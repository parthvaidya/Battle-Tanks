using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthEnemyTank : MonoBehaviour
{
    public static HealthEnemyTank Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI[] enemyHealthTexts; // Assign in Inspector

    private List<EnemyTankView> enemyTanks = new List<EnemyTankView>();

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

    public void RegisterTank(EnemyTankView enemyTank)
    {
        if (!enemyTanks.Contains(enemyTank))
        {
            enemyTanks.Add(enemyTank);
            UpdateHealthUI();
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

        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        // **Remove destroyed tanks from the list**
        enemyTanks.RemoveAll(tank => tank == null || tank.gameObject == null);

        // **Update health UI only for remaining tanks**
        for (int i = 0; i < enemyHealthTexts.Length; i++)
        {
            if (i < enemyTanks.Count)
            {
                enemyHealthTexts[i].text = $"{enemyTanks[i].name}: {enemyTanks[i].health} HP";
            }
            else
            {
                enemyHealthTexts[i].text = ""; 
            }
        }
    }

    private void DestroyTank(EnemyTankView enemyTank)
    {
        Debug.Log($"{enemyTank.name} destroyed!");
        enemyTanks.Remove(enemyTank);  // **Remove tank from list before destroying**
        Destroy(enemyTank.gameObject);
        UpdateHealthUI(); // Refresh UI after destruction
        if (enemyTanks.Count == 0)
        {
            Debug.Log("All enemy tanks destroyed! ");
            SceneManager.LoadScene(2);
        }
    }
}
