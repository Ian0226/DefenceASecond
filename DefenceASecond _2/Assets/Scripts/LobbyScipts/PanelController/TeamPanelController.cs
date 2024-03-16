using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Component on TeamPanel UI gameObject.
/// </summary>
public class TeamPanelController : MonoBehaviour
{
    public GameObject allyPanel;
    public GameObject buildingPanel;

    /// <summary>
    /// Use on ChangeBuildingBtn or ChangeAllyBtn,is use to change now display unit type.
    /// </summary>
    /// <param name="changePanel">The panel you want to change.</param>
    public void ChangeUnitType(GameObject changePanel) 
    {
        allyPanel.SetActive(false);
        buildingPanel.SetActive(false);

        changePanel.SetActive(true);
    }
    
}
