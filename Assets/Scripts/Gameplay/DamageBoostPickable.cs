using UnityEngine;

public class DamageBoostPickable : Pickable
{
    protected override void OnPicked(GameObject player)
    {
        player.GetComponent<PlayerPowerUps>().ActivateDamageBoost();
        AudioManager.Instance.PlayStar();
    }
}
