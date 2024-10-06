using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrustController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject daveEmotion;
    [SerializeField] private Sprite daveHappy;
    [SerializeField] private Sprite daveNeutral;
    [SerializeField] private Sprite daveSad;

    public int trustLevel;
    private Image img;

    // Start is called before the first frame update
    void Start()
    {
        img = daveEmotion.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void trustAddRemove(int trust) {
        trustLevel += trust;

        if(trustLevel >= 0) {
            img.sprite = daveHappy;
        }
        if(trustLevel < 0 && trust >= -3) {
            img.sprite = daveNeutral;
        }
        if(trustLevel < -3) {
            img.sprite = daveSad;
        }
    }
}
