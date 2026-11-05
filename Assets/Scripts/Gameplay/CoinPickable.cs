using UnityEngine;

public class CoinPickable : Pickable
{
    [SerializeField] private int coinValue = 1;

    protected override void OnPicked(GameObject player)
    {
        GameManager.Instance.AddCoin(coinValue);
        AudioManager.Instance.PlayCoin();
    }
}
