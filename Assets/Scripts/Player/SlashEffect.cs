using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SlashEffect : MonoBehaviour
{
    [SerializeField] private Sprite[] frames;
    [SerializeField] private float frameTime = 0.04f;

    private SpriteRenderer spriteRenderer;
    private Coroutine playing;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }

    public void Play(Color color)
    {
        if (playing != null)
            StopCoroutine(playing);

        spriteRenderer.color = color;
        playing = StartCoroutine(PlayFrames());
    }

    private IEnumerator PlayFrames()
    {
        spriteRenderer.enabled = true;

        foreach (Sprite frame in frames)
        {
            spriteRenderer.sprite = frame;
            yield return new WaitForSeconds(frameTime);
        }

        spriteRenderer.enabled = false;
        playing = null;
    }
}
