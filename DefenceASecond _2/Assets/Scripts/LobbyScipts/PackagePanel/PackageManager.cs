using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handle package system,is a component on PackagePanel UI gameObject.
/// </summary>
public class PackageManager : MonoBehaviour
{
    [SerializeField]
    private GameObject itemGroupPanel;

    /// <summary>
    /// When package panel open,display item on it.
    /// </summary>
    private void OnEnable()
    {
        ClearAllObj();
        for (int i=0;i< AllGameData.getPlayerItems().Count;i++)
        {
            //Debug.Log(AllGameData.getPlayerItemByIndex(i));
            GameObject itemObj =  Instantiate(AllGameData.getPlayerItemByIndex(i));
            itemObj.transform.SetParent(itemGroupPanel.transform);
        }
    }

    /// <summary>
    /// Clear all object on panel first when panel open.
    /// </summary>
    private void ClearAllObj()
    {
        for (int i = 0; i < itemGroupPanel.transform.childCount; i++)
        {
            Destroy(itemGroupPanel.transform.GetChild(i).gameObject);
        }
    }
        
    
}
