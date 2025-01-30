using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSpawner : MonoBehaviour
{
    [System.Serializable]
    public class Tank
    {
        public float movementSpeed;
        public float rotationSpeed;
        public TankTypes tankTypes;
        public Material color;
    }
    public List<Tank> tankList;
    
    public TankView tankView;

    void Start()
    {
        CreateTank();
    }

    private void CreateTank()
    {
        TankModel tankModel = new TankModel(tankList[2].movementSpeed , tankList[2].rotationSpeed, tankList[2].tankTypes , tankList[2].color);
        TankController tankController = new TankController(tankModel, tankView);
    }
}
