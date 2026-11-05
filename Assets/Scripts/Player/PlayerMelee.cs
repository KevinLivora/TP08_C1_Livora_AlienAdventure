using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(PlayerPowerUps))]
public class PlayerMelee : MonoBehaviour
{
    [SerializeField] private PlayerDataSo data;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private SlashEffect slash;
    [SerializeField] private Color boostedSlashColor = new Color(1f, 0.55f, 0.2f);

    private PlayerController player;
    private PlayerPowerUps powerUps;
    private float nextAttackTime;

    public event Action Attacked;
    public event Action EnemyHit;

    private void Awake()
    {
        player = GetComponent<PlayerController>();
        powerUps = GetComponent<PlayerPowerUps>();
    }

    private void Update()
    {
        if (Time.timeScale == 0f)
            return;

        bool pressed = Input.GetKeyDown(data.attackKey) || Input.GetKeyDown(data.attackAltKey);

        if (pressed && Time.time >= nextAttackTime)
            StartCoroutine(Attack());
    }

    private IEnumerator Attack()
    {
        nextAttackTime = Time.time + data.attackCooldown;

        Attacked?.Invoke();
        slash.Play(powerUps.HasDamageBoost ? boostedSlashColor : Color.white);

        yield return new WaitForSeconds(data.attackHitDelay);

        DealDamage();
    }

    private void DealDamage()
    {
        float damage = data.attackDamage;

        if (powerUps.HasDamageBoost)
            damage *= data.damageBoostMultiplier;

        Vector2 knockback = new Vector2(player.FacingSign * data.attackKnockback, 0f);
        Vector2 size = new Vector2(data.attackWidth, data.attackHeight);
        Collider2D[] hits = Physics2D.OverlapBoxAll(attackPoint.position, size, 0f);

        HashSet<IDamageable> alreadyHit = new HashSet<IDamageable>();

        foreach (Collider2D hit in hits)
        {
            if (!hit.TryGetComponent(out IDamageable target) || !alreadyHit.Add(target))
                continue;

            target.TakeDamage(damage, knockback);
        }

        if (alreadyHit.Count > 0)
            EnemyHit?.Invoke();
    }

    private void OnDrawGizmosSelected()
    {
        if (data == null || attackPoint == null)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPoint.position, new Vector3(data.attackWidth, data.attackHeight, 0f));
    }
}
