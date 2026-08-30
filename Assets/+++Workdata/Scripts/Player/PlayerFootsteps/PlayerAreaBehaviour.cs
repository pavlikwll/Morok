using System;
using FMODUnity;
using UnityEngine;

public class PlayerAreaBehaviour : MonoBehaviour
{
    [Header("Footstep Timer")] [SerializeField]
    private float foostepTime;
    private float _footstepTimer;

    private StudioEventEmitter emitter;

    private void Awake()
    {
         emitter = GetComponent<StudioEventEmitter>();
    }

    private void Update()
    {
        CalculateFootstepTimer();
    }

    private void CalculateFootstepTimer()
    {
        if (PlayerStates.Instance.PlayerMovementState == PlayerMovementState.Idle) return;

        _footstepTimer += Time.deltaTime;

        if (_footstepTimer > foostepTime)
        {
            _footstepTimer = 0;
            PlayTileSound();
        }
    }

    private void PlayTileSound()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 0.02f);

        int highestPriority = -1;
        EnvironmentAreaTrigger selectedArea = null;

        foreach (var hit in hits)
        {
            EnvironmentAreaTrigger area = hit.GetComponent<EnvironmentAreaTrigger>();

            if (area != null && area.priority > highestPriority)
            {
                highestPriority = area.priority;
                selectedArea = area;
            }
        }

        if (selectedArea == null)
        {
            return;
        }

        emitter.Play();

        FMOD.RESULT result =
            emitter.EventInstance.setParameterByNameWithLabel(
                "Surface",
                selectedArea.footstepSoundArea.fmodFootstepEvent
            );

        Debug.Log("FMOD Result: " + result);

        print(selectedArea.footstepSoundArea.fmodFootstepEvent);
    }
}
    

