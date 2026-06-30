using System;
using UnityEngine;

public class PlayerAbilityChangeWorld : MonoBehaviour
{
    public static Action OnChangeWorld;
    
    
    [SerializeField] private int actionId;
    
    private PlayerStates _playerStates;

    public WorldLoadUnloadManager _worldLoadUnloadManager;

    public bool _inWorldOne;

    private void Awake()
    {
        _playerStates = GetComponent<PlayerStates>();

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

    private void ChangeWorld()
    {
        if (_inWorldOne)
        {
            _worldLoadUnloadManager.Load(3);
            _worldLoadUnloadManager.Unload(2);

            _inWorldOne = false;
        }
        else if (!_inWorldOne)
        {
            _worldLoadUnloadManager.Load(2);
            _worldLoadUnloadManager.Unload(3);

            _inWorldOne = true;
        }
        
        /*
        if (_playerStates.GetCurrentActionState() == PlayerActionState.Default)
        {
            PlayerAnimation.OnAction?.Invoke(actionId);
        }
        */
    }
}
