using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// presets information for the characters to use for to determine direction
/// </summary>
[CreateAssetMenu(menuName = ("Character"))]
public class CharacterInformation : ScriptableObject
{
    //information used to determine which character controls normally
    public int direction;
    public bool active;
}
