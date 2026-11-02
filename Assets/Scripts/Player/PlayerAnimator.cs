using UnityEngine;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private const string IsGroundedParam = "IsGrounded";
    private const string SpeedParam = "Speed";

    private PlayerController player;
    private Rigidbody2D body;
    private Animator animator;

    private void Awake()
    {
        player = GetComponent<PlayerController>();
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        player.Jumped += OnJumped;
        player.Landed += OnLanded;
    }

    private void OnDisable()
    {
        player.Jumped -= OnJumped;
        player.Landed -= OnLanded;
    }

    private void Update()
    {
        animator.SetFloat(SpeedParam, Mathf.Abs(body.linearVelocity.x));
    }

    private void OnJumped() => animator.SetBool(IsGroundedParam, false);

    private void OnLanded() => animator.SetBool(IsGroundedParam, true);
}
