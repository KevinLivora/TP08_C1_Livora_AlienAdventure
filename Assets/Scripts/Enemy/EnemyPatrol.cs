using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private EnemyDataSo data;

    private Rigidbody2D body;
    private SpriteRenderer spriteRenderer;
    private float startX;
    private int direction = -1;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        startX = transform.position.x;
    }

    private void FixedUpdate()
    {
        float offset = body.position.x - startX;

        if (direction < 0 && offset <= -data.patrolDistance)
            direction = 1;
        else if (direction > 0 && offset >= data.patrolDistance)
            direction = -1;

        body.linearVelocity = new Vector2(direction * data.moveSpeed, 0f);
        spriteRenderer.flipX = direction > 0;
    }
}
