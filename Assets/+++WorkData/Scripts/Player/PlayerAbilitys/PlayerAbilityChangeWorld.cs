using System;
using UnityEngine;

public class PlayerAbilityChangeWorld : MonoBehaviour
{
    public static Action OnChangeWorld;

    private WorldTransitionAbilityCooldown _worldTransitionAbilityCooldown;
    
    [SerializeField] private int actionId;
    
    private PlayerStates _playerStates;

    public GameObject blackscreen;

    public WorldLoadUnloadManager _worldLoadUnloadManager;

    private SortItemsToWorlds _sortItemsToWorlds;
    
    public bool _inWorldOne;

    public bool worldChangeAllowed;

    private void Awake()
    {
        _playerStates = GetComponent<PlayerStates>();
        _worldTransitionAbilityCooldown = GetComponent<WorldTransitionAbilityCooldown>();
        _sortItemsToWorlds = GetComponent<SortItemsToWorlds>();

        _inWorldOne = true;
        worldChangeAllowed  = true;
    }
    
    private void OnEnable()
    {
        OnChangeWorld += ChangeWorld;
    }

    private void OnDisable()
    {
        OnChangeWorld -= ChangeWorld;
    }

    public void ChangeWorld()
    {
        if (!worldChangeAllowed) return;
        
        if (_inWorldOne && GetComponent<PlayerAbilityChangeWorld>().enabled)
        {
            blackscreen.SetActive(true);
            
            _worldLoadUnloadManager.Load(3);
            _worldLoadUnloadManager.Unload(2);

            _inWorldOne = false;
            GetComponent<PlayerAbilityChangeWorld>().enabled = false;
            _worldTransitionAbilityCooldown.ChangeWorldCooldown();
            
            _sortItemsToWorlds.DeactivateNormalWorldObjects();
            _sortItemsToWorlds.ActivateSecondWorldObjects();
        }
        else if (!_inWorldOne && GetComponent<PlayerAbilityChangeWorld>().enabled)
        {
            blackscreen.SetActive(true);
            
            _worldLoadUnloadManager.Load(2);
            _worldLoadUnloadManager.Unload(3);

            _inWorldOne = true;
            GetComponent<PlayerAbilityChangeWorld>().enabled = false;
            _worldTransitionAbilityCooldown.ChangeWorldCooldown();
            
            _sortItemsToWorlds.ActivateNormalWorldObjects();
            _sortItemsToWorlds.DeactivateSecondWorldObjects();
        }
        

        /*
        if (_playerStates.GetCurrentActionState() == PlayerActionState.Default)
        {
            PlayerAnimation.OnAction?.Invoke(actionId);
        }
        */
    }

    public void WorldChangeAllowed()
    {
        worldChangeAllowed = true;
    }

    public void WorldChangeDenied()
    {
        worldChangeAllowed = false;
    }
}
