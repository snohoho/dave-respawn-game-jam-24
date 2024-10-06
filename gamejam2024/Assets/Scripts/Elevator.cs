using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public Rigidbody rb;

    public float speed = 3f;
    public bool goingUp;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (rb == null)
        {
            throw new System.Exception("no rb");
        }

        goingUp = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (goingUp)
        {
            rb.velocity = new Vector3(0, speed, 0);
        }
        else
        {
            rb.velocity = new Vector3(0, -speed, 0);
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            Debug.Log("floor contact");
            goingUp = true;
        }
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "ElevatorCeiling")
        {
            Debug.Log("max y position reached");
            goingUp = false;
        }
    }

    /*private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            Debug.Log("floor . uncontact");
            goingUp = !goingUp;
        }
    }*/
}


