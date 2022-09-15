using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
/// <summary>
/// All UI elements visable while while the game state is running
/// </summary>
public class GameHud : MonoBehaviour
{
    public TMP_Text Timer;
    public TMP_Text Coins;
    public TMP_Text Resets;
    public GameObject MobControls;

    public RawImage image;

    public float m_timer;
    public int m_coins;
    public int m_resets;
    public Coin[] coins;
    public CharactersController controller;

    private void Start()
    {
        if (Application.platform != RuntimePlatform.Android)
        {
            MobControls.SetActive(false);
        }

        m_timer = 0;
        m_coins = 0;
        m_resets = 0;

    }

    private void Update()
    {
        m_timer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reset();
        }

        for (int i = 0; i < controller.characters.Length; i++)
        {
            if (controller.characters[i].characterController.active)
                image.color = controller.characters[i].swirl.color;
        }
        Stats();
    }

    public void Reset()
    {
        m_timer = 0;
        m_coins = 0;
        m_resets++;
        foreach (Coin coin in coins) coin.gameObject.SetActive(true);
    }

    void Stats()
    {
        Timer.text = "Timer: ";
        Timer.text += m_timer.ToString("F2");

        Coins.text = "Coins: ";
        Coins.text += m_coins.ToString();

        Resets.text = "Resets: ";
        Resets.text += m_resets.ToString();
    }


}
