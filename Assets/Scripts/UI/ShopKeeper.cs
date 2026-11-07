using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ShopKeeper : MonoBehaviour
{
    [SerializeField] private ShopPanel shopPanel;
    [SerializeField] private GameObject prompt;
    [SerializeField] private KeyCode interactKey = KeyCode.E;

    private bool playerInRange;

    private void Awake()
    {
        prompt.SetActive(false);
    }

    private void Update()
    {
        if (!playerInRange || Time.timeScale == 0f)
            return;

        if (Input.GetKeyDown(interactKey))
            shopPanel.Open();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag(GameTags.Player))
            return;

        playerInRange = true;
        prompt.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag(GameTags.Player))
            return;

        playerInRange = false;
        prompt.SetActive(false);
    }
}
