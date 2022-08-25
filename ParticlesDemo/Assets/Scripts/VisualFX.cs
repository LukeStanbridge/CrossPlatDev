using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "VisualFX", menuName = "VisualFXSystem/VisualFX")]
public class VisualFX : ScriptableObject
{
    public GameObject prefab;
    public bool attach;
    public bool orient;

    public GameObject Spawn(Transform t)
    {
        // do we want to be childed and follow the object?
        Transform parent = attach ? t : null;

        // do we want to match the spawn points orientation or not?
        Quaternion orientation = orient ? t.rotation : Quaternion.identity;

        // create a copy of the prefab at the spawnpoint with the desired settings
        return Instantiate(prefab, t.position, orientation, parent);
    }
}
