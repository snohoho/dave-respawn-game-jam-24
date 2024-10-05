using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlexTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Default.PlayVoiceLine(VoiceLineCatalog.TestAudio);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
