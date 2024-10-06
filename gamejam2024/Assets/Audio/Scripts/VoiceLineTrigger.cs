using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static VoiceLineCatalog;

public class VoiceLineTrigger : MonoBehaviour
{
    private bool _isTriggered = false;
    [SerializeField] private VoiceLineName _selectedVoiceLine;
    [SerializeField] private int trust;

    private void OnTriggerEnter(Collider other)
    {
        if (!_isTriggered && other.gameObject.tag == "Player")
        {
            _isTriggered = true;
            AudioManager.Default.PlayVoiceLine(_selectedVoiceLine);
            var trustController = other.gameObject.GetComponent<TrustController>();
            trustController.trustAddRemove(trust);
        }
    }
}
