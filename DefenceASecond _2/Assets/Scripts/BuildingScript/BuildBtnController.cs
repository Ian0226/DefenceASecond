using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildBtnController : MonoBehaviour
{
    [SerializeField]
    private BuildManager buildManager;

    [SerializeField]
    private Image[] buildingImg;

    private GameObject nowBuild;

    [SerializeField]
    private PlayerHome playerHome;

    private void Start()
    {
        DisplayBuilding();
    }
    public void OpenBuildPanel()
    {
        buildManager.CloseNowClickPanel();
        buildManager.NowClickBuildPanel = this.gameObject.transform.GetChild(0).gameObject;
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }
    private void DisplayBuilding()
    {
        for(int i=0; i<buildingImg.Length;i++)
        {
            if(AllGameData.findPlayerSelectBuildingByIndex(i) != null)
            {
                if(this.gameObject.CompareTag("BuildBtnOnRoad") && AllGameData.findPlayerSelectBuildingByIndex(i).GetComponent<BuildingSuperClass>().BuildingType=="onRoad")
                {
                    buildingImg[i].sprite = AllGameData.findPlayerSelectBuildingByIndex(i).GetComponent<BuildingSuperClass>().BuildingImg;
                }
                else if(this.gameObject.CompareTag("BuildBtnBesideRoad") && AllGameData.findPlayerSelectBuildingByIndex(i).GetComponent<BuildingSuperClass>().BuildingType == "besideRoad")
                {
                    buildingImg[i].sprite = AllGameData.findPlayerSelectBuildingByIndex(i).GetComponent<BuildingSuperClass>().BuildingImg;
                }
                
            }
            if(buildingImg[i].sprite == null)
            {
                buildingImg[i].gameObject.SetActive(false);
            }
        }
    }
    public void Build(int i)
    {
        if(AllGameData.findPlayerSelectBuildingByIndex(i)!=null && nowBuild == null && playerHome.PlayerMoney >= AllGameData.findPlayerSelectBuildingByIndex(i).GetComponent<BuildingSuperClass>().Cost)
        {
            if(AllGameData.findPlayerSelectBuildingByIndex(i).GetComponent<BuildingSuperClass>().BuildingType == "onRoad")
            {
                nowBuild = Instantiate(AllGameData.findPlayerSelectBuildingByIndex(i), transform.position, Quaternion.identity);
                playerHome.PlayerMoney -= AllGameData.findPlayerSelectBuildingByIndex(i).GetComponent<BuildingSuperClass>().Cost;
            }
            else if(AllGameData.findPlayerSelectBuildingByIndex(i).gameObject.name == "DefenceTower")
            {
                nowBuild = Instantiate(AllGameData.findPlayerSelectBuildingByIndex(i), new Vector2(transform.position.x,transform.position.y+1), Quaternion.identity);
                playerHome.PlayerMoney -= AllGameData.findPlayerSelectBuildingByIndex(i).GetComponent<BuildingSuperClass>().Cost;
            }
            else
            {
                nowBuild = Instantiate(AllGameData.findPlayerSelectBuildingByIndex(i), transform.position, Quaternion.identity);
                playerHome.PlayerMoney -= AllGameData.findPlayerSelectBuildingByIndex(i).GetComponent<BuildingSuperClass>().Cost;
            }
        }
            
    }
    
}
