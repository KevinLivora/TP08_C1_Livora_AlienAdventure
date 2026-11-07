using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemRow : MonoBehaviour
{
    [SerializeField] private ShopItemSo item;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text levelText;
    [SerializeField] private TMP_Text priceText;
    [SerializeField] private Button buyButton;

    public event Action Purchased;

    private void Awake()
    {
        buyButton.onClick.AddListener(OnBuyClicked);
    }

    private void OnDestroy()
    {
        buyButton.onClick.RemoveListener(OnBuyClicked);
    }

    public void Refresh()
    {
        int level = SaveData.GetLevel(item.stat);
        bool isMax = level >= item.maxLevel;

        nameText.text = item.displayName;
        levelText.text = $"Lv {level}/{item.maxLevel}";
        priceText.text = isMax ? "MAX" : item.GetPrice(level).ToString();
        buyButton.interactable = !isMax && SaveData.Coins >= item.GetPrice(level);
    }

    private void OnBuyClicked()
    {
        int level = SaveData.GetLevel(item.stat);

        if (level >= item.maxLevel)
            return;

        if (!SaveData.SpendCoins(item.GetPrice(level)))
            return;

        SaveData.SetLevel(item.stat, level + 1);
        AudioManager.Instance.PlayCoin();
        Purchased?.Invoke();
    }
}
