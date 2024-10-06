using System;
using System.Collections;
using System.Collections.Generic;
using System.Security;
using TMPro;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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
        if(gameObject.tag == "HouseLeave") {
            var homeReturn = gameObject.GetComponent<TriggerActivator>();
            homeReturn.houseLeaveTrigger.SetActive(true);
        }

        //ending triggers dave house
        if(gameObject.tag == "EndTrigger") {
            int trustLevel = other.gameObject.GetComponent<TrustController>().trustLevel;
            if(trustLevel >= 0) {
               StartCoroutine(playEndDialogue(VoiceLineName.Trust_ending));
            }
            if(trustLevel < 0 && trust >= -3) {
                StartCoroutine(playEndDialogue(VoiceLineName.Kinda_fed_up));
            }
                
            if(trustLevel < -3) {
                StartCoroutine(playEndDialogue(VoiceLineName.Completely_fed_up));
            }

            
        }

        //end trigger house return
        if(gameObject.tag == "HouseReturn") {

        }

        if (!_isTriggered && other.gameObject.tag == "Player")
        {
            _isTriggered = true;
            AudioManager.Default.PlayVoiceLine(_selectedVoiceLine);
            var trustController = other.gameObject.GetComponent<TrustController>();
            trustController.trustAddRemove(trust);

            textmesh.text = daveDialogue;   
        }
    }

    IEnumerator playEndDialogue(VoiceLineName voiceline) {
        AudioManager.Default.PlayVoiceLine(voiceline);

        yield return new WaitForSeconds(10);

        SceneManager.LoadScene("EndScene");
    }
}
