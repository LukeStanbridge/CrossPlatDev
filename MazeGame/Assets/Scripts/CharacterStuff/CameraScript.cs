using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// used to set the cameras positions to the current checkpoint
/// </summary>
public class CameraScript : MonoBehaviour
{
    public Vector3[] Pos;
    public void ChangePos(int checkpoint)
    {
        transform.position = Pos[checkpoint];
    }
}
