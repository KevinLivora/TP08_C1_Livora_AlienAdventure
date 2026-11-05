using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayHud : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private PlayerPowerUps playerPowerUps;

    [Header("Texts")]
    [SerializeField] private Image healthFill;
    [SerializeField] private Color fullHealthColor = new Color(0.3f, 0.85f, 0.35f);
    [SerializeField] private Color lowHealthColor = new Color(0.9f, 0.2f, 0.2f);
    [SerializeField] private TMP_Text coinsText;

    [Header("Keys")]
    [SerializeField] private Image[] keyIcons;
    [SerializeField] private Sprite keyFullSprite;
    [SerializeField] private Sprite keyEmptySprite;

    [Header("Invincibility")]
    [SerializeField] private GameObject invincibilityPanel;
    [SerializeField] private TMP_Text invincibilityText;

    [Header("Damage Boost")]
    [FormerlySerializedAs("powerShotPanel")]
    [SerializeField] private GameObject damageBoostPanel;
    [FormerlySerializedAs("powerShotText")]
    [SerializeField] private TMP_Text damageBoostText;

    [Header("Result")]
    [SerializeField] private GameObject resultPanel;
    [SerializeField] private TMP_Text resultTitleText;
    [SerializeField] private TMP_Text finalScoreText;
    [SerializeField] private TMP_Text bestScoreText;
    [SerializeField] private Button btnRetry;
    [SerializeField] private Button btnMenu;

    private const string MainMenuScene = "Main Menu";

    private void Awake()
    {
        btnRetry.onClick.AddListener(OnRetryClicked);
        btnMenu.onClick.AddListener(OnMenuClicked);

        resultPanel.SetActive(false);
        invincibilityPanel.SetActive(false);
        damageBoostPanel.SetActive(false);
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

        bool hasDamageBoost = playerPowerUps.HasDamageBoost;
        damageBoostPanel.SetActive(hasDamageBoost);

        if (hasDamageBoost)
        {
            float remaining = Mathf.Max(playerPowerUps.DamageBoostTimer, 0f);
            damageBoostText.text = $"Damage x2: {remaining:F1}s";
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

    public void SetCoins(int coins)
    {
        coinsText.text = $"Coins: {coins}";
    }

    public void ShowResult(bool won, int score, int bestScore)
    {
        resultTitleText.text = won ? "YOU WIN!" : "GAME OVER";
        finalScoreText.text = $"Score: {score}";
        bestScoreText.text = $"Best: {bestScore}";
        resultPanel.SetActive(true);
    }

    private void SetHealth(int current, int max)
    {
        float ratio = max > 0 ? (float)current / max : 0f;
        healthFill.fillAmount = ratio;
        healthFill.color = Color.Lerp(lowHealthColor, fullHealthColor, ratio);
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