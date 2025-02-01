using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class RollABallPlayer : MonoBehaviour
{
    public float jumpForce = 500;
    bool isGrounded;
    bool isNearGround;
    Vector2 m;
    Rigidbody rb;
    public Transform cameraPos;
    public float speed = 10f; 
    public float maxSpeed = 50f;
    public float groundCheckDistance = 0.1f;
    public float nearGroundDistance = 0.75f;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        m = new Vector2(0, 0);
    }
    
    void FixedUpdate()
    {
        MoveBallRelativeToCamera();

        /*
        Vector3 movement = new Vector3(m.x, 0, m.y) * speed;

        // Apply force with VelocityChange mode for more responsive movement
        rb.AddForce(movement, ForceMode.VelocityChange);

        // Limit maximum velocity
        if (rb.linearVelocity.magnitude > maxSpeed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfGrounded();

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce);
        }
        /*float x_dir = m.x; 
        float z_dir = m.y;
        Vector3 actualMovement = new Vector3(x_dir, 0, z_dir);
        print(actualMovement);
        rb.AddForce(actualMovement);*/
    }
    void MoveBallRelativeToCamera()
    {
        if (cameraPos == null) return; // Ensure the camera is assigned

        // Get camera's forward and right directions (ignore Y so movement is flat)
        Vector3 cameraForward = cameraPos.forward;
        Vector3 cameraRight = cameraPos.right;
        cameraForward.y = 0;
        cameraRight.y = 0;
        cameraForward.Normalize();
        cameraRight.Normalize();

        // Convert input into world direction
        Vector3 moveDirection = (cameraForward * m.y + cameraRight * m.x).normalized;

        // Apply force in that direction
        rb.AddForce(moveDirection * speed, ForceMode.VelocityChange);

        // Limit max speed for better control
        if (rb.linearVelocity.magnitude > maxSpeed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }
    }

    void OnMove(InputValue movement)
    {
        m = movement.Get<Vector2>(); 
    }

    void CheckIfGrounded()
    {
        // Replace this with your actual ground check logic
        //isGrounded = true;
        // Ground check
        Vector3 spherePosition = transform.position + Vector3.down * groundCheckDistance;
        isGrounded = Physics.SphereCast(spherePosition, 0.1f, Vector3.down, out RaycastHit hitInfo, groundCheckDistance);

        // Near ground check
        spherePosition = transform.position + Vector3.down * nearGroundDistance;
        isNearGround = Physics.SphereCast(spherePosition, 0.1f, Vector3.down, out hitInfo, nearGroundDistance);
    }
}
