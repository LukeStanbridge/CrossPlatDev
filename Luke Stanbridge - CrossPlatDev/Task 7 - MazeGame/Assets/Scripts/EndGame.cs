using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Script put on game object at the end of level to show the player has finished
/// and activates the menu to let them quit, restart or go back to the main menu
/// </summary>

public class EndGame : MonoBehaviour
{
    public CharactersController cc;
    public GameOptionsMenu menu;

    private void OnTriggerEnter(Collider other)
    {
        Controller control = other.GetComponent<Controller>();
        if(control)
        {
            control.finished = true;
            if (cc.finished > 0)
            {
                menu.EndGame();
            }
            else cc.finished++;
        }
    }
}
