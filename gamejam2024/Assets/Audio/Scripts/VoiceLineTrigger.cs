using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static VoiceLineCatalog;

public class VoiceLineTrigger : MonoBehaviour
{
    private bool _isTriggered = false;
    [SerializeField] private VoiceLineName _selectedVoiceLine;

    private void OnTriggerEnter(Collider other)
    {
        // TODO: Define what is considered colliding with the player
        if (false && !_isTriggered)
        {
            _isTriggered = true;
            AudioManager.Default.PlayVoiceLine(_selectedVoiceLine);
        }
    }
}
