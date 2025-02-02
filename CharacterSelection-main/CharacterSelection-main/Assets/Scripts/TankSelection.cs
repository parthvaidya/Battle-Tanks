using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSelection : MonoBehaviour
{

    public TankSpawner tankSpawner;
   public void BlueTank()
    {
        tankSpawner.CreateTank(TankTypes.BlueTank);
        SoundManager.Instance.Play(Sounds.ButtonClick);
        this.gameObject.SetActive(false);
    }


    public void RedTank()
    {
        tankSpawner.CreateTank(TankTypes.RedTank);
        SoundManager.Instance.Play(Sounds.ButtonClick);
        this.gameObject.SetActive(false);
    }

    public void GreenTank()
    {
        tankSpawner.CreateTank(TankTypes.GreenTank);
        SoundManager.Instance.Play(Sounds.ButtonClick);
        this.gameObject.SetActive(false);
    }
}
