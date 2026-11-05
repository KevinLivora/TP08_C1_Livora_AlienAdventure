using UnityEngine;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(PlayerMelee))]
public class PlayerAudio : MonoBehaviour
{
    private PlayerController player;
    private PlayerMelee melee;

    private void Awake()
    {
        player = GetComponent<PlayerController>();
        melee = GetComponent<PlayerMelee>();
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

    private void OnJumped() => AudioManager.Instance.PlayJump();

    private void OnLanded() => AudioManager.Instance.PlayLand();

    private void OnAttacked() => AudioManager.Instance.PlayAttack();
}
