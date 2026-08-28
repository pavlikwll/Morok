using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTransitionAbilityCooldown : MonoBehaviour
{

    private PlayerAbilityChangeWorld _playerAbilityChangeWorld;
    
    public GameObject timerVisual;
    public GameObject timerVisual2;
    
    private Coroutine _changeWorldCooldown;

    private void Awake()
    {
        _playerAbilityChangeWorld = GetComponent<PlayerAbilityChangeWorld>();
    }

    public void ChangeWorldCooldown()
    {
        _changeWorldCooldown = StartCoroutine(ChangeWorldCooldownTimer());
    }

    IEnumerator ChangeWorldCooldownTimer()
    {
        Debug.Log("start");
        timerVisual.SetActive(true);
        timerVisual2.SetActive(true);
        yield return new WaitForSeconds(5);
        Debug.Log("end");
        _playerAbilityChangeWorld.enabled = true;
    }
}
