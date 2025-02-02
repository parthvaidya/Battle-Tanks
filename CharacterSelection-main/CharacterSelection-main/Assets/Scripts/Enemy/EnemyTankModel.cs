using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankModel 
{
    private EnemyTankController tankController;
    public float movementSpeed;
    public float rotationSpeed;
    public int health;
    public EnemyTankTypes tankType;
    public Material color;

    public EnemyTankModel(float _movement, float _rotation, int _health, EnemyTankTypes _type, Material _color)
    {
        movementSpeed = _movement;
        rotationSpeed = _rotation;
        health = _health;
        tankType = _type;
        color = _color;
    }

    public void SetTankController(EnemyTankController _tankController)
    {
        tankController = _tankController;
    }
}
