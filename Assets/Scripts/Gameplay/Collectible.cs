using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private CollectibleType type;
    [SerializeField] private int coinValue = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag(GameTags.Player))
            return;

        Collect(other);
        Destroy(gameObject);
    }

    private void Collect(Collider2D player)
    {
        switch (type)
        {
            case CollectibleType.Coin:
                GameManager.Instance.AddCoin(coinValue);
                AudioManager.Instance.PlayCoin();
                break;

            case CollectibleType.Star:
                player.GetComponent<PlayerPowerUps>().ActivateInvincibility();
                AudioManager.Instance.PlayStar();
                break;

            case CollectibleType.ExtraLife:
                GameManager.Instance.AddLife();
                AudioManager.Instance.PlayExtraLife();
                break;

            case CollectibleType.DamageBoost:
                player.GetComponent<PlayerPowerUps>().ActivateDamageBoost();
                AudioManager.Instance.PlayStar();
                break;

            case CollectibleType.Key:
                GameManager.Instance.AddKey();
                break;
        }
    }
}
