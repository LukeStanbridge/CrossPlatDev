using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Sends the relevant information to each character based on player input.
/// Includes functions such as switching the active player, Reseting the game,
/// and checks if any of the characters are still moving before letting them send out a raycast
/// </summary>
public class CharactersController : MonoBehaviour
{
    //used to control both characters through the same inputs
    public Controller[] characters;
    public CameraScript[] cameras;
    public Gate[] gates;
    public GameHud gameMenu;
    public int cp;
    public int finished = 0;
    public bool check = false;
    float fwd;
    float hor;

    void Update()
    {
        //cycles through each character to control both at the same time
        for (int i = 0; i < characters.Length; i++)
        {
            RaycastHit hit;
            //checks if both characters are standing still before being able to give another input
            if (RunCheck())
            {
                if (fwd != 0)
                {
                    //send a raycast in given direction based on input
                    if (Physics.Raycast(characters[i].transform.position, fwd * Vector3.forward 
                        * characters[i].characterController.direction,
                        out hit, Mathf.Infinity))
                    {
                        //sets the characters target destination and rotation
                        characters[i].thing = hit.transform.position;
                        characters[i].rotateval = (int)fwd * 90;
                    }
                }

                if (hor != 0)
                {
                    //send a raycast in given direction based on input and if the character is active
                    if (Physics.Raycast(characters[i].transform.position,
                        hor * Vector3.right * characters[i].characterController.direction, out hit, Mathf.Infinity))
                    {
                        //sets the characters target destination and rotation
                        characters[i].thing = hit.transform.position;
                        if (hor * characters[i].characterController.direction > 0)
                            characters[i].rotateval = 180;
                        else
                            characters[i].rotateval = 0;
                    }
                }
            }
            //switches which character moves normally
            if (Input.GetKeyDown(KeyCode.Space))
            {
                    characters[i].characterController.active = !characters[i].characterController.active;
            }
            //resets the characters positions based on last checkpoint hit
            if (Input.GetKeyDown(KeyCode.R))
            {
                Reset();
                foreach (CameraScript camera in cameras)
                {
                    camera.ChangePos(cp);
                }
            }
        }

        if(finished == characters.Length)
        {
            finished = 0;
            cp++;

            foreach (CameraScript camera in cameras)
            {
                camera.ChangePos(cp);
            }
            foreach (Controller character in characters)
            {
                character.thing = character.resetPos[cp];
                character.finished = false;
            }
            foreach (Gate gate in gates)
            {
                gate.activate(gate.newGate);
                gate.StartCoroutine(gate.MoveNext());
            }
        }

        //detects vertical and horizontal input (can be WASD, arrow keys or other) and converts it to a float
        fwd = Input.GetAxisRaw("Vertical");
        hor = Input.GetAxisRaw("Horizontal");
    }

    public void Switch()
    {
        for(int i = 0; i < characters.Length; i++)
        characters[i].characterController.active = !characters[i].characterController.active;
    }
    public void Reset()
    {
        for(int i = 0; i < characters.Length; i++)
        {
            characters[i].transform.position = characters[i].resetPos[cp];
            characters[i].thing = characters[i].resetPos[cp];
            characters[i].finished = false;
            finished = 0;
        }
    }

    public void FullReset()
    {
        for (int i = 0; i < characters.Length; i++)
        {
            cp = 0;
            characters[i].transform.position = characters[i].resetPos[cp];
            characters[i].thing = characters[i].resetPos[cp];
            characters[i].finished = false;
            finished = 0;
        }
        for(int i = 0; i < cameras.Length; i++)
        {
            cameras[i].ChangePos(cp);
        }
        gameMenu.Reset();
        gameMenu.m_resets = 0;
    }

    //used to change the control variables for mobile
    public void ChangeDirection(int direction)
    {
        switch (direction)
        {
            case 0:
                fwd = 1;
                break;
            case 180:
                fwd = -1;
                break;
            case 90:
                hor = 1;
                break;
            case 270:
                hor = -1;
                break;
        }
    }

    //cycles through each character to check if both are done moving
    public bool RunCheck()
    {
        for (int i = 0; i < characters.Length; i++)
        {
            if (characters[i].running)
                return false;
        }
        return true;
    }
}