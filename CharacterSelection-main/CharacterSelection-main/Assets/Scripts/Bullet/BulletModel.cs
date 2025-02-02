using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletModel 
{
    public float speed { get; private set; }
    public float damage { get; private set; }
    public BulletTypes bulletType { get; private set; }

    public BulletModel(float speed, float damage, BulletTypes bulletType)
    {
        this.speed = speed;
        this.damage = damage;
        this.bulletType = bulletType;
    }
}
