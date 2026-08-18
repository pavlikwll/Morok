using System;
using UnityEngine;

public class PlayerAbilityChangeWorld : MonoBehaviour
{
    public static Action OnChangeWorld;

    private WorldTransitionAbilityCooldown _worldTransitionAbilityCooldown;
    
    
    [SerializeField] private int actionId;
    
    private PlayerStates _playerStates;

    public WorldLoadUnloadManager _worldLoadUnloadManager;

    public bool _inWorldOne;

    private void Awake()
    {
        _playerStates = GetComponent<PlayerStates>();
        _worldTransitionAbilityCooldown = GetComponent<WorldTransitionAbilityCooldown>();

        _inWorldOne = true;
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
        if (_inWorldOne && GetComponent<PlayerAbilityChangeWorld>().enabled)
        {
            _worldLoadUnloadManager.Load(3);
            _worldLoadUnloadManager.Unload(2);

            _inWorldOne = false;
            GetComponent<PlayerAbilityChangeWorld>().enabled = false;
            _worldTransitionAbilityCooldown.ChangeWorldCooldown();
        }
        else if (!_inWorldOne && GetComponent<PlayerAbilityChangeWorld>().enabled)
        {
            _worldLoadUnloadManager.Load(2);
            _worldLoadUnloadManager.Unload(3);

            _inWorldOne = true;
            GetComponent<PlayerAbilityChangeWorld>().enabled = false;
            _worldTransitionAbilityCooldown.ChangeWorldCooldown();
        }
        

        /*
        if (_playerStates.GetCurrentActionState() == PlayerActionState.Default)
        {
            PlayerAnimation.OnAction?.Invoke(actionId);
        }
        */
    }
}
