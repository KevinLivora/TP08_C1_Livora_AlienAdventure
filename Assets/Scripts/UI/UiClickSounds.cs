using UnityEngine;
using UnityEngine.UI;

public class UiClickSounds : MonoBehaviour
{
    private Button[] buttons;

    private void Awake()
    {
        buttons = GetComponentsInChildren<Button>(true);

        foreach (Button button in buttons)
            button.onClick.AddListener(PlayClick);
    }

    private void OnDestroy()
    {
        foreach (Button button in buttons)
        {
            if (button != null)
                button.onClick.RemoveListener(PlayClick);
        }
    }

    private void PlayClick() => AudioManager.Instance.PlayClick();
}
