using System;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private EnemyDataSo data;
    [SerializeField] private ParticleSystem deathEffect;

    private float health;
    private bool isDead;

    public event Action<float> HealthChanged;

    private void Awake()
    {
        health = data.maxHealth;
    }

    public void TakeDamage(float amount)
    {
        if (isDead)
            return;

        health = Mathf.Max(health - amount, 0f);
        HealthChanged?.Invoke(health / data.maxHealth);

        if (health <= 0f)
            Die();
    }

    private void Die()
    {
        isDead = true;

        ParticleSystem effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        ParticleSystem.MainModule main = effect.main;
        Destroy(effect.gameObject, main.duration + main.startLifetime.constantMax);

        AudioManager.Instance.PlayEnemyKilled();
        Destroy(gameObject);
    }
}
