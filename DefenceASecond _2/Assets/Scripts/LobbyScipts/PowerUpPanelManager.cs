using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpPanelManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> pyCharacters = new List<GameObject>();
    private GameObject nowSelectCha;

    public GameObject unitBlock;

    //放遊戲中UI物件的變數
    [Header("顯示東西的框框")]
    public GameObject characterPanel;
    public GameObject materialsPanel;
    public GameObject chaUpgradeValuePanel;

    public void OnEnable()
    {
        pyCharacters = AllGameData.getAllAllies();
        for(int i=0;i<3;i++)
        {
            Instantiate(unitBlock).transform.SetParent(characterPanel.transform);
        }
    }
    private void Update()
    {
        
    }
    private void Upgrade()
    {
        if(nowSelectCha)
        {
            //nowSelectCha.GetComponent<AllySuperClass>().Damage += 10;
        }
    }
    private void DisplayChaValue()
    {

    }
}
