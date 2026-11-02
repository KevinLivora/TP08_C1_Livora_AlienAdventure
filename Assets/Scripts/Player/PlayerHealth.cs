using System;
using UnityEngine;

[RequireComponent(typeof(PlayerPowerUps))]
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private PlayerDataSo data;

    private PlayerPowerUps powerUps;
    private int currentHealth;

    public event Action<int, int> HealthChanged;
    public event Action Died;

    private void Awake()
    {
        powerUps = GetComponent<PlayerPowerUps>();
        currentHealth = data.maxHealth;
    }

    private void Start()
    {
        HealthChanged?.Invoke(currentHealth, data.maxHealth);
    }

    public void TakeDamage(int amount)
    {
        if (currentHealth <= 0 || powerUps.IsProtected)
            return;

        currentHealth = Mathf.Max(currentHealth - amount, 0);
        HealthChanged?.Invoke(currentHealth, data.maxHealth);

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

        currentHealth = Mathf.Min(currentHealth + amount, data.maxHealth);
        HealthChanged?.Invoke(currentHealth, data.maxHealth);
    }
}
