using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [Header("Sources")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioSource uiSource;

    [Header("Sfx Clips")]
    [SerializeField] private AudioClip jumpClip;
    [SerializeField] private AudioClip landClip;
    [SerializeField] private AudioClip shootClip;
    [SerializeField] private AudioClip enemyKilledClip;
    [SerializeField] private AudioClip coinClip;
    [SerializeField] private AudioClip starClip;
    [SerializeField] private AudioClip extraLifeClip;
    [SerializeField] private AudioClip lifeLostClip;
    [SerializeField] private AudioClip gameOverClip;
    [SerializeField] private AudioClip keyClip;
    [SerializeField] private AudioClip winClip;

    [Header("Ui Clips")]
    [SerializeField] private AudioClip clickClip;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void PlayMusic(AudioClip clip)
    {
        if (clip == null || (musicSource.clip == clip && musicSource.isPlaying))
            return;

        musicSource.clip = clip;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void StopMusic() => musicSource.Stop();

    public void PlayJump() => PlaySfx(jumpClip);

    public void PlayLand() => PlaySfx(landClip);

    public void PlayShoot() => PlaySfx(shootClip);

    public void PlayEnemyKilled() => PlaySfx(enemyKilledClip);

    public void PlayCoin() => PlaySfx(coinClip);

    public void PlayStar() => PlaySfx(starClip);

    public void PlayExtraLife() => PlaySfx(extraLifeClip);

    public void PlayLifeLost() => PlaySfx(lifeLostClip);

    public void PlayGameOver() => PlaySfx(gameOverClip);

    public void PlayKey() => PlaySfx(keyClip);

    public void PlayWin() => PlaySfx(winClip);

    public void PlayClick() => uiSource.PlayOneShot(clickClip);

    private void PlaySfx(AudioClip clip)
    {
        if (clip != null)
            sfxSource.PlayOneShot(clip);
    }
}
