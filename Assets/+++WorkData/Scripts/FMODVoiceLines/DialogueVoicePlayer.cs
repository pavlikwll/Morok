using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using System;
using System.Runtime.InteropServices;

public class DialogueVoicePlayer : MonoBehaviour
{
    [SerializeField] private EventReference dialogueEvent;

    public void PlayVoice(string voiceId)
    {
        EventInstance instance = RuntimeManager.CreateInstance(dialogueEvent);

        instance.setCallback(
            (type, eventInstance, parameters) =>
            {
                if (type == EVENT_CALLBACK_TYPE.CREATE_PROGRAMMER_SOUND)
                {
                    PROGRAMMER_SOUND_PROPERTIES props =
                        Marshal.PtrToStructure<PROGRAMMER_SOUND_PROPERTIES>(parameters);

                    SOUND_INFO soundInfo;

                    FMOD.RESULT result =
                        RuntimeManager.StudioSystem.getSoundInfo(
                            voiceId,
                            out soundInfo
                        );

                    if (result != FMOD.RESULT.OK)
                    {
                        Debug.LogError(
                            $"FMOD Voice-ID nicht gefunden: {voiceId} | {result}"
                        );

                        return result;
                    }

                    FMOD.Sound sound;

                    result = RuntimeManager.CoreSystem.createSound(
                        soundInfo.name_or_data,
                        FMOD.MODE.DEFAULT |
                        FMOD.MODE.CREATECOMPRESSEDSAMPLE |
                        FMOD.MODE.NONBLOCKING |
                        soundInfo.mode,
                        ref soundInfo.exinfo,
                        out sound
                    );

                    if (result != FMOD.RESULT.OK)
                    {
                        Debug.LogError(
                            $"FMOD konnte Sound nicht erstellen: {voiceId} | {result}"
                        );

                        return result;
                    }

                    props.sound = sound.handle;
                    props.subsoundIndex = soundInfo.subsoundindex;

                    Marshal.StructureToPtr(
                        props,
                        parameters,
                        false
                    );
                }

                return FMOD.RESULT.OK;
            },
            EVENT_CALLBACK_TYPE.CREATE_PROGRAMMER_SOUND
        );

        instance.start();
        instance.release();
    }
}