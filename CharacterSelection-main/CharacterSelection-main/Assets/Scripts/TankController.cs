using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TankController 
{


    private TankModel tankModel;
    private TankView tankView;

    private Rigidbody rb;

    public TankController(TankModel _tankModel, TankView _tankView)
    {
        tankModel = _tankModel;
        tankView = GameObject.Instantiate<TankView>(_tankView);
        rb = tankView.GetRigidbody();
        tankModel.SetTankController(this);
        tankView.SetTankController(this);
        tankView.ChangeColor(tankModel.color);

        //UpdateHealthUI();
    }

    public void Move(float movement, float movementSpeed)
    {
        rb.velocity = tankView.transform.forward * movement * movementSpeed;
    }

    public void Rotate(float rotate, float rotateSpeed)
    {
        Vector3 vector = new Vector3(0f, rotate * rotateSpeed, 0f);
        Quaternion deltaRotation = Quaternion.Euler(vector * Time.deltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }

    public TankModel GetTankModel()
    {
        return tankModel;
    }

    public void Fire()
    {
        if (tankView.shellPrefab != null && tankView.firePoint != null)
        {
            BulletModel bulletModel = GetBulletModelForTank(tankModel.tankTypes);
            BulletController bulletController = new BulletController(
                bulletModel,
                tankView.shellPrefab.GetComponent<BulletView>(),
                tankView.firePoint.position,
                tankView.firePoint.rotation
            );
        }
    }

    //public void TakeDamage(int amount)
    //{
    //    tankModel.health -= amount;
    //    UpdateHealthUI();

    //    if (tankModel.health <= 0)
    //    {
    //        Debug.Log($"{tankModel.tankTypes} tank destroyed!");
    //    }
    //}

    //private void UpdateHealthUI()
    //{
    //    if (tankView != null)
    //    {
    //        tankView.UpdateHealthUI();
    //    }
    //}
    private BulletModel GetBulletModelForTank(TankTypes tankType)
    {
        switch (tankType)
        {
            case TankTypes.GreenTank:
                return new BulletModel(15f, 30f, BulletTypes.HighExplosive); // Area-of-effect damage
            case TankTypes.BlueTank:
                return new BulletModel(10f, 50f, BulletTypes.GuidedMissile); // Slow, accurate, high damage
            case TankTypes.RedTank:
                return new BulletModel(25f, 20f, BulletTypes.ArmorPiercing); // Fast, linear bullets
            default:
                return new BulletModel(15f, 25f, BulletTypes.HighExplosive); // Default fallback
        }
    }

    //public void Fire()
    //{
    //    if (tankView.shellPrefab != null && tankView.firePoint != null)
    //    {
    //        GameObject shellInstance = GameObject.Instantiate(tankView.shellPrefab, tankView.firePoint.position, tankView.firePoint.rotation);
    //        Rigidbody shellRb = shellInstance.GetComponent<Rigidbody>();

    //        if (shellRb != null)
    //        {
    //            shellRb.velocity = tankView.firePoint.forward * 20f; // Adjust bullet speed
    //        }
    //    }
    //}

}
