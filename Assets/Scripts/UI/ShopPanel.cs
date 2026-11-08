using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopPanel : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private TMP_Text coinsText;
    [SerializeField] private ShopItemRow[] rows;
    [SerializeField] private Button closeButton;

    public static bool IsOpen { get; private set; }

    private void Awake()
    {
        foreach (ShopItemRow row in rows)
            row.Purchased += OnPurchased;

        closeButton.onClick.AddListener(Close);
    }

    private void OnEnable()
    {
        IsOpen = true;
        Refresh();
    }

    private void OnDisable()
    {
        IsOpen = false;
    }

    private void OnDestroy()
    {
        foreach (ShopItemRow row in rows)
        {
            if (row != null)
                row.Purchased -= OnPurchased;
        }

        closeButton.onClick.RemoveListener(Close);
    }

    public void Open()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0f;
        AudioManager.Instance.PlayShopOpen();
    }

    public void Close()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
        AudioManager.Instance.PlayClick();
    }

    private void OnPurchased()
    {
        playerHealth.RefreshMaxHealth();
        Refresh();
    }

    private void Refresh()
    {
        coinsText.text = $"Coins: {SaveData.Coins}";

        foreach (ShopItemRow row in rows)
            row.Refresh();
    }

    [ContextMenu("Add 50 Coins")]
    private void AddTestCoins()
    {
        SaveData.AddCoins(50);
        Refresh();
    }

    [ContextMenu("Reset Shop")]
    private void ResetShop()
    {
        SaveData.ResetShop();
        Refresh();
    }
}
