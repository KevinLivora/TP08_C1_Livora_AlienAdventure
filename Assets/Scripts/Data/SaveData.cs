using System;
using UnityEngine;

public static class SaveData
{
    private const string CoinsKey = "Coins";
    private const string BestScoreKey = "BestScore";
    private const string ShopLevelPrefix = "ShopLevel_";

    public static int Coins => PlayerPrefs.GetInt(CoinsKey, 0);
    public static int BestScore => PlayerPrefs.GetInt(BestScoreKey, 0);

    public static void AddCoins(int amount)
    {
        PlayerPrefs.SetInt(CoinsKey, Coins + amount);
        PlayerPrefs.Save();
    }

    public static bool SpendCoins(int amount)
    {
        if (amount > Coins)
            return false;

        PlayerPrefs.SetInt(CoinsKey, Coins - amount);
        PlayerPrefs.Save();
        return true;
    }

    public static void SaveBestScore(int score)
    {
        if (score <= BestScore)
            return;

        PlayerPrefs.SetInt(BestScoreKey, score);
        PlayerPrefs.Save();
    }

    public static int GetLevel(ShopStat stat)
    {
        return PlayerPrefs.GetInt(ShopLevelPrefix + stat, 0);
    }

    public static void SetLevel(ShopStat stat, int level)
    {
        PlayerPrefs.SetInt(ShopLevelPrefix + stat, level);
        PlayerPrefs.Save();
    }

    public static void ResetShop()
    {
        foreach (ShopStat stat in Enum.GetValues(typeof(ShopStat)))
            PlayerPrefs.DeleteKey(ShopLevelPrefix + stat);

        PlayerPrefs.Save();
    }
}
