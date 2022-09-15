using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Sets the characters transformation and rotation based on their target and their
/// characters information. As well triggers the animation if they are running
/// </summary>
public class Controller : MonoBehaviour
{
    public CharacterInformation characterController;
    public Vector3[] resetPos;
    public Image swirl;
    Animator animator;
    public Vector3 thing;
    public float rotateSpeed = 1;
    public bool running;
    public bool finished = false;
    public int rotateval = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
        //sets a destination on start to avoid the characters attempting to reach coordinates (0,0,0)
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.back, out hit, Mathf.Infinity))
        {
            thing = hit.transform.position;
        }

        if (characterController.active)
            swirl.color = Color.yellow;
        else
            swirl.color = Color.green;
    }

    void FixedUpdate()
    {
        //changes rotation based on input
        Quaternion rotate = Quaternion.Euler(new Vector3(0, rotateval, 0));
        transform.rotation = Quaternion.Slerp(transform.rotation, rotate, rotateSpeed * Time.deltaTime);


        //moves the character to destination if they are not already a set distance away
        //sets animation to running if they are moving and resets if they aren't
        if (Vector3.Distance(thing, transform.position) >= 2.5f && !finished)
        {
            transform.position = Vector3.Lerp(transform.position, thing, Time.deltaTime);
            animator.SetBool("Running", true);
            running = true;
        }
        else
        {
            animator.SetBool("Running", false);
            running = false;
        }

        //sets colour and direction based on if they are the active player
        if (characterController.active)
            characterController.direction = 1;
        else
            characterController.direction = -1;
    }
}
