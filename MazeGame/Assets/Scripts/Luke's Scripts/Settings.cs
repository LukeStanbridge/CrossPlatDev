using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

/// <summary>
/// Allows for developer to edit music volume in inspector.
/// Adds RGB effects to Title in Main Menu.
/// </summary>

public class Settings : MonoBehaviour
{
    // Set slider values in inspector

    public float musicVolume;
    public float soundFxVolume;

    public bool stereo;

    public TextMeshProUGUI title;

    public void Update()
    {
        // Changes RGB glow of main title
        title.fontMaterial.SetColor(ShaderUtilities.ID_GlowColor, Color.HSVToRGB(Mathf.Repeat(Time.time * 0.1f, 1), 1f, 1f));
    }
}
