using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankView : MonoBehaviour
{
    private EnemyTankController tankController;

    [Header("Tank Attributes")]
    public float movementSpeed = 5f;
    public float rotationSpeed = 50f;
    public int health = 100;

    [Header("References")]
    public Rigidbody rb;
    public MeshRenderer[] childs;
    public Transform firePoint;
    public GameObject shellPrefab;

    private float moveTimer;
    private float moveDuration = 2f;
    private Vector3 randomDirection;

    [Header("Targeting")]
    [SerializeField] private Transform player; // Player assigned manually in Inspector
    public LayerMask playerLayer; // Layer Mask for detecting only the player

    [Header("Shooting Settings")]
    public float shootingRange = 20f;
    public float fireCooldown = 2f;
    private float fireTimer = 0f;

    void Start()
    {
        moveTimer = moveDuration;
        fireTimer = fireCooldown;

        Debug.Log($"{gameObject.name} spawned with {health} HP.");
    }

    void Update()
    {
        if (tankController == null || player == null) return;

        HandleMovement();
        HandleShooting();
    }

    void HandleMovement()
    {
        if (player == null) return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= shootingRange && IsPlayerVisible())
        {
            Vector3 directionToPlayer = (player.position - transform.position).normalized;
            tankController.Move(directionToPlayer, movementSpeed);
            RotateTowards(player.position);
        }
        else
        {
            MoveRandomly();
        }
    }

    bool IsPlayerVisible()
    {
        RaycastHit hit;
        if (Physics.Linecast(transform.position, player.position, out hit, playerLayer))
        {
            return hit.collider.CompareTag("Player"); // Ensure it's actually the player
        }
        return false;
    }

    void RotateTowards(Vector3 targetPosition)
    {
        Vector3 direction = (targetPosition - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }

    void MoveRandomly()
    {
        moveTimer -= Time.deltaTime;
        if (moveTimer <= 0)
        {
            moveTimer = moveDuration;
            randomDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
        }

        tankController.Move(randomDirection, movementSpeed);
    }

    void HandleShooting()
    {
        if (player == null) return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        fireTimer -= Time.deltaTime;

        if (distanceToPlayer <= shootingRange && fireTimer <= 0 && IsPlayerVisible())
        {
            tankController.Fire();
            fireTimer = fireCooldown;
        }
    }

    public void SetTankController(EnemyTankController _tankController, Transform _player)
    {
        tankController = _tankController;
        player = _player; // Assign player reference when enemy tank is created
    }

    public Rigidbody GetRigidbody()
    {
        return rb;
    }

    public void ChangeColor(Material color)
    {
        foreach (var child in childs)
        {
            child.material = color;
        }
    }
}
