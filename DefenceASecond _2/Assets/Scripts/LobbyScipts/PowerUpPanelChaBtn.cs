using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPanelChaBtn : MonoBehaviour
{
    public int numberInList;
    public void OnClick()
    {
        if(PowerUpPanelManager.NowSelectChaNumber < 0)
        {
            PowerUpPanelManager.NowSelectChaNumber = numberInList;
        }
        else if(PowerUpPanelManager.NowSelectChaNumber >= 0 && PowerUpPanelManager.NowSelectChaNumber != numberInList)
        {
            PowerUpPanelManager.NowSelectChaNumber = numberInList;
        }
        else if(PowerUpPanelManager.NowSelectChaNumber >= 0 && PowerUpPanelManager.NowSelectChaNumber == numberInList)
        {
            PowerUpPanelManager.NowSelectChaNumber = -1;
        }
        Debug.Log(PowerUpPanelManager.NowSelectChaNumber);
    }
}
