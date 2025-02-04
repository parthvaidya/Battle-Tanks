using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController 
{

    //call view and model
    private BulletModel bulletModel;
    private BulletView bulletView;


    //connect the model and view , spawn position and rotation
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

        bulletModel = model; //initalize model
        bulletView = GameObject.Instantiate(viewPrefab, spawnPosition, spawnRotation); //instantiate the bullet
        bulletView.Initialize(this); //initialize this component
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
            
        }

        else if(collision.gameObject.CompareTag("Military"))
        {
            //SoundManager.Instance.Play(Sounds.EnemyDeath);
        }

        else  if(collision.gameObject.CompareTag("Player"))
        {
            HealthManagerTank.Instance.TakeDamage(10);
        }

        GameObject.Destroy(bulletView.gameObject);
    }
}
