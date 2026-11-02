using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayHud : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private PlayerPowerUps playerPowerUps;

    [Header("Texts")]
    [SerializeField] private TMP_Text healthText;

    [Header("Keys")]
    [SerializeField] private Image[] keyIcons;
    [SerializeField] private Sprite keyFullSprite;
    [SerializeField] private Sprite keyEmptySprite;

    [Header("Invincibility")]
    [SerializeField] private GameObject invincibilityPanel;
    [SerializeField] private TMP_Text invincibilityText;

    [Header("Power Shot")]
    [SerializeField] private GameObject powerShotPanel;
    [SerializeField] private TMP_Text powerShotText;

    [Header("Result")]
    [SerializeField] private GameObject resultPanel;
    [SerializeField] private TMP_Text resultTitleText;
    [SerializeField] private Button btnRetry;
    [SerializeField] private Button btnMenu;

    private const string MainMenuScene = "Main Menu";

    private void Awake()
    {
        btnRetry.onClick.AddListener(OnRetryClicked);
        btnMenu.onClick.AddListener(OnMenuClicked);

        resultPanel.SetActive(false);
        invincibilityPanel.SetActive(false);
        powerShotPanel.SetActive(false);
    }

    private void OnEnable()
    {
        playerHealth.HealthChanged += SetHealth;
    }

    private void OnDisable()
    {
        playerHealth.HealthChanged -= SetHealth;
    }

    private void OnDestroy()
    {
        btnRetry.onClick.RemoveAllListeners();
        btnMenu.onClick.RemoveAllListeners();
    }

    private void Update()
    {
        bool isInvincible = playerPowerUps.IsInvincible;
        invincibilityPanel.SetActive(isInvincible);

        if (isInvincible)
        {
            float remaining = Mathf.Max(playerPowerUps.InvincibleTimer, 0f);
            invincibilityText.text = $"Invincible: {remaining:F1}s";
        }

        bool hasPowerShot = playerPowerUps.HasPowerShot;
        powerShotPanel.SetActive(hasPowerShot);

        if (hasPowerShot)
        {
            float remaining = Mathf.Max(playerPowerUps.PowerShotTimer, 0f);
            powerShotText.text = $"PowerUp: {remaining:F1}s";
        }
    }

    public void SetKeys(int collected, int required)
    {
        for (int i = 0; i < keyIcons.Length; i++)
        {
            keyIcons[i].gameObject.SetActive(i < required);
            keyIcons[i].sprite = i < collected ? keyFullSprite : keyEmptySprite;
        }
    }

    public void ShowResult(bool won)
    {
        resultTitleText.text = won ? "YOU WIN!" : "GAME OVER";
        resultPanel.SetActive(true);
    }

    private void SetHealth(int current, int max)
    {
        healthText.text = $"Health: {current}/{max}";
    }

    private void OnRetryClicked()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnMenuClicked()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(MainMenuScene);
    }
}