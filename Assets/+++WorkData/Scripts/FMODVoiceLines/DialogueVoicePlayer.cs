using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using System;
using System.Runtime.InteropServices;

public class DialogueVoicePlayer : MonoBehaviour
{
    [SerializeField] private EventReference dialogueEvent;

    private EventInstance currentInstance;

    private static readonly EVENT_CALLBACK callback =
        ProgrammerSoundCallback;

    private class VoiceContext
    {
        public string key;
        public FMOD.Sound sound;
    }

    public void PlayVoice(string voiceId)
    {
        if (string.IsNullOrWhiteSpace(voiceId))
            return;

        StopVoice();

        string character = voiceId.Split('_')[0];

        string folder =
            char.ToUpper(character[0]) +
            character.Substring(1);

        string fmodKey =
            folder + "/" + voiceId;

        Debug.Log($"Voice: {voiceId} -> {fmodKey}");

        VoiceContext context = new VoiceContext
        {
            key = fmodKey
        };

        GCHandle handle = GCHandle.Alloc(context);
        IntPtr handlePtr = GCHandle.ToIntPtr(handle);

        currentInstance =
            RuntimeManager.CreateInstance(dialogueEvent);

        if (!currentInstance.isValid())
        {
            handle.Free();
            Debug.LogError("Dialogue FMOD Event konnte nicht erstellt werden.");
            return;
        }

        FMOD.RESULT result =
            currentInstance.setUserData(handlePtr);

        if (result != FMOD.RESULT.OK)
        {
            handle.Free();
            currentInstance.release();
            currentInstance.clearHandle();

            Debug.LogError(
                $"FMOD setUserData Fehler: {result}"
            );

            return;
        }

        result = currentInstance.setCallback(
            callback,
            EVENT_CALLBACK_TYPE.CREATE_PROGRAMMER_SOUND |
            EVENT_CALLBACK_TYPE.DESTROY_PROGRAMMER_SOUND |
            EVENT_CALLBACK_TYPE.DESTROYED
        );

        if (result != FMOD.RESULT.OK)
        {
            handle.Free();
            currentInstance.release();
            currentInstance.clearHandle();

            Debug.LogError(
                $"FMOD Callback Fehler: {result}"
            );

            return;
        }

        result = currentInstance.start();

        if (result != FMOD.RESULT.OK)
        {
            Debug.LogError(
                $"FMOD Start Fehler: {result}"
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

    [AOT.MonoPInvokeCallback(typeof(EVENT_CALLBACK))]
    private static FMOD.RESULT ProgrammerSoundCallback(
        EVENT_CALLBACK_TYPE type,
        IntPtr eventInstancePtr,
        IntPtr parameters)
    {
        EventInstance instance =
            new EventInstance(eventInstancePtr);

        FMOD.RESULT result =
            instance.getUserData(out IntPtr userData);

        if (result != FMOD.RESULT.OK)
            return result;

        if (userData == IntPtr.Zero)
            return FMOD.RESULT.OK;

        GCHandle handle =
            GCHandle.FromIntPtr(userData);

        VoiceContext context =
            handle.Target as VoiceContext;

        if (context == null)
            return FMOD.RESULT.OK;

        if (type ==
            EVENT_CALLBACK_TYPE.CREATE_PROGRAMMER_SOUND)
        {
            PROGRAMMER_SOUND_PROPERTIES props =
                Marshal.PtrToStructure<
                    PROGRAMMER_SOUND_PROPERTIES
                >(parameters);

            result =
                RuntimeManager.StudioSystem.getSoundInfo(
                    context.key,
                    out SOUND_INFO soundInfo
                );

            if (result != FMOD.RESULT.OK)
                return result;

            result =
                RuntimeManager.CoreSystem.createSound(
                    soundInfo.name_or_data,
                    FMOD.MODE.DEFAULT |
                    FMOD.MODE.CREATECOMPRESSEDSAMPLE |
                    FMOD.MODE.NONBLOCKING |
                    soundInfo.mode,
                    ref soundInfo.exinfo,
                    out context.sound
                );

            if (result != FMOD.RESULT.OK)
                return result;

            props.sound = context.sound.handle;
            props.subsoundIndex =
                soundInfo.subsoundindex;

            Marshal.StructureToPtr(
                props,
                parameters,
                false
            );
        }

        else if (
            type ==
            EVENT_CALLBACK_TYPE.DESTROY_PROGRAMMER_SOUND)
        {
            if (context.sound.hasHandle())
            {
                context.sound.release();
                context.sound.clearHandle();
            }
        }

        else if (
            type ==
            EVENT_CALLBACK_TYPE.DESTROYED)
        {
            if (handle.IsAllocated)
                handle.Free();
        }

        return FMOD.RESULT.OK;
    }

    private void OnDestroy()
    {
        StopVoice();
    }
}