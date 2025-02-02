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
    // Start is called before the first frame update
    //change test

    public Transform firePoint; 
    public GameObject shellPrefab;
    [SerializeField] public TextMeshProUGUI healthText;

    void Start()
    {
        GameObject cam = GameObject.Find("Main Camera");
        cam.transform.SetParent(transform);
        cam.transform.position = new Vector3(0f, 3f, -6.5f);
        if (HealthManagerTank.Instance != null && healthText != null)
        {
            HealthManagerTank.Instance.healthText = healthText; // Assign UI reference
        }
    }

    // Update is called once per frame
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            tankController.Fire();
        }
    }

    private void Movement()
    {
        movement = Input.GetAxis("Vertical");
        rotation = Input.GetAxis("Horizontal");
    }

    public void SetTankController(TankController _tankController)
    {
        tankController = _tankController;
        //UpdateHealthUI();

    }

    public Rigidbody GetRigidbody() { return rb; }

    public void ChangeColor(Material color)
    {
        for(int i = 0; i< childs.Length; i++)
        {
            childs[i].material = color;
        }
    }

    //public void UpdateHealthUI()
    //{
    //    if (healthText != null)
    //    {
    //        healthText.text = "Health: " + tankController.GetTankModel().health;
    //    }
    //    else
    //    {
    //        Debug.LogWarning("Health UI Text is not assigned in the inspector!");
    //    }
    //}
}
