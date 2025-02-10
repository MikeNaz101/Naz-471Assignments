using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] AudioClip pewSound;
    Rigidbody rb;
    [SerializeField] float speed = 10f;
    [SerializeField] float lifetime = 1f;

    void Start()
    {
        AudioSource.PlayClipAtPoint(pewSound, transform.position);
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * speed, ForceMode.VelocityChange);
        Destroy(gameObject, lifetime);
    }
}
