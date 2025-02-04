using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletView : MonoBehaviour
{
    private BulletController bulletController; //call controller to connect
    private Rigidbody rb;
    private bool isInitialized = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); //find component
    }

    private void Start()
    {
        if (!isInitialized)
        {
            Debug.LogError("BulletView was not properly initialized! Call Initialize() after instantiation.");
            return;
        }

        rb.velocity = transform.forward * bulletController.GetBulletModel().speed; //give initial speed to bullet
        Destroy(gameObject, 5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isInitialized)
        {
            Debug.LogError("BulletView was not properly initialized!");
            return;
        }

        bulletController.OnImpact(collision); //on impact
    }

    public void Initialize(BulletController controller)
    {
        if (controller == null)
        {
            Debug.LogError("Attempted to initialize BulletView with null controller!");
            return;
        }

        bulletController = controller; //set the controller
        isInitialized = true; //yes initialized
    }
}
