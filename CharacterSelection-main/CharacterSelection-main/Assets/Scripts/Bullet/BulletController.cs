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

        if (collision.gameObject.CompareTag("Enemy") )
        {
            if (HealthEnemyTank.Instance == null)
            {
                Debug.LogError("HealthEnemyTank.Instance is null! Make sure there's a GameObject with HealthEnemyTank component in the scene.");
                return;
            }
            EnemyTankView enemyTank = collision.gameObject.GetComponent<EnemyTankView>();
            if (enemyTank != null)
            {
                HealthEnemyTank.Instance.TakeDamage(enemyTank, 10);
            }
            Debug.Log($"Bullet hit: {collision.gameObject.name}");
            //HealthManagerTank.Instance.TakeDamage(10);
            // Here you might want to apply damage to the hit object
            // var hitObject = collision.gameObject.GetComponent<IDamageable>();
            // if (hitObject != null) hitObject.TakeDamage(bulletModel.damage);
        }

        else if(collision.gameObject.CompareTag("Military"))
        {

        }

        else  if(collision.gameObject.CompareTag("Player"))
        {
            HealthManagerTank.Instance.TakeDamage(10);
        }

        GameObject.Destroy(bulletView.gameObject);
    }
}
