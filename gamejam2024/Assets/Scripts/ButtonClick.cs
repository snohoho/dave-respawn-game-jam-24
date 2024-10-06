using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    [SerializeField] private GameObject dialogueMenu;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject mainMenu;

    private bool inSettings;
    private bool inDialogue;

    // Start is called before the first frame update
    void Start()
    {
        inSettings = false;
        inDialogue = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void mainToDialogue() {
        mainMenu.SetActive(false);
        dialogueMenu.SetActive(true);
    }

    public void dialogueToSettings() {
        dialogueMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void settingsToDialogue() {
        settingsMenu.SetActive(false);
        dialogueMenu.SetActive(true);
    }

    public void settingsToMain() {
        mainMenu.SetActive(false);
        dialogueMenu.SetActive(true);
    }

    public void exitGame() {
        Application.Quit();
    }
}
