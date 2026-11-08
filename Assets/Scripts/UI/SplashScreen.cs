using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private float fadeInTime = 1f;
    [SerializeField] private float holdTime = 1.5f;
    [SerializeField] private float fadeOutTime = 1f;
    [SerializeField] private string nextScene = "Main Menu";

    private bool loading;

    private void Start()
    {
        canvasGroup.alpha = 0f;
        StartCoroutine(PlaySplash());
    }

    private void Update()
    {
        if (!loading && Input.anyKeyDown)
        {
            StopAllCoroutines();
            LoadNext();
        }
    }

    private IEnumerator PlaySplash()
    {
        yield return Fade(0f, 1f, fadeInTime);
        yield return new WaitForSecondsRealtime(holdTime);
        yield return Fade(1f, 0f, fadeOutTime);

        LoadNext();
    }

    private IEnumerator Fade(float from, float to, float duration)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.unscaledDeltaTime;
            canvasGroup.alpha = Mathf.Lerp(from, to, elapsed / duration);
            yield return null;
        }

        canvasGroup.alpha = to;
    }

    private void LoadNext()
    {
        loading = true;
        SceneManager.LoadScene(nextScene);
    }
}
