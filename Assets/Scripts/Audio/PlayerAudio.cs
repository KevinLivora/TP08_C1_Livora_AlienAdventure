using UnityEngine;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(PlayerShooting))]
public class PlayerAudio : MonoBehaviour
{
    private PlayerController player;
    private PlayerShooting shooting;

    private void Awake()
    {
        player = GetComponent<PlayerController>();
        shooting = GetComponent<PlayerShooting>();
    }

    private void OnEnable()
    {
        player.Jumped += OnJumped;
        player.Landed += OnLanded;
        shooting.Shot += OnShot;
    }

    private void OnDisable()
    {
        player.Jumped -= OnJumped;
        player.Landed -= OnLanded;
        shooting.Shot -= OnShot;
    }

    private void OnJumped() => AudioManager.Instance.PlayJump();

    private void OnLanded() => AudioManager.Instance.PlayLand();

    private void OnShot() => AudioManager.Instance.PlayShoot();
}
