using UnityEngine;

public class HealPickable : Pickable
{
    [SerializeField] private int healAmount = 1;

    protected override void OnPicked(GameObject player)
    {
        player.GetComponent<PlayerHealth>().Heal(healAmount);
        AudioManager.Instance.PlayExtraLife();
    }
}
