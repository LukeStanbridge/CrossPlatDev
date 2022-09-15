using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Controls for all the settings in the Main Menu.
/// </summary>
/// <remarks>
/// Adjust volume and associated slider, mute audio, fullscreen option, resolution option, 
/// mute option and quality options.
/// </remarks>

public class SettingsUI : MonoBehaviour
{
    public Settings settings;
    public FloatEditor musicVolume;

    public Slider musicVolume1;
    public AudioSource backgorundMusic;

    public TMP_Dropdown resDropdown;
    Resolution[] resolutions;

    // Update settings sliders with values
    private void Start()
    {
        // Audio slider controls
        Load();

        musicVolume1.onValueChanged.AddListener(OnMusicVolumeChanged);

        if (musicVolume)
        {
            musicVolume.floatValue = settings.musicVolume;
            musicVolume.onValueChanged.AddListener((float value) =>
            {
                settings.musicVolume = value;
            });
        }

        //Add screen resolutions
        resolutions = Screen.resolutions;
        resDropdown.ClearOptions();

        List<string> resList = new List<string>();

        int currentResolution = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            resList.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height) currentResolution = i;
        }

        resDropdown.AddOptions(resList);
        resDropdown.value = currentResolution;
        resDropdown.RefreshShownValue();
    }

    public void OnMusicVolumeChanged(float volume)
    {
        settings.musicVolume = volume;
        backgorundMusic.volume = settings.musicVolume / 100;
        Save();
    }

    private void Load()
    {
        musicVolume1.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", musicVolume1.value);
    }

    // Quality settings
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    // Full screen option
    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    // Screen resolution options
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    // Mute audio options
    public void SetMute(bool mute)
    {
        if(mute)
        {
            AudioListener.volume = 0;
        }
        else
        {
            AudioListener.volume = 1;
        }
    }    
}
