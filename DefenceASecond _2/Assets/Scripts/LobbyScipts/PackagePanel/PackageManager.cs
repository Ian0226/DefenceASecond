using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageManager : MonoBehaviour
{
    [SerializeField]
    private GameObject itemGroupPanel;


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
    private void ClearAllObj()
    {
        for (int i = 0; i < itemGroupPanel.transform.childCount; i++)
        {
            Destroy(itemGroupPanel.transform.GetChild(i).gameObject);
        }
    }
        
    
}
