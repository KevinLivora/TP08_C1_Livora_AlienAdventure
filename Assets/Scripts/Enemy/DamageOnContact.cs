using UnityEngine;

public class DamageOnContact : MonoBehaviour
{
    [SerializeField] private int damage = 1;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!other.CompareTag(GameTags.Player))
            return;

        PlayerHealth health = other.GetComponent<PlayerHealth>();

        if (health != null)
            health.TakeDamage(damage);
    }
}
