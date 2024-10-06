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


    private void OnTriggerEnter(Collider other)
    {
        if(gameObject.tag == "HouseLeave") {
            var homeReturn = gameObject.GetComponent<TriggerActivator>();
            homeReturn.activeTrigger.SetActive(true);
            gameObject.SetActive(false);

            return;
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

        if(gameObject.tag == "ParkourStart") {
            var parkour = gameObject.GetComponent<TriggerActivator>();
            parkour.activeTrigger.SetActive(true);
            gameObject.SetActive(false);
        }
    
        if(gameObject.tag == "ParkourEnd") {
            var parkour = gameObject.GetComponent<TriggerActivator>();
            parkour.activeTrigger.SetActive(false);
            gameObject.SetActive(false);
        }

        //end trigger house return
        if(gameObject.tag == "HouseReturn") {
            StartCoroutine(playEndDialogue(VoiceLineName.Arriving_home));
        }

        if(gameObject.tag == "ParkourDie") {
            SceneManager.LoadScene("EndScene");
        }

        if(gameObject.tag == "PoolEnd") {
            StartCoroutine(playEndDialogue(VoiceLineName.Pool_ending));
        }  

        if(gameObject.tag == "McdonaldsEnd") {
            StartCoroutine(playEndDialogue(VoiceLineName.McDonalds_ending));
        }  


        if (!_isTriggered && other.gameObject.tag == "Player")
        {
            _isTriggered = true;
            AudioManager.Default.PlayVoiceLine(_selectedVoiceLine);
            var trustController = other.gameObject.GetComponent<TrustController>();
            trustController.trustAddRemove(trust); 
        }
    }

    IEnumerator playEndDialogue(VoiceLineName voiceline) {
        AudioManager.Default.PlayVoiceLine(voiceline);

        yield return new WaitForSeconds(15);

        SceneManager.LoadScene("EndScene");
    }
}
