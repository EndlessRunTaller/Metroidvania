using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    public AudioSource MusicaUrbana, MusicaMetroid;


    [SerializeField] private Slider masterSlider, musicaSlider, effecSlider;
    public const string MIXER_MASTER = "Master";
    public const string MIXER_MUSIC = "Music";
    public const string MIXER_SFX = "SFX";

    public static VolumeSettings instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        masterSlider.value = 0.5f;
        musicaSlider.value = 0.5f;
        effecSlider.value = 0.5f;

        masterSlider.onValueChanged.AddListener(SetMasterVolume);
        musicaSlider.onValueChanged.AddListener(SetMusicVolume);
        effecSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    private void Start()
    {
        masterSlider.value = PlayerPrefs.GetFloat(AudioManager.MASTER_KEY, 1f);
        musicaSlider.value = PlayerPrefs.GetFloat(AudioManager.MUSIC_KEY, 1f);
        effecSlider.value = PlayerPrefs.GetFloat(AudioManager.SFX_KEY, 1f);
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat(AudioManager.MASTER_KEY, masterSlider.value);
        PlayerPrefs.SetFloat(AudioManager.MUSIC_KEY, musicaSlider.value);
        PlayerPrefs.SetFloat(AudioManager.SFX_KEY, effecSlider.value);
    }

    private void SetMasterVolume(float value)
    {
        mixer.SetFloat(MIXER_MASTER, Mathf.Log10(value) * 20);
    }

    private void SetMusicVolume(float value)
    {
        mixer.SetFloat(MIXER_MUSIC, Mathf.Log10(value) * 20);
    }

    private void SetSFXVolume(float value)
    {
        mixer.SetFloat(MIXER_SFX, Mathf.Log10(value) * 20);
    }
}
