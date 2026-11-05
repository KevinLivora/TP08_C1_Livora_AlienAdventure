using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Game/Player Data")]
public class PlayerDataSo : ScriptableObject
{
    public float moveSpeed = 6f;
    public float jumpForce = 15f;
    public int maxJumps = 2;
    public float gravityScale = 4f;
    public KeyCode jumpKey = KeyCode.Space;

    public KeyCode attackKey = KeyCode.Mouse0;
    public KeyCode attackAltKey = KeyCode.J;
    public float attackDamage = 34f;
    public float attackCooldown = 0.4f;
    public float attackHitDelay = 0.08f;
    public float attackWidth = 1.4f;
    public float attackHeight = 1.2f;
    public float attackKnockback = 2.5f;

    public int maxHealth = 3;
    public float hitProtectionDuration = 1.5f;
    public float invincibilityDuration = 5f;
    public float damageBoostDuration = 8f;
    public float damageBoostMultiplier = 2f;
}
