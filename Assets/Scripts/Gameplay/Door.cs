using UnityEngine;

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
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!isOpen || !other.CompareTag(GameTags.Player))
            return;

        GameManager.Instance.Win();
    }
}
