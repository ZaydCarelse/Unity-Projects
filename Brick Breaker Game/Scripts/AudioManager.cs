using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Components:")]
    public AudioMixer audioMixer;
    public AudioSource music;

    [Header("Switches:")]
    public bool isMute = false;

    [Header("Sliders:")]
    public Slider volumeSlider;
    public Slider musicSlider;
    public Slider effectsSlider;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("MasterVolume", 0.75f);
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
        effectsSlider.value = PlayerPrefs.GetFloat("EffectsVolume", 0.75f);
    }

    void Update()
    {
        if (!isMute)
        {
            audioMixer.SetFloat("Master", volumeSlider.value);
        }
        else
        {
            audioMixer.SetFloat("Master", -80);
        }
    }

    public void SetMasterLevel()
    {
        float volumeValue = volumeSlider.value;
        audioMixer.SetFloat("Master", volumeValue);
        PlayerPrefs.SetFloat("MasterVolume", volumeValue);
    }

    public void SetMusicLevel()
    {
        float musicValue = musicSlider.value;
        audioMixer.SetFloat("Music", musicValue);
        PlayerPrefs.SetFloat("MusicVolume", musicValue);
    }

    public void SetEffectsLevel()
    {
        float effectsValue = effectsSlider.value;
        audioMixer.SetFloat("Effects", effectsValue);
        PlayerPrefs.SetFloat("EffectsVolume", effectsValue);
    }

}