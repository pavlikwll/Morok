using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using System.Runtime.InteropServices;

public class DialogueVoicePlayer : MonoBehaviour
{
    [SerializeField] private EventReference dialogueEvent;

    private EventInstance currentInstance;
    private FMOD.Sound currentSound;

    public void PlayVoice(string voiceId)
    {
        if (string.IsNullOrWhiteSpace(voiceId))
            return;

        StopVoice();

        // Beispiel:
        // father_001 -> Father/father_001
        // jack_035   -> Jack/jack_035
        // emily_020  -> Emily/emily_020

        string character = voiceId.Split('_')[0];

        if (string.IsNullOrWhiteSpace(character))
        {
            Debug.LogError($"Ungültige Voice-ID: {voiceId}");
            return;
        }

        string folderName =
            char.ToUpper(character[0]) +
            character.Substring(1);

        string fmodKey =
            folderName + "/" + voiceId;

        Debug.Log(
            $"Playing Voice: {voiceId} | FMOD Key: {fmodKey}"
        );

        currentInstance =
            RuntimeManager.CreateInstance(dialogueEvent);

        currentInstance.setCallback(
            (type, eventInstance, parameters) =>
            {
                if (
                    type ==
                    EVENT_CALLBACK_TYPE.CREATE_PROGRAMMER_SOUND
                )
                {
                    PROGRAMMER_SOUND_PROPERTIES props =
                        Marshal.PtrToStructure<
                            PROGRAMMER_SOUND_PROPERTIES
                        >(parameters);

                    SOUND_INFO soundInfo;

                    FMOD.RESULT result =
                        RuntimeManager.StudioSystem.getSoundInfo(
                            fmodKey,
                            out soundInfo
                        );

                    if (result != FMOD.RESULT.OK)
                    {
                        Debug.LogError(
                            $"FMOD Voice-ID nicht gefunden: " +
                            $"{fmodKey} | {result}"
                        );

                        return result;
                    }

                    result =
                        RuntimeManager.CoreSystem.createSound(
                            soundInfo.name_or_data,

                            FMOD.MODE.DEFAULT |
                            FMOD.MODE.CREATECOMPRESSEDSAMPLE |
                            FMOD.MODE.NONBLOCKING |
                            soundInfo.mode,

                            ref soundInfo.exinfo,

                            out currentSound
                        );

                    if (result != FMOD.RESULT.OK)
                    {
                        Debug.LogError(
                            $"FMOD konnte Sound nicht erstellen: " +
                            $"{fmodKey} | {result}"
                        );

                        return result;
                    }

                    props.sound =
                        currentSound.handle;

                    props.subsoundIndex =
                        soundInfo.subsoundindex;

                    Marshal.StructureToPtr(
                        props,
                        parameters,
                        false
                    );
                }

                if (
                    type ==
                    EVENT_CALLBACK_TYPE.DESTROY_PROGRAMMER_SOUND
                )
                {
                    if (currentSound.hasHandle())
                    {
                        currentSound.release();
                        currentSound.clearHandle();
                    }
                }

                return FMOD.RESULT.OK;
            },

            EVENT_CALLBACK_TYPE.CREATE_PROGRAMMER_SOUND |
            EVENT_CALLBACK_TYPE.DESTROY_PROGRAMMER_SOUND
        );

        FMOD.RESULT startResult =
            currentInstance.start();

        if (startResult != FMOD.RESULT.OK)
        {
            Debug.LogError(
                $"FMOD Event konnte nicht gestartet werden: " +
                $"{fmodKey} | {startResult}"
            );
        }
    }

    public void StopVoice()
    {
        if (!currentInstance.isValid())
            return;

        currentInstance.stop(
            FMOD.Studio.STOP_MODE.IMMEDIATE
        );

        currentInstance.release();
        currentInstance.clearHandle();
    }

    private void OnDestroy()
    {
        StopVoice();
    }
}