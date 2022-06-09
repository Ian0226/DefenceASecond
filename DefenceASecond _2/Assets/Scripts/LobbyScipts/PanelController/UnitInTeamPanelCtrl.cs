using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitInTeamPanelCtrl : MonoBehaviour
{
    public GameObject[] playerSelectUnitBtn;
    public GameObject[] playerSelectUnitType;
    public GameObject[] playerSelectUnitCost;

    

    public GameObject unitBlock;
    [SerializeField]
    private List<GameObject> unitBlockList = new List<GameObject>();
    public GameObject showUnitPanel;
    [SerializeField]
    private List<GameObject> allUnitList = new List<GameObject>();
    public static bool nowClickCondition = false;
    public static GameObject registerNowClickUnit;
    private string allyType = "All";
    private GameObject nowClickTypeBtn = null;

    private void OnEnable()
    {
        CleanUnitBlock();
        GetUnitFromStorage();
        DisplayUnit();
    }
    private void Update()
    {
        DisplayUnitOnSelectBtn();
    }
    private void DisplayUnit()
    {
        unitBlockList.Clear();
        for (int i=0;i<allUnitList.Count;i++)
        {
            unitBlockList.Add(Instantiate(unitBlock));
            unitBlockList[i].transform.SetParent(showUnitPanel.transform);
            unitBlockList[i].GetComponent<UnitBlockController>().NowUnit = allUnitList[i].gameObject;
        }
        
    }
    private void GetUnitFromStorage()
    {
        if (this.gameObject.name == "AllyPanel")
        {
            allUnitList.Clear();
            allUnitList.AddRange(AllGameData.getAllAllies());
        }
        else
        {
            allUnitList.Clear();
            allUnitList.AddRange(AllGameData.getAllBuildings());
        }
    }

    public void SetUnitIntoplayerSelect(int i)
    {
        
        if (this.gameObject.name == "AllyPanel")
        {
            if (nowClickCondition == true && registerNowClickUnit != null)
            {
                
                AllGameData.setPlayerSelectAllyByIndex(i, registerNowClickUnit.gameObject.GetComponent<UnitBlockController>().NowUnit);
            }
        }
        else
        {
            
            if (nowClickCondition == true && registerNowClickUnit != null)
            {
                AllGameData.setPlayerSelectBuildingByIndex(i, registerNowClickUnit.gameObject.GetComponent<UnitBlockController>().NowUnit);
            }
        }
        
        
    }
    private void DisplayUnitOnSelectBtn()
    {
        if(this.gameObject.name == "AllyPanel")
        {
            for (int i = 0; i < playerSelectUnitBtn.Length; i++)
            {

                if (AllGameData.findPlayerSelectAllyByIndex(i) != null)
                {
                    playerSelectUnitBtn[i].transform.GetChild(0).GetComponent<Image>().sprite =
                        AllGameData.findPlayerSelectAllyByIndex(i).GetComponent<AllySuperClass>().CharacterBigHead;
                    if(playerSelectUnitBtn[i].transform.GetChild(0).GetComponent<Image>().sprite != null)
                    {
                        playerSelectUnitBtn[i].transform.GetChild(0).gameObject.SetActive(true);
                    }
                    playerSelectUnitType[i].GetComponent<Image>().sprite = 
                        AllGameData.findPlayerSelectAllyByIndex(i).GetComponent<AllySuperClass>().CharacterTypeImg;
                    if(playerSelectUnitType[i].GetComponent<Image>().sprite != null)
                    {
                        playerSelectUnitType[i].gameObject.SetActive(true);
                    }
                    playerSelectUnitCost[i].GetComponent<Text>().text = 
                        AllGameData.findPlayerSelectAllyByIndex(i).GetComponent<AllySuperClass>().Cost.ToString();
                }
                else
                {
                    continue;
                }

            }
        }
        else
        {
            for (int i = 0; i < playerSelectUnitBtn.Length; i++)
            {
                if (AllGameData.findPlayerSelectBuildingByIndex(i) != null)
                {
                    playerSelectUnitType[i].SetActive(false);
                    playerSelectUnitBtn[i].transform.GetChild(0).GetComponent<Image>().sprite =
                        AllGameData.findPlayerSelectBuildingByIndex(i).GetComponent<BuildingSuperClass>().BuildingImg;
                    if (playerSelectUnitBtn[i].transform.GetChild(0).GetComponent<Image>().sprite != null)
                    {
                        playerSelectUnitBtn[i].transform.GetChild(0).gameObject.SetActive(true);
                    }
                    
                    playerSelectUnitCost[i].GetComponent<Text>().text =
                        AllGameData.findPlayerSelectBuildingByIndex(i).GetComponent<BuildingSuperClass>().Cost.ToString();
                }
                else
                {
                    continue;
                }
            }
        }
    }
    public void ChangeAllyType(string unitType)
    {
        allUnitList.Clear();
        CleanUnitBlock();
        foreach (GameObject ally in AllGameData.getAllAllies())
        {
            if (ally.GetComponent<AllySuperClass>().CharacterType == unitType)
            {
                allUnitList.Add(ally);
            }
        }
        DisplayUnit();
    }
    public void ReDisplayAllAllies(GameObject nowClickBtn)
    {
        if(nowClickTypeBtn != nowClickBtn)
        {
            nowClickTypeBtn = nowClickBtn;
        }
        else
        {
            nowClickTypeBtn = null;
            allUnitList.Clear();
            CleanUnitBlock();
            GetUnitFromStorage();
            DisplayUnit();
        }
    }
    private void CleanUnitBlock()
    {
        for(int i=0; i<showUnitPanel.transform.childCount; i++)
        {
            Destroy(showUnitPanel.transform.GetChild(i).gameObject);
        }
    }
}
