using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private GameplayHud hud;
    [SerializeField] private Door door;
    [SerializeField] private int keysRequired = 3;

    private int keys;
    private int runCoins;

    public bool IsPlaying { get; private set; }
    public int RunCoins => runCoins;

    private void Awake()
    {
        Instance = this;
        runCoins = RunState.TakeCoins();
        IsPlaying = true;
    }

    private void OnEnable()
    {
        playerHealth.Died += HandlePlayerDied;
    }

    private void OnDisable()
    {
        playerHealth.Died -= HandlePlayerDied;
    }

    private void Start()
    {
        hud.SetKeys(keys, keysRequired);
        hud.SetCoins(runCoins);
    }

    public void AddCoin(int amount)
    {
        if (!IsPlaying)
            return;

        runCoins += amount;
        SaveData.AddCoins(amount);
        hud.SetCoins(runCoins);
    }

    public void AddLife()
    {
        if (!IsPlaying)
            return;

        playerHealth.Heal(1);
    }

    public void AddKey()
    {
        if (!IsPlaying)
            return;

        keys++;
        hud.SetKeys(keys, keysRequired);
        AudioManager.Instance.PlayKey();

        if (keys >= keysRequired)
            door.Open();
    }

    public void Win()
    {
        if (!IsPlaying)
            return;

        EndGame(true);
    }

    private void HandlePlayerDied()
    {
        EndGame(false);
    }

    private void EndGame(bool won)
    {
        IsPlaying = false;

        SaveData.SaveBestScore(runCoins);

        AudioManager.Instance.StopMusic();

        if (won)
            AudioManager.Instance.PlayWin();
        else
            AudioManager.Instance.PlayGameOver();

        hud.ShowResult(won, runCoins, SaveData.BestScore);

        Time.timeScale = 0f;
    }
}
