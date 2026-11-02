using UnityEngine;
using UnityEngine.UI;

public class UiMenuManager : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject creditsPanel;

    [Header("Main Menu Buttons")]
    [SerializeField] private Button btnSettings;
    [SerializeField] private Button btnCredits;

    [Header("Back Buttons")]
    [SerializeField] private Button btnBackSettings;
    [SerializeField] private Button btnBackCredits;

    private void Awake()
    {
        btnSettings.onClick.AddListener(() => OpenPanel(settingsPanel));
        btnCredits.onClick.AddListener(() => OpenPanel(creditsPanel));
        btnBackSettings.onClick.AddListener(CloseToMainMenu);
        btnBackCredits.onClick.AddListener(CloseToMainMenu);
    }

    private void Start()
    {
        mainMenuPanel.SetActive(true);
        settingsPanel.SetActive(false);
        creditsPanel.SetActive(false);
    }

    private void OnDestroy()
    {
        btnSettings.onClick.RemoveAllListeners();
        btnCredits.onClick.RemoveAllListeners();
        btnBackSettings.onClick.RemoveAllListeners();
        btnBackCredits.onClick.RemoveAllListeners();
    }

    private void OpenPanel(GameObject panel)
    {
        mainMenuPanel.SetActive(false);
        panel.SetActive(true);
    }

    private void CloseToMainMenu()
    {
        settingsPanel.SetActive(false);
        creditsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
}