using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    public float speed = 50f;  // Speed of the bullet
    public float lifeTime = 3f; // Bullet disappears after X seconds

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Ensure the Rigidbody exists
        if (rb != null)
        {
            rb.velocity = transform.forward * speed; // Move forward instantly
        }

        // Destroy bullet after a certain time to avoid memory leaks
        Destroy(gameObject, lifeTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Play an impact effect (if needed)
        Debug.Log("Bullet hit: " + collision.gameObject.name);

        // Destroy the bullet on any collision
        Destroy(gameObject);
    }
}
