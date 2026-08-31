using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;


public enum NPCFacingDirection{Up, Down, Left, Right}
public class NavMeshPatrol : MonoBehaviour
{
    
    private int HashMovementValue = Animator.StringToHash("MovementValue");
    private int HashDirX = Animator.StringToHash("xDir");
    private int HashDirY = Animator.StringToHash("yDir");
    private int HashActionTrigger = Animator.StringToHash("ActionTrigger");
    private int HashActionId = Animator.StringToHash("ActionId");
    
    #region Inspector
    
        [Header("NPC States")] 
        [SerializeField] private NPCFacingDirection npcFacingDirection;
    
    
        [FormerlySerializedAs("_anim")]
        [Header("NPC Reference")]
        [SerializeField] private Animator animator;
        [SerializeField] private bool startDirectionIsRight = false;
        
        [Header("Waypoins")] 
        [SerializeField] private List<Transform> waypoints;
        [SerializeField] private bool waitAtWaypoint = true;
        [SerializeField] private bool randomOrder;
        [SerializeField] private bool canPatrol = true;
    
        [SerializeField] private Vector2 waitDuration = new Vector2(1, 5);
        
    
        [Header("Gizmos")] 
        [SerializeField] private bool showWaypoints;
        
    #endregion

    #region Private Variables
        private NavMeshAgent _agent;
        private int _currentWaypointIndex;
        private bool _isWaiting;
        private Transform _target;
        
        private Vector2 _lookDirection;


    #endregion


    #region Event Functions
    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.autoBraking = waitAtWaypoint;
    }

    private void Start()
    {
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
        
        if (canPatrol && waypoints.Count > 0 && _agent.isOnNavMesh)
        {
            SetNextWaypoint();
        }
    }

    private void Update()
    {
        if (_agent == null || !_agent.enabled || !_agent.isOnNavMesh)
        {
            return;
        }
        
        if (canPatrol)
        {
            if (_agent.isStopped) return;
            
            CheckIfWaypointIsReached();
            return;
        }


        if (!_agent.isStopped && !_agent.pathPending)
        {
            _agent.SetDestination(_target.position);
        }

        Vector2 direction = _agent.velocity;
        
        //if (_anim) //TODO: add animator logic 
        
        RotateObject(direction);
    }
    
    private void LateUpdate()
    {
        UpdateFacing();
        UpdateAniamtor();
    }
    
    #endregion


    #region Navigation

    private void UpdateFacing()
    {
        Vector2 velocity = _agent.velocity;

        if (velocity.sqrMagnitude > 0.0001f)
        {
            _lookDirection = velocity.normalized;
        }
        
        UpdateFacingDirection(_lookDirection);
        RotateObject(_lookDirection);
    }
    
    private void UpdateFacingDirection(Vector2 dir)
    {
        if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
        {
            npcFacingDirection = dir.x > 0 ? NPCFacingDirection.Right : NPCFacingDirection.Left;
        }
        else
        {
            npcFacingDirection = dir.y > 0 ? NPCFacingDirection.Up : NPCFacingDirection.Down;
        }

        SetAnimationDirection(new Vector2(dir.x, dir.y));
        /*
        switch (enemyFacingDirection)
        {
            case EnemyFacingDirection.Up:

                break;

            case EnemyFacingDirection.Down:
                SetAnimationDirection(new Vector2(0, -1));
                break;

            case EnemyFacingDirection.Left:
                SetAnimationDirection(new Vector2(-1, 0));
                break;

            case EnemyFacingDirection.Right:
                SetAnimationDirection(new Vector2(1, 0));
                break;
        }*/
    }

    private void RotateObject(Vector2 direction)
    {
        if (direction.x < 0)
        {
            animator.transform.rotation = Quaternion.Euler(0, startDirectionIsRight ? 180 : 0, 0);
        }
        else if (direction.x > 0)
        {
            animator.transform.rotation = Quaternion.Euler(0, startDirectionIsRight ? 0 : 180, 0);
        }
    }

    private void StopPatrolForDialogue()
    {
        //TODO: Dialogue Logic
    }

    public void StopPatrol()
    {
        if (_agent != null && _agent.enabled && _agent.isOnNavMesh)
        {
            _agent.isStopped = true;
        }
    }
    
    public void ResumePatrol()
    {
        if (_agent != null && _agent.enabled && _agent.isOnNavMesh)
        {
            _agent.isStopped = false;
        }
    }
    
    public void TogglePatrol()
    {
        _agent.isStopped = !_agent.isStopped;
        canPatrol = !canPatrol;
    }
    
    public void SetNewTarget(Transform newTarget)
    {
        _target = newTarget;
        _agent.isStopped = false;
        canPatrol = false;
        _agent.SetDestination(_target.position);
    }

    private void SetNextWaypoint()
    {
        if (_agent == null || !_agent.enabled || !_agent.isOnNavMesh)
        {
            return;
        }

        if (waypoints == null || waypoints.Count == 0)
        {
            canPatrol = false;
            return;
        }
        
        if (randomOrder && waypoints.Count > 1)
        {
            int newWaypointIndex;

            do
            {
                newWaypointIndex = Random.Range(0, waypoints.Count);
            }
            while (newWaypointIndex == _currentWaypointIndex);

            _currentWaypointIndex = newWaypointIndex;
        }
        else
        {
            _currentWaypointIndex = (_currentWaypointIndex + 1) % waypoints.Count;
        }

        _agent.SetDestination(waypoints[_currentWaypointIndex].position);
    }

    private void CheckIfWaypointIsReached()
    {
        if (_isWaiting) return;
        if (_agent.pathPending) return;

        if (_agent.remainingDistance <= _agent.stoppingDistance + 0.01f)
        {
            if (waitAtWaypoint)
            {
                StartCoroutine(WaitBeforeNextWaypoint(Random.Range(waitDuration.x, waitDuration.y)));
            }
            else
            {
                SetNextWaypoint();
            }
        }
    }

    private IEnumerator WaitBeforeNextWaypoint(float duration)
    {
        _isWaiting = true;
        yield return new WaitForSeconds(duration);
        _isWaiting = false;
        SetNextWaypoint();
    }

    public void SetNewWaypoints(List<Transform> newWaypoint)
    {
        waypoints = newWaypoint;
        canPatrol = true;
    }

    #endregion
    
    #region Animation

    private void UpdateAniamtor()
    {
        animator.SetFloat(HashMovementValue, _agent.velocity.magnitude);
    }

    private void SetAnimationDirection(Vector2 direction)
    {
        animator.SetFloat(HashDirX, direction.x);
        animator.SetFloat(HashDirY, direction.y);
    }

    private void SetAnimationAction(int actionId)
    {
        animator.SetTrigger(HashActionTrigger);
        animator.SetInteger(HashActionId, actionId);
    }

    #endregion
}
