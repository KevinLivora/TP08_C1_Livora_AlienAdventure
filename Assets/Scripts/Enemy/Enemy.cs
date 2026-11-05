using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private EnemyDataSo data;
    [SerializeField] private ParticleSystem deathEffect;
    [SerializeField] private Pickable coinPrefab;
    [SerializeField] private Color hitColor = new Color(1f, 0.35f, 0.35f);
    [SerializeField] private float hitFlashDuration = 0.1f;
    [SerializeField] private float stunDuration = 0.15f;

    private Rigidbody2D body;
    private SpriteRenderer spriteRenderer;
    private Coroutine hurtRoutine;
    private float health;
    private bool isDead;

    public bool IsStunned { get; private set; }

    public event Action<float> HealthChanged;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        health = data.maxHealth;
    }

    public void TakeDamage(float amount, Vector2 knockback)
    {
        if (isDead)
            return;

        health = Mathf.Max(health - amount, 0f);
        HealthChanged?.Invoke(health / data.maxHealth);

        if (health <= 0f)
        {
            Die();
            return;
        }

        if (hurtRoutine != null)
            StopCoroutine(hurtRoutine);

        hurtRoutine = StartCoroutine(Hurt(knockback));
    }

    private IEnumerator Hurt(Vector2 knockback)
    {
        IsStunned = true;
        body.linearVelocity = knockback;
        spriteRenderer.color = hitColor;
        AudioManager.Instance.PlayEnemyHit();

        yield return new WaitForSeconds(hitFlashDuration);

        spriteRenderer.color = Color.white;

        yield return new WaitForSeconds(stunDuration - hitFlashDuration);

        IsStunned = false;
        hurtRoutine = null;
    }

    private void Die()
    {
        isDead = true;

        ParticleSystem effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        ParticleSystem.MainModule main = effect.main;
        Destroy(effect.gameObject, main.duration + main.startLifetime.constantMax);

        if (coinPrefab != null && UnityEngine.Random.value <= data.coinDropChance)
            Instantiate(coinPrefab, transform.position, Quaternion.identity);

        AudioManager.Instance.PlayEnemyKilled();
        Destroy(gameObject);
    }
}
