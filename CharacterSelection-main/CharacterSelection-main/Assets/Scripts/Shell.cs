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

        // Ensure Rigidbody exists and bullet moves forward
        if (rb != null)
        {
            rb.velocity = transform.forward * speed; // Move forward instantly
        }

        // Destroy bullet after lifetime to avoid memory leaks
        Destroy(gameObject, lifeTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Debug log when the bullet collides
        Debug.Log($"Bullet hit: {collision.gameObject.name}");

        if (collision.gameObject.CompareTag("Military"))
        {
            Debug.Log("Bullet hit Military");
            Destroy(collision.gameObject); // Destroy the Military object
        }

        // Destroy the bullet on any collision
        Destroy(gameObject);
    }
}
