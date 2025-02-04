using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSelection : MonoBehaviour
{
    //create tank in the spawner
    public TankSpawner tankSpawner;
   public void BlueTank() 
    {
        tankSpawner.CreateTank(TankTypes.BlueTank); //create tank based on the tanktype
        SoundManager.Instance.Play(Sounds.ButtonClick);
        this.gameObject.SetActive(false); //set screen inactive after clicking tank
    }


    public void RedTank() //create tank red
    {
        tankSpawner.CreateTank(TankTypes.RedTank);
        SoundManager.Instance.Play(Sounds.ButtonClick);
        this.gameObject.SetActive(false);
    }

    public void GreenTank() //create tank blue
    {
        tankSpawner.CreateTank(TankTypes.GreenTank);
        SoundManager.Instance.Play(Sounds.ButtonClick);
        this.gameObject.SetActive(false);
    }
}
