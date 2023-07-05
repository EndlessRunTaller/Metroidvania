using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] AudioMixer mixer;
    [SerializeField] AudioSource grafitti;
    [SerializeField] List<AudioClip> Graffiti = new List<AudioClip>();

    public const string MASTER_KEY = "master";
    public const string MUSIC_KEY = "music";
    public const string SFX_KEY = "SFX";

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void HacerGraffiti()
    {
        AudioClip clip = Graffiti[Random.Range(0, Graffiti.Count)];
        grafitti.PlayOneShot(clip);
    }

    void LoadVolume() //Volume saved in volumeSetting.cs
    {
        float MasterVolume = PlayerPrefs.GetFloat(MASTER_KEY, 1f);
        float MusicVolume = PlayerPrefs.GetFloat(MUSIC_KEY, 1f);
        float SFXVolume = PlayerPrefs.GetFloat(SFX_KEY, 1f);
        mixer.SetFloat(VolumeSettings.MIXER_MASTER, Mathf.Log10(MasterVolume) * 20);
        mixer.SetFloat(VolumeSettings.MIXER_MUSIC, Mathf.Log10(MusicVolume) * 20);
        mixer.SetFloat(VolumeSettings.MIXER_SFX, Mathf.Log10(SFXVolume) * 20);
    }
}
