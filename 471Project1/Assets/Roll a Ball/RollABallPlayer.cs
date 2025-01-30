using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class RollABallPlayer : MonoBehaviour
{
    Vector2 m;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        m = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float x_dir = m.x; 
        float z_dir = m.y;
        Vector3 actualMovement = new Vector3(x_dir, 0, z_dir);
        print(actualMovement);
        rb.AddForce(actualMovement);
    }

    void OnMove(InputValue movement)
    {
        m = movement.Get<Vector2>(); 
    }
}
