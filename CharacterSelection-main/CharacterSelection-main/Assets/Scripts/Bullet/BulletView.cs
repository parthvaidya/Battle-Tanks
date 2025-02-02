using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletView : MonoBehaviour
{
    private BulletController bulletController;
    private Rigidbody rb;
    private bool isInitialized = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        if (!isInitialized)
        {
            Debug.LogError("BulletView was not properly initialized! Call Initialize() after instantiation.");
            return;
        }

        rb.velocity = transform.forward * bulletController.GetBulletModel().speed;
        Destroy(gameObject, 5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isInitialized)
        {
            Debug.LogError("BulletView was not properly initialized!");
            return;
        }

        bulletController.OnImpact(collision);
    }

    public void Initialize(BulletController controller)
    {
        if (controller == null)
        {
            Debug.LogError("Attempted to initialize BulletView with null controller!");
            return;
        }

        bulletController = controller;
        isInitialized = true;
    }
}
