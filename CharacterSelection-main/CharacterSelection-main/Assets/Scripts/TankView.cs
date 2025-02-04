using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TankView : MonoBehaviour
{
    
    private TankController tankController;
    private float movement;
    private float rotation;

    public Rigidbody rb;
    public MeshRenderer[] childs;
    

    public Transform firePoint; 
    public GameObject shellPrefab;
    [SerializeField] public TextMeshProUGUI healthText;


    //camera follows the player 
    void Start()
    {
        GameObject cam = GameObject.Find("Main Camera");
        cam.transform.SetParent(transform);
        cam.transform.position = new Vector3(0f, 3f, -6.5f);
        if (HealthManagerTank.Instance != null && healthText != null)
        {
            HealthManagerTank.Instance.healthText = healthText; //give health text for updating the textmeshpro
        }
    }

    
    //for movement and physics
    void Update()
    {
        Movement();

        if( movement != 0 )
        {
            tankController.Move(movement, tankController.GetTankModel().movementSpeed);
        }

        if(rotation != 0)
        {
            tankController.Rotate(rotation, tankController.GetTankModel().rotationSpeed);
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            tankController.Fire();
        }
    }


    //movement logic
    private void Movement()
    {
        movement = Input.GetAxis("Vertical");
        rotation = Input.GetAxis("Horizontal");
    }


    //connect view and tankcontroller
    public void SetTankController(TankController _tankController)
    {
        tankController = _tankController;
        

    }

    public Rigidbody GetRigidbody() { return rb; } //get tank physics for the body


    //change color for each tanks
    public void ChangeColor(Material color)
    {
        for(int i = 0; i< childs.Length; i++)
        {
            childs[i].material = color;
        }
    }

    
}
