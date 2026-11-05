using UnityEngine;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerMelee))]
public class PlayerAnimator : MonoBehaviour
{
    private const string IsGroundedParam = "IsGrounded";
    private const string SpeedParam = "Speed";
    private const string AttackParam = "Attack";

    private PlayerController player;
    private PlayerMelee melee;
    private Rigidbody2D body;
    private Animator animator;

    private void Awake()
    {
        player = GetComponent<PlayerController>();
        melee = GetComponent<PlayerMelee>();
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        player.Jumped += OnJumped;
        player.Landed += OnLanded;
        melee.Attacked += OnAttacked;
    }

    private void OnDisable()
    {
        player.Jumped -= OnJumped;
        player.Landed -= OnLanded;
        melee.Attacked -= OnAttacked;
    }

    private void Update()
    {
        animator.SetFloat(SpeedParam, Mathf.Abs(body.linearVelocity.x));
    }

    private void OnJumped() => animator.SetBool(IsGroundedParam, false);

    private void OnLanded() => animator.SetBool(IsGroundedParam, true);

    private void OnAttacked() => animator.SetTrigger(AttackParam);
}
