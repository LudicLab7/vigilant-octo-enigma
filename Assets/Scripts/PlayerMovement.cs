using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float maxSpeed = 10f;
    public float acceleration = 1f;
    public float airMultiplier = 0.5f;
    public float deceleration = 1f;
    public float jumpForce = 5f;
    public float crouchSpeedMultiplier = 0.5f;
    public float sprintSpeedMultiplier = 2f;
    public float maxSlope = 50f;

    [Header("Camera Settings")]
    public float sensitivity = 1f;
    public int FOV = 70;
    public Camera playerCamera;


    private CapsuleCollider playerCapsule;
    void Start()
    {
        playerCapsule = GetComponent<CapsuleCollider>();
        playerCamera.fieldOfView = FOV;
    }

    void Update()
    {
        
    }

    private bool isGrounded()
    {
        RaycastHit hit;
        Vector3 origin = playerCapsule.transform.position;
        float rayDistance = 0.1f;
        Debug.DrawRay(origin, Vector3.down * (playerCapsule.height/4 + rayDistance), Color.red);
        if(Physics.SphereCast(origin, playerCapsule.radius*0.9f, Vector3.down, out hit, playerCapsule.height/4 + rayDistance))
        {
            return true;
        }
        return false;
    }
}
