using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using static VoiceLineCatalog;

public class VoiceLineTrigger : MonoBehaviour
{
    private bool _isTriggered = false;
    [SerializeField] private VoiceLineName _selectedVoiceLine;
    [SerializeField] private int trust;
    [SerializeField] private string daveDialogue;

    [SerializeField] private TMP_Text textmesh;

    private void OnTriggerEnter(Collider other)
    {
        if (!_isTriggered && other.gameObject.tag == "Player")
        {
            _isTriggered = true;
            AudioManager.Default.PlayVoiceLine(_selectedVoiceLine);
            var trustController = other.gameObject.GetComponent<TrustController>();
            trustController.trustAddRemove(trust);

            textmesh.text = daveDialogue;   
        }
    }
}
