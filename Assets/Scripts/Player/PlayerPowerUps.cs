using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerPowerUps : MonoBehaviour
{
    [SerializeField] private PlayerDataSo data;
    [SerializeField] private Color invincibleColor = new Color(1f, 0.9f, 0.3f);
    [SerializeField] private Color hitColor = new Color(1f, 1f, 1f, 0.4f);

    private SpriteRenderer spriteRenderer;
    private float invincibleTimer;
    private float hitTimer;
    private float powerShotTimer;

    public bool IsInvincible => invincibleTimer > 0f;
    public bool IsProtected => invincibleTimer > 0f || hitTimer > 0f;
    public bool HasPowerShot => powerShotTimer > 0f;
    public float InvincibleTimer => invincibleTimer;
    public float PowerShotTimer => powerShotTimer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (invincibleTimer > 0f)
            invincibleTimer -= Time.deltaTime;

        if (hitTimer > 0f)
            hitTimer -= Time.deltaTime;

        if (powerShotTimer > 0f)
            powerShotTimer -= Time.deltaTime;

        RefreshColor();
    }

    public void ActivateInvincibility()
    {
        invincibleTimer = data.invincibilityDuration;
    }

    public void ActivatePowerShot()
    {
        powerShotTimer = data.powerShotDuration;
    }

    public void ActivateHitProtection()
    {
        hitTimer = data.hitProtectionDuration;
    }

    private void RefreshColor()
    {
        if (IsInvincible)
            spriteRenderer.color = invincibleColor;
        else if (hitTimer > 0f)
            spriteRenderer.color = hitColor;
        else
            spriteRenderer.color = Color.white;
    }
}