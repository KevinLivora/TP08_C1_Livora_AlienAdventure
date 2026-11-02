using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private GameplayHud hud;
    [SerializeField] private Door door;
    [SerializeField] private int keysRequired = 3;

    private int keys;

    public bool IsPlaying { get; private set; }

    private void Awake()
    {
        Instance = this;
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

        AudioManager.Instance.StopMusic();

        if (won)
            AudioManager.Instance.PlayWin();
        else
            AudioManager.Instance.PlayGameOver();

        hud.ShowResult(won);

        Time.timeScale = 0f;
    }
}
