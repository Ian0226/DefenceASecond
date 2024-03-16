using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Component on BuildingCanvas in the scene.BuildBtnController use this script.
/// </summary>
public class BuildManager : MonoBehaviour
{
    public List<GameObject> allBuildBtnInGame = new List<GameObject>();

    private GameObject nowClickBuildPanel;
    public GameObject NowClickBuildPanel
    {
        get { return nowClickBuildPanel; }
        set { nowClickBuildPanel = value; }
    }

    public void CloseNowClickPanel()
    {
        if (nowClickBuildPanel != null)
            nowClickBuildPanel.SetActive(false);
    }
    
}
