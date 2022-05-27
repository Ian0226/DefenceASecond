using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetManager : MonoBehaviour
{
    public Text windowStateTxt;
    private int stateValue;

    private void Awake()
    {
        stateValue = 1;
    }
    public void ChangeWindowState()
    {
        if(stateValue == 1)
        {
            stateValue++;
        }
        else
        {
            stateValue--;
        }
    }
    private void Update()
    {
        if(windowStateTxt != null)
            DisplayState();
    }
    private void DisplayState()
    {
        switch (stateValue)
        {
            case 1:
                windowStateTxt.text = "¥þ¿Ã¹õ";
                if(!Screen.fullScreen)
                {
                    Screen.fullScreen = true;
                }
                break;
            case 2:
                windowStateTxt.text = "µøµ¡¼Ò¦¡";
                if(Screen.fullScreen)
                {
                    Screen.fullScreen = !Screen.fullScreen;
                }
                break;
        }
    }
}
