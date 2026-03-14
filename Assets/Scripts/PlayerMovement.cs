using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public enum PlayerState
{
    Normal, //Sprinting
    Walk,
    Crouch
}

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float maxSpeed = 10f;
    public float acceleration = 1f;
    public float airMultiplier = 0.5f;
    public float deceleration = 1f;
    public float jumpForce = 5f;
    public float crouchSpeedMultiplier = 0.5f;
    public float walkSpeedMultiplier = 0.7f;
    public float maxSlope = 50f;
    private PlayerState currentState = PlayerState.Normal;
    private bool isWalkingInput = false;
    private bool isCrouchingInput = false;
    private float moveX, moveY;

    [Header("Capsule Settings")]
    public float crouchHeightMultiplier = 0.6f;
    public float capsuleResizeSpeed = 10f;
    public float cameraCrouchOffset = 0.4f;

    private Vector3 capsuleCenterOriginal;
    private Vector3 cameraOriginalLocalPos;

    [Header("Camera Settings")]
    public float sensitivity = 1f;
    public int FOV = 70;
    public Transform playerCameraTransform;
    public Camera playerCamera;
    private float mouseX, mouseY;
    private float xRotation;


    private CapsuleCollider playerCapsule;
    private float playerCapsuleHeight;
    private Rigidbody rb;
    private bool isGrounded()
    {
        RaycastHit hit;
        Vector3 origin = playerCapsule.transform.position;
        float rayDistance = (currentState == PlayerState.Crouch) ? 0.3f : 0.1f;
        Debug.DrawRay(origin, Vector3.down * (playerCapsule.height/4 + rayDistance), Color.red);
        if(Physics.SphereCast(origin, playerCapsule.radius*0.9f, Vector3.down, out hit, playerCapsule.height/4 + rayDistance))
        {
            return true;
        }
        return false;
    }
    private void OnLook(InputValue value)
    {
        Vector2 rotateInput = value.Get<Vector2>();
        mouseX = rotateInput.x;
        mouseY = rotateInput.y;
    }
    private float getMovespeedMultiplier()
    {
        switch(currentState)
        {
            case PlayerState.Crouch: return crouchSpeedMultiplier;
            case PlayerState.Walk: return walkSpeedMultiplier;
            default: return 1f;
        }
    }
    private void OnCrouch(InputValue value)
    {
        isCrouchingInput = value.isPressed;
    }
    private void OnWalk(InputValue value)
    {
        isWalkingInput = value.isPressed;
    }
    private void OnMove(InputValue value)
    {
        Vector2 move = value.Get<Vector2>();
        moveX = move.x;
        moveY = move.y;
    }
    private void setState()
    {
        if(isCrouchingInput) currentState = PlayerState.Crouch;
        else if(isWalkingInput) currentState = PlayerState.Walk;
        else currentState = PlayerState.Normal;
    }

    void Start()
    {
        playerCapsule = GetComponent<CapsuleCollider>();
        rb = GetComponent<Rigidbody>();

        playerCamera.fieldOfView = FOV;

        playerCapsuleHeight = playerCapsule.height;
        capsuleCenterOriginal = playerCapsule.center;

        cameraOriginalLocalPos = playerCameraTransform.localPosition;

        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        //Camera
        xRotation -= mouseY * sensitivity * Time.fixedDeltaTime;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        playerCameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX * sensitivity * Time.fixedDeltaTime);
        setState();
        Debug.Log($"Grounded: {isGrounded()}");
    }
    void FixedUpdate()
    {
        float targetHeight = playerCapsuleHeight;
        switch(currentState)
        {
            case PlayerState.Crouch:
                targetHeight = playerCapsuleHeight * crouchHeightMultiplier;
                break;

            case PlayerState.Walk:
            case PlayerState.Normal:
                targetHeight = playerCapsuleHeight;
                break;
        }

        float newHeight = Mathf.Lerp(playerCapsule.height, targetHeight, Time.fixedDeltaTime * capsuleResizeSpeed);
        playerCapsule.height = newHeight;

        float heightDifference = playerCapsuleHeight - newHeight;
        playerCapsule.center = capsuleCenterOriginal - new Vector3(0, heightDifference / 2f, 0);

        float targetCameraOffset = (currentState == PlayerState.Crouch) ? -cameraCrouchOffset : 0f;
        Vector3 targetCameraPos = cameraOriginalLocalPos + new Vector3(0, targetCameraOffset, 0);

        playerCameraTransform.localPosition = Vector3.Lerp(
            playerCameraTransform.localPosition,
            targetCameraPos,
            Time.fixedDeltaTime * capsuleResizeSpeed
        );

        float targetFov = (currentState == PlayerState.Crouch || currentState == PlayerState.Walk) ? FOV * 0.98f : FOV;
        playerCamera.fieldOfView = Mathf.Lerp(playerCamera.fieldOfView, targetFov, Time.fixedDeltaTime * 3.5f);

        //Movement
        
    }
}
