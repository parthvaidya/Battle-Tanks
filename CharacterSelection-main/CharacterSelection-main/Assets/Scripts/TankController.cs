using System.Collections;
using System.Collections.Generic;
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

        
    }

    public void Move(float movement, float movementSpeed)
    {
        rb.velocity = tankView.transform.forward * movement * movementSpeed;
    }

    public void Rotate(float rotate , float rotateSpeed)
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
            GameObject shellInstance = GameObject.Instantiate(tankView.shellPrefab, tankView.firePoint.position, tankView.firePoint.rotation);
            Rigidbody shellRb = shellInstance.GetComponent<Rigidbody>();

            if (shellRb != null)
            {
                shellRb.velocity = tankView.firePoint.forward * 20f; // Adjust bullet speed
            }
        }
    }

}
