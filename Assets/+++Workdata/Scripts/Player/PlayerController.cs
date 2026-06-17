using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static Action<Vector2> OnMoveInput;
    public static Action<float> OnAddForce;
    public static Action OnActionEnd;
    
    #region Inspektor
    
    [Header("Movement")]
    [SerializeField] private float walkingSpeed = 5f;
    [SerializeField] private float accelerationTime = 10f;

    #endregion

    #region Private Variables
    
    private PlayerDirection _playerDirection;
    private PlayerAction _playerAction;
    
    [SerializeField] private Vector2 _moveInput;
    public Vector2 MoveInput => _moveInput;

    private Vector2 _lastGivenInput;
    
    private Rigidbody2D _rb;
    public Rigidbody2D Rb => _rb;
    
    private float _currentSpeed;

    #endregion

    #region UnityEvents

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerDirection = GetComponent<PlayerDirection>();
        _playerAction = GetComponent<PlayerAction>();
        
        _currentSpeed = walkingSpeed;
    }

    private void OnEnable()
    {
        OnMoveInput += SetMoveInput;
        OnAddForce += SetForce;
        OnActionEnd += SetLastGivenInput;
    }

    private void FixedUpdate()
    {
        MovementHandler();
    }

    private void OnDisable()
    {
        OnMoveInput -= SetMoveInput;
        OnAddForce -= SetForce;
        OnActionEnd -= SetLastGivenInput;

    }

    #endregion

    #region Handler Methodes

    private void MovementHandler()
    {
        
        Vector2 targetVelocity = _moveInput * _currentSpeed;
        Vector2 currentVelocity = _rb.linearVelocity;

        if (_playerAction.GetCurrentActionState() != PlayerActionState.Default)
        {
            targetVelocity = Vector2.zero;
        }
        
        if (_playerAction.GetCurrentActionState() == PlayerActionState.Rolling) return;
        
        _rb.linearVelocity = Vector2.Lerp(currentVelocity, targetVelocity, Time.fixedDeltaTime * accelerationTime);
    }
    
    private void SetMoveInput(Vector2 input)
    {
        _moveInput = input;
        _lastGivenInput = input;
     
        if (_playerAction.GetCurrentActionState() != PlayerActionState.Default)
        {
            _moveInput = Vector2.zero;
        }
        
            
        
        if (_moveInput.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (_moveInput.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    #endregion
    
    #region Physics
    
    private void SetForce(float force)
    {
        Vector2 forceDir = Vector2.zero;
        switch (_playerDirection.GetPlayerDirection())
        {
            case PlayerDirectionState.Down:
                forceDir = Vector2.down;
                break;
            
            case PlayerDirectionState.Up:
                forceDir = Vector2.up;
                break;
            
            case PlayerDirectionState.Left:
                forceDir = Vector2.left;
                break;
            
            case PlayerDirectionState.Right:
                forceDir = Vector2.right;
                break;
        }
        _rb.AddForce(forceDir * force, ForceMode2D.Impulse);
    }
    
    #endregion
    
    #region InputMethodRegion

    private void SetLastGivenInput()
    {
        SetMoveInput(_lastGivenInput);
    }
    
    #endregion
}