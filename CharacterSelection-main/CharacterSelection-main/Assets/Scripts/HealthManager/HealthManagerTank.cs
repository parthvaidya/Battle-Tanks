using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HealthManagerTank : MonoBehaviour
{
    public static HealthManagerTank Instance { get; private set; }

    public int maxHealth = 100;
    private int currentHealth;

    [SerializeField] public TextMeshProUGUI healthText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Max(0, currentHealth); // Prevent health from going below 0
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Debug.Log("Tank Destroyed!");
            SoundManager.Instance.Play(Sounds.EnemyDeath);
            SceneManager.LoadScene(2);
            // You can trigger an explosion, destroy the tank, or handle game over here.
        }
    }

    private void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = "Player: " + currentHealth;
        }
        else
        {
            Debug.LogWarning("Health UI TextMeshPro is not assigned in the inspector!");
        }
    }
}
