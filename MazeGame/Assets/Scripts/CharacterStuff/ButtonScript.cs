using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Checks if the player is in front of the button and has stopped moving. 
/// then based on input will activate a gate
/// </summary>
public class ButtonScript : MonoBehaviour
{
    public Gate gate;

    private void Update()
    {
        //Sends raycast forward and checks if object hit is player
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 2))
        {
            Controller hitchar = hit.transform.gameObject.GetComponent<Controller>();
            if (hitchar && Input.GetKeyDown(KeyCode.E) && !hitchar.running)
            {
                Activate();
                
            }
        }
        //if reset button is pressed, returns gate to starting position
        if (Input.GetKeyDown(KeyCode.R))
        {
            gate.Reset();
        }
    }

    public void Activate()
    {
        //if there is a gate referenced, tells it to open
        if (gate.oldGate)
            gate.activate(gate.oldGate);
    }

}
