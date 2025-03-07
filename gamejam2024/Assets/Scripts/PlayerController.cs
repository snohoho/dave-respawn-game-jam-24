using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //object references
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject phone;
    [SerializeField] private Slider sensSlider;
    
    //regular movement
    [SerializeField] private float speed = 300f;
    [SerializeField] private float jumpHeight = 10f;
    private Vector2 moveInput;
    private bool isJumping;
    private bool canJump;

    //camera stuff
    private float camSensitivity = 0.15f;
    private float newCamSensitivity;
    private float camX;
    private bool usingCam;
    private Vector3 initialCamPos;
    private Vector3 initialCamRot;

    private bool isRotating;
    public bool inMainMenu;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        isJumping = false;
        canJump = true;

        //camera handling
        camX = cam.transform.localRotation.eulerAngles.x;
        initialCamPos = cam.transform.localPosition;
        initialCamRot = cam.transform.localRotation.eulerAngles;
        Cursor.lockState = CursorLockMode.Locked;
        usingCam = false;
        isRotating = false;

        sensSlider.value = camSensitivity;
        inMainMenu = true;
        
        var targetPos = phone.transform.localPosition;
        targetPos.y = cam.transform.localPosition.y;
        var targetRot = new Vector3(89,0,0);

        initialCamPos = cam.transform.localPosition;
        initialCamRot = cam.transform.localRotation.eulerAngles;

        StartCoroutine(CamRotation(targetPos, targetRot));             
        camSensitivity = 0.01f;
        Cursor.lockState = CursorLockMode.None;
    }


    void Update()
    {

    }

    void FixedUpdate()
    {
        rb.velocity = transform.TransformVector(new Vector3(moveInput.x * speed * Time.deltaTime, 
                                rb.velocity.y, 
                                moveInput.y * speed * Time.deltaTime));
        if(isJumping) {
            rb.velocity += new Vector3(0,jumpHeight,0);
            isJumping = false;
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        if(inMainMenu) {
            return;
        }

        if (context.started || context.performed) {
            moveInput = context.ReadValue<Vector2>();
        }
        if (context.canceled) {
            moveInput = Vector2.zero;
        }
    }

    public void Jump(InputAction.CallbackContext context) {
        if(inMainMenu) {
            return;
        }

        if(context.started || context.performed) {
            if (canJump)
            {
                canJump = false;
                isJumping = true;
            }
        }
    }

    public void Look(InputAction.CallbackContext context)
    {
        if(isRotating) {
            return;
        }

        var lookVector = context.ReadValue<Vector2>();

        camX += -lookVector.y * camSensitivity;
        camX = Mathf.Clamp(camX, -89, 89);

        if(usingCam) {
            cam.transform.localRotation = Quaternion.Euler(camX, cam.transform.localRotation.y, cam.transform.localRotation.z);
            transform.Rotate(0, lookVector.x * camSensitivity, 0);
        }
        else {
            cam.transform.localRotation = Quaternion.Euler(camX, cam.transform.localRotation.y, cam.transform.localRotation.z);
            transform.Rotate(0, lookVector.x * camSensitivity, 0);
        }      
    }

    public void UnlockCam(InputAction.CallbackContext context) {
        if(inMainMenu) {
            return;
        }
        
        if (context.started) {
            usingCam = !usingCam;

            if(usingCam) {
                StartCoroutine(CamRotation(initialCamPos,initialCamRot));            
                camSensitivity = newCamSensitivity;
                Cursor.lockState = CursorLockMode.Locked;
            }
            else {
                var targetPos = phone.transform.localPosition;
                targetPos.y = cam.transform.localPosition.y;
                var targetRot = new Vector3(89,0,0);

                initialCamPos = cam.transform.localPosition;
                initialCamRot = cam.transform.localRotation.eulerAngles;

                StartCoroutine(CamRotation(targetPos, targetRot));             
                camSensitivity = 0.01f;
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }

    IEnumerator CamRotation(Vector3 targetPos, Vector3 targetRot) {
        isRotating = true;

        var startingRot = cam.transform.localRotation.eulerAngles;
        var startingPos = cam.transform.localPosition;
        var movTime = 0.5f;
        var elapsedTime = 0f;

        while(elapsedTime < movTime) {
            var currentRot = Vector3.Lerp(startingRot,targetRot,elapsedTime/movTime);
            var currentPos = Vector3.Lerp(startingPos,targetPos,elapsedTime/movTime);

            cam.transform.localPosition = currentPos;
            cam.transform.localRotation = Quaternion.Euler(currentRot);
            
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        camX = targetRot.x;
        isRotating = false;
    }

    public void ChangeSensitivity() {
        newCamSensitivity = sensSlider.value;
    }

    public void LeaveMM() {
        inMainMenu = false;
    }

    public void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "EndTrigger" || other.gameObject.tag == "McdonaldsEnd" || other.gameObject.tag == "PoolEnd" || other.gameObject.tag == "HouseReturn" || other.gameObject.tag == "HellzoneEnd") {
            Cursor.lockState = CursorLockMode.None;            
            inMainMenu = true;
            isRotating = true;
            rb.velocity = Vector2.zero;
            moveInput = Vector2.zero;
        }
    }

    public void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Ground") {
            canJump = true;
        }
    }
}
