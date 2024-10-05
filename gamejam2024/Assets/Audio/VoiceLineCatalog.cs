using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Voice Line Catalog", fileName = "Voice Line Catalog")]
public class VoiceLineCatalog : ScriptableObject
{
    public static int TestAudio => 0;
    public static int TestAudio2 => 1;

    [SerializeField] private AudioClip[] AudioClips;

    public AudioClip GetAudioClip(int index) => AudioClips[index];
}
