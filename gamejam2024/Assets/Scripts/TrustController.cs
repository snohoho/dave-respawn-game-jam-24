using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrustController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private int trustLevel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void trustAddRemove(int trust) {
        trustLevel += trust;
    }
}
