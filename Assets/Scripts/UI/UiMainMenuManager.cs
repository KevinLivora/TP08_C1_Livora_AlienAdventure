using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiMainMenuManager : MonoBehaviour
{
    [SerializeField] private Button btnPlay;
    [SerializeField] private Button btnQuit;

    private void Awake()
    {
        btnPlay.onClick.AddListener(OnPlayClick);
        btnQuit.onClick.AddListener(OnQuitClick);
    }

    private void OnDestroy()
    {
        btnPlay.onClick.RemoveAllListeners();
        btnQuit.onClick.RemoveAllListeners();
    }

    private void OnPlayClick()
    {
        SceneManager.LoadScene("Gameplay");
    }

    private void OnQuitClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}