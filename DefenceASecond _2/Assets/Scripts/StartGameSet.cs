using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGameSet : MonoBehaviour
{
    private void Awake()
    {
        //����]�w��e�ë̤��G�v 
        //Resolution[] resolutions = Screen.resolutions;
        //�]�w��e�ѪR�� 
        Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);

        //Screen.fullScreen = true;  //�]�w������
        //this.gameObject.GetComponent<RectTransform>().
    }
}
