using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Use on Start Scene,Set screen resolution.
/// </summary>
public class StartGameSet : MonoBehaviour
{
    private void Awake()
    {
        //獲取設定當前螢屏分辯率 
        //Resolution[] resolutions = Screen.resolutions;
        //設定當前解析度 
        Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);

        //Screen.fullScreen = true;  //設定成全屏
        //this.gameObject.GetComponent<RectTransform>().
    }
}
