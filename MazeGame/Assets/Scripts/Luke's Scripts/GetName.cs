using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Sets button name in game to name of parent game object in Unity
/// </summary>

public class GetName : MonoBehaviour
{
    public GameObject parent;
    public TextMeshProUGUI textMeshPro;

    void Awake()
    {
        //Name button according to game object name
        var parentName = transform.parent.name;
        textMeshPro.text = parentName;
    }
}
