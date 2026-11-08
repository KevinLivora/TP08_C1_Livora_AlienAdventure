using System;
using UnityEngine;

[RequireComponent(typeof(PlayerPowerUps))]
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private PlayerDataSo data;

    private PlayerPowerUps powerUps;
    private int currentHealth;
    private int knownMaxHealth;

    public int CurrentHealth => currentHealth;

    public event Action<int, int> HealthChanged;
    public event Action Died;

    private void Awake()
    {
        powerUps = GetComponent<PlayerPowerUps>();
        knownMaxHealth = data.TotalMaxHealth;
        currentHealth = RunState.TakeHealth(knownMaxHealth);
    }

    private void Start()
    {
        HealthChanged?.Invoke(currentHealth, data.TotalMaxHealth);
    }

    public void TakeDamage(int amount)
    {
        if (currentHealth <= 0 || powerUps.IsProtected)
            return;

        currentHealth = Mathf.Max(currentHealth - amount, 0);
        HealthChanged?.Invoke(currentHealth, data.TotalMaxHealth);

        if (currentHealth == 0)
        {
            Died?.Invoke();
            return;
        }

        powerUps.ActivateHitProtection();
        AudioManager.Instance.PlayLifeLost();
    }

    public void Heal(int amount)
    {
        if (currentHealth <= 0)
            return;

        currentHealth = Mathf.Min(currentHealth + amount, data.TotalMaxHealth);
        HealthChanged?.Invoke(currentHealth, data.TotalMaxHealth);
    }

    public void RefreshMaxHealth()
    {
        if (currentHealth <= 0)
            return;

        int newMax = data.TotalMaxHealth;
        currentHealth += newMax - knownMaxHealth;
        knownMaxHealth = newMax;
        HealthChanged?.Invoke(currentHealth, newMax);
    }
}
