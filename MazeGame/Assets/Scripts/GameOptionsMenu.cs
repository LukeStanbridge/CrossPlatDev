using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;
/// <summary>
/// This Controls the Menus within the game world and all their variables
/// </summary>
public class GameOptionsMenu : MonoBehaviour
{
    public TMP_Text volume;
    public Slider volumeSlider;

    public GameObject options;
    public GameObject GameHud;
    public GameObject endGameScreen;

    public GameObject mute;
    Image muteImage;

    float storeVolume = 50f;
    float volumeNumber;

    bool isMuted = false;
    public CharactersController cc;

    private void Start()
    {
        GameHud.gameObject.SetActive(true);
        options.gameObject.SetActive(false);
        endGameScreen.SetActive(false);
        muteImage = mute.GetComponent<Image>();
        muteImage.enabled = false;
    }

    public void Volume() // sets the volume number equal to the slider value
    {
        volumeNumber = volumeSlider.value;
        volume.text = "Volume: " + volumeNumber.ToString();

        // if volume is zero, mute. Other wise unmute
        if(volumeSlider.value == 0)
        {
            muteImage.enabled = true;
            isMuted = true;
        }
        else
        {
            muteImage.enabled = false;
            isMuted = false;
        }
    }

    public void Mute()
    {
        // sets the mute UI object on and off
        if(muteImage.isActiveAndEnabled)
        {
            muteImage.enabled = false;
            isMuted = false;
        }
        else
        {
            muteImage.enabled = true;
            isMuted = true;
        }

        if (isMuted)
        {
            storeVolume = volumeSlider.value;
            volumeSlider.value = 0f;
        }
        else
            volumeSlider.value = storeVolume;
    }

    public void SwapBetweenGameMenus()
    {
        // sets the menus on and off so they cant both be active at once
        GameHud.gameObject.SetActive(!GameHud.gameObject.activeSelf);
        options.gameObject.SetActive(!options.gameObject.activeSelf);
        
        // when the game is active time is running
        if(GameHud.activeSelf == true)
        {
            Time.timeScale = 1.0f;
        }
        else
            Time.timeScale = 0.0f;
    }

    public void ToMainMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }

    public void RestartGame()
    {
        endGameScreen.gameObject.SetActive(false);
        options.gameObject.SetActive(false);
        GameHud.gameObject.SetActive(true);
        cc.FullReset();
    }

    public void EndGame()
    {
        endGameScreen.gameObject.SetActive(true);
        options.gameObject.SetActive(false);
        GameHud.gameObject.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
