using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Component on LobbyManager,provide some operations for LobbyScene's button.
/// </summary>
public class LobbyPanelController : MonoBehaviour
{
    private GameObject nowSelectLevel;
    public GameObject NowSelectLevel
    {
        get { return nowSelectLevel; }
    }

    /// <summary>
    /// Use on Level buttons event.
    /// </summary>
    /// <param name="panel">Level information panel.</param>
    public void ShowClickPanel(GameObject panel)
    {
        panel.SetActive(true);
    }

    /// <summary>
    /// Use on ReturnLobby button.
    /// </summary>
    /// <param name="panel">The panel you want to close.</param>
    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }

    /// <summary>
    /// Use on Level buttons event,is use to set now select level,make player into correct level.
    /// </summary>
    /// <param name="level">The level correspond this button.</param>
    public void SetNowSelectLevel(GameObject level)
    {
        nowSelectLevel = level;
        Debug.Log(level);
    }

    /// <summary>
    /// Use on IntoGame button in LevelInfoPanel,Load now selected level.
    /// </summary>
    public void LoadLevel()
    {
        if(nowSelectLevel != null)
            Application.LoadLevel(nowSelectLevel.name);
    }

}
