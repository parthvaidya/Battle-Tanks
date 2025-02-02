using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankController
{
    //private EnemyTankModel tankModel;
    //private EnemyTankView tankView;
    //private Rigidbody rb;

    //public EnemyTankController(EnemyTankModel _tankModel, EnemyTankView _tankView)
    //{
    //    tankModel = _tankModel;
    //    //tankView = GameObject.Instantiate<EnemyTankView>(_tankView);
    //    rb = tankView.GetRigidbody();

    //    tankModel.SetTankController(this);
    //    tankView.SetTankController(this);
    //    tankView.ChangeColor(tankModel.color);
    //}

    //public void Move(Vector3 direction, float speed)
    //{
    //    rb.velocity = direction.normalized * speed;
    //}

    //public void Fire()
    //{
    //    if (tankView.shellPrefab != null && tankView.firePoint != null)
    //    {
    //        BulletModel bulletModel = GetBulletModelForTank(tankModel.tankType);
    //        BulletController bulletController = new BulletController(
    //            bulletModel,
    //            tankView.shellPrefab.GetComponent<BulletView>(),
    //            tankView.firePoint.position,
    //            tankView.firePoint.rotation
    //        );
    //    }
    //}

    //private BulletModel GetBulletModelForTank(EnemyTankTypes enemyTankTypes)
    //{
    //    switch (enemyTankTypes)
    //    {
    //        case EnemyTankTypes.Artillery:
    //            return new BulletModel(15f, 30f, BulletTypes.Artillery); // Area-of-effect damage
    //        case EnemyTankTypes.HeavyAssault:
    //            return new BulletModel(10f, 50f, BulletTypes.HeavyAssault); // Slow, accurate, high damage
    //        case EnemyTankTypes.Scout:
    //            return new BulletModel(25f, 20f, BulletTypes.Scout); // Fast, linear bullets
    //        default:
    //            return new BulletModel(15f, 25f, BulletTypes.Artillery); // Default fallback
    //    }
    //}

    //public EnemyTankModel GetTankModel()
    //{
    //    return tankModel;
    //}

    private EnemyTankModel tankModel;
    private EnemyTankView tankView;
    private Rigidbody rb;

    public EnemyTankController(EnemyTankModel tankModel, EnemyTankView tankView , Transform player)
    {
        this.tankModel = tankModel;
        this.tankView = tankView;
        this.rb = tankView.GetRigidbody();

        this.tankModel.SetTankController(this);
        this.tankView.SetTankController(this , player) ;
        this.tankView.ChangeColor(this.tankModel.color);
    }

    public void Move(Vector3 direction, float speed)
    {
        rb.velocity = direction.normalized * speed;
    }

    public void Fire()
    {
        if (tankView.shellPrefab != null && tankView.firePoint != null)
        {
            BulletModel bulletModel = GetBulletModelForTank(tankModel.tankType);
            BulletController bulletController = new BulletController(
                bulletModel,
                tankView.shellPrefab.GetComponent<BulletView>(),
                tankView.firePoint.position,
                tankView.firePoint.rotation
            );
        }
    }

    private BulletModel GetBulletModelForTank(EnemyTankTypes enemyTankTypes)
    {
        switch (enemyTankTypes)
        {
            case EnemyTankTypes.Artillery:
                return new BulletModel(15f, 30f, BulletTypes.Artillery);
            case EnemyTankTypes.HeavyAssault:
                return new BulletModel(10f, 50f, BulletTypes.HeavyAssault);
            case EnemyTankTypes.Scout:
                return new BulletModel(25f, 20f, BulletTypes.Scout);
            default:
                return new BulletModel(15f, 25f, BulletTypes.Artillery);
        }
    }

    public EnemyTankModel GetTankModel()
    {
        return tankModel;
    }
}
