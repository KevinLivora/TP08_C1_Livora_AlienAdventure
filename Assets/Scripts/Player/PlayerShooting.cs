using System;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(PlayerPowerUps))]
public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private PlayerDataSo data;
    [SerializeField] private Transform firePoint;
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Color powerShotColor = new Color(0.2f, 0.6f, 1f);

    private PlayerController player;
    private PlayerPowerUps powerUps;
    private float nextShotTime;

    public event Action Shot;

    private void Awake()
    {
        player = GetComponent<PlayerController>();
        powerUps = GetComponent<PlayerPowerUps>();
    }

    private void Update()
    {
        if (Time.timeScale == 0f)
            return;

        if (Input.GetKey(data.shootKey) && Time.time >= nextShotTime)
            Shoot();
    }

    private void Shoot()
    {
        nextShotTime = Time.time + data.fireCooldown;

        bool isPowerShot = powerUps.HasPowerShot;
        float damage = isPowerShot ? data.powerShotDamage : data.bulletDamage;

        Bullet bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        bullet.Initialize(Vector2.right * player.FacingSign, damage, data.bulletSpeed, data.bulletLifeTime);

        if (isPowerShot)
            bullet.SetColor(powerShotColor);

        Shot?.Invoke();
    }
}
