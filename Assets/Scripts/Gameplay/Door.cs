using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] private SpriteRenderer midRenderer;
    [SerializeField] private SpriteRenderer topRenderer;
    [SerializeField] private Sprite openMidSprite;
    [SerializeField] private Sprite openTopSprite;
    [SerializeField] private string nextScene;

    private bool isOpen;

    public void Open()
    {
        isOpen = true;
        midRenderer.sprite = openMidSprite;
        topRenderer.sprite = openTopSprite;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!isOpen || !other.CompareTag(GameTags.Player))
            return;

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
