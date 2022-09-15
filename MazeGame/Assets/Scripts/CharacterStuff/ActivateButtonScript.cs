using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 
/// </summary>
public class ActivateButtonScript : MonoBehaviour
{
    public ButtonScript[] buttons;
    public CharactersController controller;

    public void Activate()
    {
        foreach (ButtonScript button in buttons)
        {
            RaycastHit hit;
            if (Physics.Raycast(button.transform.position, button.transform.forward, out hit, 2))
            {
                Controller hitchar = hit.transform.gameObject.GetComponent<Controller>();
                if (hitchar && !hitchar.running)
                {
                    button.Activate();
                }
            }
        }
    }

    public void Reset()
    {
        controller.Reset();
        foreach (ButtonScript button in buttons)
        {
            button.gate.Reset();
        }
    }
}
