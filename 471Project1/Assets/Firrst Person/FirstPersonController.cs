using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonController : MonoBehaviour
{
    [SerializeField] float speed = 2.0f;
    [SerializeField] float mouseSensitivity = 100f;
    [SerializeField] GameObject cam;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject bulletSpawner;

    Vector2 movement;
    Vector2 mouseMovement;
    CharacterController chara;
    float cameraUpRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        chara = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Camera rotation
        float mouseX = mouseMovement.x * Time.deltaTime * mouseSensitivity / 10;
        float mouseY = mouseMovement.y * Time.deltaTime * mouseSensitivity / 10;

        cameraUpRotation -= mouseY;
        cameraUpRotation = Mathf.Clamp(cameraUpRotation, -90f, 90f);

        cam.transform.localRotation = Quaternion.Euler(cameraUpRotation, 0, 0);
        transform.Rotate(Vector3.up * mouseX);

        // Movement
        Vector3 move = transform.right * movement.x + transform.forward * movement.y;
        //Vector3 actual_movement = transform.right * movement.x + transform.forward * movement.y;
        chara.SimpleMove(move * speed);

        
    }

    void OnMove(InputValue moveVal)
    {
        movement = moveVal.Get<Vector2>();
    }

    void OnLook(InputValue lookVal)
    {
        mouseMovement = lookVal.Get<Vector2>();
    }

    void OnAttack(InputValue fireVal)
    {
        GameObject newBullet = Instantiate(bullet, bulletSpawner.transform.position, bulletSpawner.transform.rotation);
        Rigidbody rb = newBullet.GetComponent<Rigidbody>();
        rb.AddForce(bulletSpawner.transform.forward * 20f, ForceMode.Impulse);
    }
}
