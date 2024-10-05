using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _default;
    
    [SerializeField] private AudioSource _soundPlayer;
    [SerializeField] private AudioSource _musicPlayer;
    [SerializeField] private VoiceLineCatalog _voiceLineCatalog;

    public static AudioManager Default
    {
        get
        {
            // A little smelly using GameObject.Find
            if (_default == null)
                _default = GameObject.Find("AudioManager").GetComponent<AudioManager>();

            return _default;
        }
    }

    private void Update()
    {
        // Test
#if UNITY_EDITOR

        if (Input.GetKeyDown(KeyCode.Alpha1))
            PlayVoiceLine(VoiceLineCatalog.TestAudio);

        if (Input.GetKeyDown(KeyCode.Alpha2))
            PlayVoiceLine(VoiceLineCatalog.TestAudio2);

#endif

    }

    public void PlayVoiceLine(int index)
    {
        // This guy prevents overlapping multiple sounds
        _soundPlayer.clip = _voiceLineCatalog.GetAudioClip(index);
        _soundPlayer.Play();

        // This guy doesn't care and you can have as many sounds overlapping as you want
        //_soundPlayer.PlayOneShot(_voiceLineCatalog.GetAudioClip(index));
    }

    public void PlaySound(int index)
    {
        throw new NotImplementedException();
        //_soundPlayer.PlayOneShot(_voiceLineCatalog.GetAudioClip(index));
    }

    public void PlayMusic(int index)
    {
        throw new NotImplementedException();
    }
}
