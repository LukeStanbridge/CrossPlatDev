using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

 /// <summary>
 /// This script controls the movement of the backgorund cubes in the 
 /// Main Menu using LeanTween.
 /// </summary>
 
public class EasingManager : MonoBehaviour
{
    public GameObject cube1;
    public GameObject cube2;
    public GameObject cube3;
    public GameObject cube4;
    public GameObject cube5;
    public GameObject cube6;
    public GameObject cube7;
    public GameObject cube8;

    // Start is called before the first frame update
    void Start()
    {
        // Accross Screen
        LeanTween.moveX(cube1, -0.03f, 4).setEaseInOutBack().setLoopPingPong();
        LeanTween.moveX(cube2, -0.03f, 4).setEaseOutBounce().setLoopPingPong();

        //Up and down
        LeanTween.moveZ(cube3, -0.03f, 4).setEaseInOutBack().setLoopPingPong();
        LeanTween.moveZ(cube4, -0.03f, 4).setEaseOutBounce().setLoopPingPong();

        //Rotate
        LeanTween.rotateY(cube5, -180, 1).setEaseInOutSine().setLoopPingPong();
        LeanTween.rotateY(cube6, 180, 1).setEaseInOutSine().setLoopPingPong();

        //Worm
        LeanTween.rotateY(cube7, 180, 1).setEaseLinear().setLoopPingPong();
        LeanTween.scaleX(cube7, 40, 3).setEaseInOutCubic().setLoopPingPong();
        LeanTween.scaleZ(cube7, 40, 3).setEaseInOutCubic().setLoopPingPong();

        LeanTween.rotateY(cube8, -180, 2).setEaseLinear().setLoopPingPong();
        LeanTween.scaleX(cube8, 40, 1).setEaseInOutCubic().setLoopPingPong();
        LeanTween.scaleZ(cube8, 40, 1).setEaseInOutCubic().setLoopPingPong();
    }
}
