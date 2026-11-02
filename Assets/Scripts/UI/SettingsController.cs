using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    [Header("Mixer")]
    [SerializeField] private AudioMixer mixer;

    [Header("Volume Sliders")]
    [SerializeField] private Slider sliderMaster;
    [SerializeField] private Slider sliderMusic;
    [SerializeField] private Slider sliderSfx;
    [SerializeField] private Slider sliderUi;

    private const string MasterParameter = "VolumeMaster";
    private const string MusicParameter = "VolumeMusic";
    private const string SfxParameter = "VolumeSfx";
    private const string UiParameter = "VolumeUi";

    private const float MinSliderValue = 0.0001f;
    private const float MaxSliderValue = 1f;
    private const float DecibelMultiplier = 30f;
    private const float MinDecibels = -80f;
    private const float MaxDecibels = 0f;

    private void Awake()
    {
        BindSlider(sliderMaster, MasterParameter);
        BindSlider(sliderMusic, MusicParameter);
        BindSlider(sliderSfx, SfxParameter);
        BindSlider(sliderUi, UiParameter);
    }

    private void Start()
    {
        SyncSlider(sliderMaster, MasterParameter);
        SyncSlider(sliderMusic, MusicParameter);
        SyncSlider(sliderSfx, SfxParameter);
        SyncSlider(sliderUi, UiParameter);
    }

    private void OnDestroy()
    {
        sliderMaster.onValueChanged.RemoveAllListeners();
        sliderMusic.onValueChanged.RemoveAllListeners();
        sliderSfx.onValueChanged.RemoveAllListeners();
        sliderUi.onValueChanged.RemoveAllListeners();
    }

    private void BindSlider(Slider slider, string parameter)
    {
        slider.minValue = MinSliderValue;
        slider.maxValue = MaxSliderValue;
        slider.onValueChanged.AddListener(value => SetMixerVolume(parameter, value));
    }

    private void SyncSlider(Slider slider, string parameter)
    {
        if (mixer.GetFloat(parameter, out float decibels))
            slider.SetValueWithoutNotify(Mathf.Pow(10f, decibels / DecibelMultiplier));
    }

    private void SetMixerVolume(string parameter, float value)
    {
        float decibels = Mathf.Clamp(Mathf.Log10(value) * DecibelMultiplier, MinDecibels, MaxDecibels);
        mixer.SetFloat(parameter, decibels);
    }
}
