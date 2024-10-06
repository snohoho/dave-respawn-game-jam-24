using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    [SerializeField] private GameObject dialogueMenu;
    [SerializeField] private GameObject settingsMenu;

    private bool inSettings;

    // Start is called before the first frame update
    void Start()
    {
        inSettings = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClick() {
        inSettings = !inSettings;

        if(inSettings) {
            Debug.Log("move to settings menu");
            dialogueMenu.SetActive(false);
            settingsMenu.SetActive(true);
        }
        else {
            Debug.Log("move to dialogue menu");
            settingsMenu.SetActive(false);
            dialogueMenu.SetActive(true);
        }
    }
}
