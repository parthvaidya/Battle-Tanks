using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel 
{
    //connect TankController to the Model
    private TankController tankController;
    public float movementSpeed;
    public float rotationSpeed;
    public TankTypes tankTypes;
    public Material color;
    public int health;

    //create the constructor of TankModel based on attributes
    public TankModel(float _movement, float _rotation , TankTypes tank, Material _color , int _health)
    {
        movementSpeed = _movement;
        rotationSpeed = _rotation;
        tankTypes = tank;
        color = _color;
        health = _health;
    }


    //set the tank controller to connect model and controller

    public void SetTankController(TankController _tankController)
    {
        tankController = _tankController;
    }
}
