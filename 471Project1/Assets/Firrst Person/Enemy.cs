using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int health = 10;
    [SerializeField] GameObject explosionEffect;
    [SerializeField] AudioClip explosionSound;
    [SerializeField] EnemyController self;
    [SerializeField] float explosionRadius = 75f;
    [SerializeField] float explosionForce = 750f;

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Bullet>() != null)
        {
            self.TakeDamage(1);
            health -= 1;
            Destroy(other.gameObject);

            if (health <= 0)
            {
                Explode();
                Destroy(gameObject);
            }
        }
    }
    void Explode()
    {
        // Instantiate explosion effect
        if (explosionEffect != null)
        {
            GameObject explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(explosion, 2f);  // Deletes particle effect after 2 seconds
        }

        // Play explosion sound
        if (explosionSound != null)
        {
            AudioSource.PlayClipAtPoint(explosionSound, transform.position);
        }

        // Apply force to nearby objects
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius); // builds an array of colliders and stores all of the colliders within the given radius.
        foreach (Collider nearby in colliders)
        {
            Rigidbody rb = nearby.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce * rb.mass, transform.position, explosionRadius);
            }
        }
    }
}
