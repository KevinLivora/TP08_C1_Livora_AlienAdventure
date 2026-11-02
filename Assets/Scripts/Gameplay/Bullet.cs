using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D body;
    private SpriteRenderer[] spriteRenderers;
    private TrailRenderer trail;
    private float damage;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        trail = GetComponentInChildren<TrailRenderer>();
    }

    public void Initialize(Vector2 direction, float damage, float speed, float lifeTime)
    {
        this.damage = damage;
        transform.right = direction;
        body.linearVelocity = direction * speed;
        Destroy(gameObject, lifeTime);
    }

    public void SetColor(Color color)
    {
        foreach (SpriteRenderer spriteRenderer in spriteRenderers)
            spriteRenderer.color = color;

        if (trail != null)
        {
            trail.startColor = color;
            trail.endColor = new Color(color.r, color.g, color.b, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out IDamageable target))
        {
            target.TakeDamage(damage);
            Destroy(gameObject);
            return;
        }

        if ((groundLayer.value & (1 << other.gameObject.layer)) != 0)
            Destroy(gameObject);
    }
}
