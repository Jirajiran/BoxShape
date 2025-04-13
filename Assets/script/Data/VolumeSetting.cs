using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSetting : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider SFXSlider;


    private void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
            SetSFXVolume();
        }
        SetMusicVolume();
    }
    public void SetMusicVolume()
    {
        float Volume = musicSlider.value;
        myMixer.SetFloat("MusicHere", Mathf.Log10(Volume)*20);
        PlayerPrefs.SetFloat("musicVolume", Volume);
    }
    public void SetSFXVolume()
    {
        float Volume = SFXSlider.value;
        myMixer.SetFloat("SFXHere", Mathf.Log10(Volume) * 20);
        PlayerPrefs.SetFloat("SFXVolume", Volume);
    }
    private void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        SetMusicVolume();
        SetSFXVolume();
    }
}
