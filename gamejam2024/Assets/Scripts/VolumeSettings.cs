using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider volumeSlider;
    private float volume;

    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.value = 10;
    }

    // Update is called once per frame
    void Update()
    {
        volume = volumeSlider.value;
        audioMixer.SetFloat("master",volume);
    }

    public void SetVolume() {

    }
}
