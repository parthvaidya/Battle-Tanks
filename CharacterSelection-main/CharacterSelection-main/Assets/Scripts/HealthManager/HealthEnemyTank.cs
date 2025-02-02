using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEnemyTank : MonoBehaviour
{
    public static HealthEnemyTank Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(EnemyTankView enemyTank, int damage)
    {
        if (enemyTank == null) return;

        enemyTank.health -= damage;
        Debug.Log($"{enemyTank.name} took {damage} damage. Remaining Health: {enemyTank.health}");

        if (enemyTank.health <= 0)
        {
            DestroyTank(enemyTank);
        }
    }

    private void DestroyTank(EnemyTankView enemyTank)
    {
        Debug.Log($"{enemyTank.name} destroyed!");
        Destroy(enemyTank.gameObject);
    }
}
