using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls what panels are shown based on the users selection.
/// Also animates the panel when selected.
/// </summary>

public class PanelGroup : MonoBehaviour
{
    public GameObject[] panels;
    public TabGroup tabGroup;
    public int panelIndex;

    private void Awake()
    {
        ShowCurrentPanel();
    }
    
    // Display selected panels
    void ShowCurrentPanel()
    {
        for (int i = 0; i < panels.Length; i++)
        {
            if (i == panelIndex)
            {
                panels[i].gameObject.SetActive(true);
                if (tabGroup.name == "Menu")
                {
                    TweenPanelOpen();
                }
            }
            else panels[i].gameObject.SetActive(false);
        }
    }

    public void SetPageIndex(int index)
    {
        panelIndex = index;
        ShowCurrentPanel();
    }

    public void TweenPanelOpen()
    {
        LeanTween.cancel(gameObject);
        transform.localScale = Vector3.zero;
        LeanTween.scale(gameObject, new Vector3(1, 1, 1), 0.3f).setIgnoreTimeScale(true);
    }
}
