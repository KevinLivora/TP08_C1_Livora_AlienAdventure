using UnityEngine;

public static class SaveData
{
    private const string CoinsKey = "Coins";
    private const string BestScoreKey = "BestScore";

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
}
