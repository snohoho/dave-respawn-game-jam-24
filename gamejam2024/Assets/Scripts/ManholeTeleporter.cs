using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManholeTeleporter : MonoBehaviour
{
    [SerializeField] private Transform _destination;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.transform.position = _destination.position;
        }
    }
}
