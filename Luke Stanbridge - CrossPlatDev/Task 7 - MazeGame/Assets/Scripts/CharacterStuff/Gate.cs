using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Used to control the gates. Sets one gameobject as the "active" one and moves it up. 
/// allowing the player to pass through.
/// if the player comes in contact with the middle object, stops them from moving until
/// the other player is in the other middle object
/// then gets the characters to move to the next area
/// </summary>
public class Gate : MonoBehaviour
{
    public CharactersController charCon;
    public Transform newGate;
    public Transform oldGate;
    [SerializeField]
    Transform active = null;

    //detects colliding object is player before setting the finished boolean on them to true,
    //disabling their movement until the other character is finished
    private void OnTriggerEnter(Collider other)
    {
        Controller control = other.GetComponent<Controller>();
        if (control)
        {
            control.transform.position = transform.position;
            charCon.finished++;
            control.finished = true;
        }
    }

    public void activate(Transform gate)
    {
        active = gate;
    }

    public void Reset()
    {
        active = null;
        if (newGate.transform.position.y <= -6.5f)
            newGate.transform.position += new Vector3(0, 5, 0);

        if (oldGate.transform.position.y <= -6.5f)
            oldGate.transform.position += new Vector3(0, 5, 0);
    }

    void FixedUpdate()
    {
        if (active)
        {
            if (active.transform.position.y > -6.5f)
            {
                active.transform.position += new Vector3(0,
                    -6.5f, 0) * Time.deltaTime;
            }
            else active = null;
        }
    }

    public IEnumerator MoveNext()
    {
        yield return new WaitForSeconds(2);
        Reset();
    }
}