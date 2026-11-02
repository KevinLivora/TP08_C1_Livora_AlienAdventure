using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Game/Player Data")]
public class PlayerDataSo : ScriptableObject
{
    public float moveSpeed = 6f;
    public float jumpForce = 15f;
    public float gravityScale = 4f;
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode shootKey = KeyCode.Mouse0;
    public float bulletDamage = 25f;
    public float bulletSpeed = 14f;
    public float bulletLifeTime = 2f;
    public float fireCooldown = 0.35f;
    public float invincibilityDuration = 5f;
    public int maxHealth = 3;
    public float hitProtectionDuration = 1.5f;
    public float powerShotDuration = 8f;
    public float powerShotDamage = 1000f;
}
