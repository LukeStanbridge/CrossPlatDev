using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Rotates the coin game object over time. Also disapears when the players touches it and adds
/// to the HUDs coin count
/// </summary>
public class Coin : MonoBehaviour
{
    public GameHud gameHud;
    //checks if the colliding object is a player before updating hud and disabling itself
    private void OnTriggerEnter(Collider other)
    {
        Controller player = other.GetComponent<Controller>();
        if (player)
        {
            gameHud.m_coins++;
            gameObject.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        //rotates every 0.2 seconds
        transform.Rotate(Vector3.up * 50 * Time.deltaTime);
    }
}
