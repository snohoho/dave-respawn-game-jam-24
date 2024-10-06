using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonClick : MonoBehaviour
{
    [SerializeField] private GameObject dialogueMenu;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void dialogueToSettings() {
        dialogueMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void settingsToDialogue() {
        settingsMenu.SetActive(false);
        dialogueMenu.SetActive(true);
    }

    public void mainToDialogue() {
        player.GetComponent<PlayerController>().LeaveMM();
        AudioManager.Default.PlayVoiceLine(VoiceLineCatalog.VoiceLineName.Game_Start);

        mainMenu.SetActive(false);
        dialogueMenu.SetActive(true);
    }

    public void restartGame() {
        SceneManager.LoadScene("BasicMap");
    }

    public void hangUp() {
        SceneManager.LoadScene("EndScene");
    }
}
