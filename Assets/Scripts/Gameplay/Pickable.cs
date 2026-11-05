using UnityEngine;

public abstract class Pickable : MonoBehaviour
{
    protected abstract void OnPicked(GameObject player);

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag(GameTags.Player))
            return;

        OnPicked(other.gameObject);
        Destroy(gameObject);
    }
}
