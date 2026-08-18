using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSettings : MonoBehaviour
{
     private FMOD.Studio.EventInstance SFXVolumeTestEvent;
     private FMOD.Studio.EventInstance VoiceVolumeTestEvent;
     
     FMOD.Studio.Bus Music;
     FMOD.Studio.Bus SFX;
     FMOD.Studio.Bus Voice;
     FMOD.Studio.Bus Master;
     float MusicVolume = 1f;
     float SFXVolume = 1f;
     float VoiceVolume = 1f;
     float MasterVolume = 1f;

     void Awake ()
     {
          Music = FMODUnity.RuntimeManager.GetBus ("bus:/MusicBus");
          SFX = FMODUnity.RuntimeManager.GetBus ("bus:/SFXBus");
          Voice = FMODUnity.RuntimeManager.GetBus ("bus:/VoiceBus");
          Master = FMODUnity.RuntimeManager.GetBus ("bus:/");

          SFXVolumeTestEvent = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/SFXVolumeTestEvent");
          VoiceVolumeTestEvent = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/VoiceVolumeTestEvent");
     }

    void Update () 
     {
          Music.setVolume (MusicVolume);
          SFX.setVolume (SFXVolume);
          Voice.setVolume (VoiceVolume);
          Master.setVolume (MasterVolume);
     }

     public void MasterVolumeLevel (float newMasterVolume)
     {
          MasterVolume = newMasterVolume;
     }

     public void MusicVolumeLevel (float newMusicVolume)
     {
          MusicVolume = newMusicVolume;
     }
     
     public void VoiceVolumeLevel (float newVoiceVolume)
     {
          VoiceVolume = newVoiceVolume;
          
          FMOD.Studio.PLAYBACK_STATE PbState;
          VoiceVolumeTestEvent.getPlaybackState(out PbState);
          if (PbState != FMOD.Studio.PLAYBACK_STATE.PLAYING)
          {
               VoiceVolumeTestEvent.start();
          }
     }

     public void SFXVolumeLevel (float newSFXVolume)
     {
          SFXVolume = newSFXVolume;

          FMOD.Studio.PLAYBACK_STATE PbState;
          SFXVolumeTestEvent.getPlaybackState(out PbState);
          if (PbState != FMOD.Studio.PLAYBACK_STATE.PLAYING)
          {
               SFXVolumeTestEvent.start();
          }
     }
}