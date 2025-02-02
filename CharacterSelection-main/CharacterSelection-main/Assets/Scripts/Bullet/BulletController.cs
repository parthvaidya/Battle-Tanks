using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController 
{
    private BulletModel bulletModel;
    private BulletView bulletView;

    public BulletController(BulletModel model, BulletView viewPrefab, Vector3 spawnPosition, Quaternion spawnRotation)
    {
        if (model == null)
        {
            Debug.LogError("Attempted to create BulletController with null model!");
            return;
        }

        if (viewPrefab == null)
        {
            Debug.LogError("Attempted to create BulletController with null view prefab!");
            return;
        }

        bulletModel = model;
        bulletView = GameObject.Instantiate(viewPrefab, spawnPosition, spawnRotation);
        bulletView.Initialize(this);
    }

    public BulletModel GetBulletModel()
    {
        return bulletModel;
    }

    public void OnImpact(Collision collision)
    {
        if (collision == null) return;

        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Military") || collision.gameObject.CompareTag("Player"))
        {
            Debug.Log($"Bullet hit: {collision.gameObject.name}");
            // Here you might want to apply damage to the hit object
            // var hitObject = collision.gameObject.GetComponent<IDamageable>();
            // if (hitObject != null) hitObject.TakeDamage(bulletModel.damage);
        }

        GameObject.Destroy(bulletView.gameObject);
    }
}
