using UnityEngine;

public static class RunState
{
    private static int health = -1;
    private static int coins;

    public static void Store(int currentHealth, int runCoins)
    {
        health = currentHealth;
        coins = runCoins;
    }

    public static int TakeHealth(int maxHealth)
    {
        int value = health > 0 ? Mathf.Min(health, maxHealth) : maxHealth;
        health = -1;
        return value;
    }

    public static int TakeCoins()
    {
        int value = coins;
        coins = 0;
        return value;
    }
}
