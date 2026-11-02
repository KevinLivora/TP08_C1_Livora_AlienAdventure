using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiPauseMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject creditsPanel;

    [SerializeField] private Button btnContinue;
    [SerializeField] private Button btnPauseSettings;
    [SerializeField] private Button btnPauseCredits;
    [SerializeField] private Button btnPauseQuit;

    [SerializeField] private Button btnBackSettings;
    [SerializeField] private Button btnBackCredits;

    private const string MainMenuScene = "Main Menu";

    private bool isPaused;

    private void Awake()
    {
        btnContinue.onClick.AddListener(Resume);
        btnPauseSettings.onClick.AddListener(() => OpenPanel(settingsPanel));
        btnPauseCredits.onClick.AddListener(() => OpenPanel(creditsPanel));
        btnPauseQuit.onClick.AddListener(OnQuitClicked);
        btnBackSettings.onClick.AddListener(CloseToPauseMenu);
        btnBackCredits.onClick.AddListener(CloseToPauseMenu);
    }

    private void Start()
    {
        pausePanel.SetActive(false);
        settingsPanel.SetActive(false);
        creditsPanel.SetActive(false);
    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Escape))
            return;

        if (!GameManager.Instance.IsPlaying)
            return;

        if (isPaused)
            Resume();
        else
            Pause();
    }

    private void OnDestroy()
    {
        btnContinue.onClick.RemoveAllListeners();
        btnPauseSettings.onClick.RemoveAllListeners();
        btnPauseCredits.onClick.RemoveAllListeners();
        btnPauseQuit.onClick.RemoveAllListeners();
        btnBackSettings.onClick.RemoveAllListeners();
        btnBackCredits.onClick.RemoveAllListeners();
    }

    private void Pause()
    {
        isPaused = true;
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    private void Resume()
    {
        isPaused = false;
        pausePanel.SetActive(false);
        settingsPanel.SetActive(false);
        creditsPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    private void OnQuitClicked()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(MainMenuScene);
    }

    private void OpenPanel(GameObject panelToOpen)
    {
        pausePanel.SetActive(false);
        panelToOpen.SetActive(true);
    }

    private void CloseToPauseMenu()
    {
        settingsPanel.SetActive(false);
        creditsPanel.SetActive(false);
        pausePanel.SetActive(true);
    }
}
