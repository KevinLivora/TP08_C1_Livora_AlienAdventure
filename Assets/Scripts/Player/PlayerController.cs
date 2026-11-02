using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerDataSo data;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D body;
    private Collider2D bodyCollider;
    private float horizontalInput;
    private bool jumpRequested;
    private bool isGrounded;

    public event Action Jumped;
    public event Action Landed;

    public int FacingSign { get; private set; } = 1;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        bodyCollider = GetComponent<Collider2D>();
        body.gravityScale = data.gravityScale;
    }

    private void Update()
    {
        if (Time.timeScale == 0f)
            return;

        horizontalInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(data.jumpKey))
            jumpRequested = true;

        UpdateFacing();
    }

    private void FixedUpdate()
    {
        Move();
        CheckGround();
        TryJump();
    }

    private void Move()
    {
        body.linearVelocity = new Vector2(horizontalInput * data.moveSpeed, body.linearVelocity.y);
    }

    private void CheckGround()
    {
        bool wasGrounded = isGrounded;
        isGrounded = bodyCollider.IsTouchingLayers(groundLayer);

        if (!wasGrounded && isGrounded)
            Landed?.Invoke();
    }

    private void TryJump()
    {
        if (jumpRequested && isGrounded)
        {
            body.AddForce(Vector2.up * data.jumpForce, ForceMode2D.Impulse);
            Jumped?.Invoke();
        }

        jumpRequested = false;
    }

    private void UpdateFacing()
    {
        if (horizontalInput == 0f)
            return;

        FacingSign = horizontalInput > 0f ? 1 : -1;

        Vector3 scale = transform.localScale;
        scale.x = Mathf.Abs(scale.x) * FacingSign;
        transform.localScale = scale;
    }
}
