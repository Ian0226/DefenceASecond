using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamPanelController : MonoBehaviour
{
    public GameObject allyPanel;
    public GameObject buildingPanel;
    
    public void ChangeUnitType(GameObject changePanel) 
    {
        allyPanel.SetActive(false);
        buildingPanel.SetActive(false);

        changePanel.SetActive(true);
    }
    
}
