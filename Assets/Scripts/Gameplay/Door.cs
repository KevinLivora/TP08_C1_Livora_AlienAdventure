using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] private SpriteRenderer midRenderer;
    [SerializeField] private SpriteRenderer topRenderer;
    [SerializeField] private Sprite openMidSprite;
    [SerializeField] private Sprite openTopSprite;

    private bool isOpen;

    public void Open()
    {
        isOpen = true;
        midRenderer.sprite = openMidSprite;
        topRenderer.sprite = openTopSprite;
        AudioManager.Instance.PlayDoorOpen();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!isOpen || !other.CompareTag(GameTags.Player))
            return;

        string nextScene = GameManager.Instance.NextScene;

        if (string.IsNullOrEmpty(nextScene))
        {
            GameManager.Instance.Win();
            return;
        }

        PlayerHealth health = other.GetComponent<PlayerHealth>();

        if (health != null)
            RunState.Store(health.CurrentHealth, GameManager.Instance.RunCoins);

        Time.timeScale = 1f;
        SceneManager.LoadScene(nextScene);
    }
}
