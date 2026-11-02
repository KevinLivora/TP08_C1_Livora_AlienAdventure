using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerEffects : MonoBehaviour
{
    [SerializeField] private ParticleSystem dust;

    private PlayerController player;

    private void Awake()
    {
        player = GetComponent<PlayerController>();
    }

    private void OnEnable()
    {
        player.Jumped += PlayDust;
        player.Landed += PlayDust;
    }

    private void OnDisable()
    {
        player.Jumped -= PlayDust;
        player.Landed -= PlayDust;
    }

    private void PlayDust()
    {
        dust.Play();
    }
}
