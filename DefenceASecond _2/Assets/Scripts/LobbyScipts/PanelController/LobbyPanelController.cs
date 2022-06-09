using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyPanelController : MonoBehaviour
{
    private GameObject nowSelectLevel;
    public GameObject NowSelectLevel
    {
        get { return nowSelectLevel; }
    }
    public void ShowClickPanel(GameObject panel)
    {
        panel.SetActive(true);
    }
    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }
    public void SetNowSelectLevel(GameObject level)
    {
        nowSelectLevel = level;
        Debug.Log(level);
    }
    public void LoadLevel()
    {
        if(nowSelectLevel != null)
            Application.LoadLevel(nowSelectLevel.name);
    }

}
