using UnityEngine;

[CreateAssetMenu(fileName = "ShopItem", menuName = "Game/Shop Item")]
public class ShopItemSo : ScriptableObject
{
    public string displayName = "Item";
    public ShopStat stat;
    public int maxLevel = 3;
    public int basePrice = 5;
    public int priceStep = 5;

    public int GetPrice(int currentLevel)
    {
        return basePrice + priceStep * currentLevel;
    }
}
