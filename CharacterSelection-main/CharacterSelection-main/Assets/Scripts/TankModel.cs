using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel 
{
    private TankController tankController;
    public float movementSpeed;
    public float rotationSpeed;
    public TankTypes tankTypes;
    public Material color;

    public TankModel(float _movement, float _rotation , TankTypes tank, Material _color)
    {
        movementSpeed = _movement;
        rotationSpeed = _rotation;
        tankTypes = tank;
        color = _color;
    }

    public void SetTankController(TankController _tankController)
    {
        tankController = _tankController;
    }
}
