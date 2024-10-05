using System;
using UnityEngine;
using static VoiceLineCatalog;

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
            PlayVoiceLine(VoiceLineName.TestAudio);

        if (Input.GetKeyDown(KeyCode.Alpha2))
            PlayVoiceLine(VoiceLineName.TestAudio2);

#endif

    }

    public void PlayVoiceLine(VoiceLineName voiceLine)
    {
        _soundPlayer.clip = _voiceLineCatalog.GetAudioClip(voiceLine);
        _soundPlayer.Play();
    }

    public void PlaySound(int index)
    {
        throw new NotImplementedException();
    }

    public void PlayMusic(int index)
    {
        throw new NotImplementedException();
    }
}
