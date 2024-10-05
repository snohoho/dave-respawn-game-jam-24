using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Voice Line Catalog", fileName = "Voice Line Catalog")]
public class VoiceLineCatalog : ScriptableObject
{
    public enum VoiceLineName
    {
        TestAudio = 0,
        TestAudio2 = 1
    }

    [SerializeField] private AudioClip[] AudioClips;

    public AudioClip GetAudioClip(VoiceLineName voiceLine) => AudioClips[(int)voiceLine];
}
