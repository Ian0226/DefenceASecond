using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UnitBlockController : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private GameObject nowUnit;
    public GameObject NowUnit
    {
        get { return nowUnit; }
        set { nowUnit = value; }
    }
    public GameObject unitImage;
    public GameObject unitType;
    public Text unitCost;
    private void Update()
    {
        if(nowUnit.tag == "Ally")
        {
            if (nowUnit != null)
            {
                GetUnitInfo(nowUnit.tag);
                unitImage.SetActive(true);
                unitType.SetActive(true);
            }
            else
            {
                unitImage.SetActive(false);
                unitType.SetActive(false);
                unitCost.text = "";
            }
        }
        else if(nowUnit.tag == "Building")
        {
            if (nowUnit != null)
            {
                GetUnitInfo(nowUnit.tag);
                unitImage.SetActive(true);
                unitType.SetActive(false);
            }
            else
            {
                unitImage.SetActive(false);
                unitCost.text = "";
            }
        }
        
            

        
    }
    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if(UnitInTeamPanelCtrl.nowClickCondition == false && UnitInTeamPanelCtrl.registerNowClickUnit == null)
        {
            UnitInTeamPanelCtrl.nowClickCondition = true;
            UnitInTeamPanelCtrl.registerNowClickUnit = this.gameObject;
        }
        else if(UnitInTeamPanelCtrl.nowClickCondition == true && UnitInTeamPanelCtrl.registerNowClickUnit == this.gameObject)
        {
            UnitInTeamPanelCtrl.nowClickCondition = false;
            UnitInTeamPanelCtrl.registerNowClickUnit = null;
        }
        else if(UnitInTeamPanelCtrl.nowClickCondition == true && UnitInTeamPanelCtrl.registerNowClickUnit != this.gameObject)
        {
            UnitInTeamPanelCtrl.registerNowClickUnit = this.gameObject;
        }
    }
    private void GetUnitInfo(string unitTypeString)
    {
        switch(unitTypeString)
        {
            case "Ally":
                unitImage.GetComponent<Image>().sprite = nowUnit.GetComponent<AllySuperClass>().CharacterBigHead;
                unitType.GetComponent<Image>().sprite = nowUnit.GetComponent<AllySuperClass>().CharacterTypeImg;
                unitCost.text = nowUnit.GetComponent<AllySuperClass>().Cost.ToString();
                break;
            case "Building":
                unitImage.GetComponent<Image>().sprite = nowUnit.GetComponent<BuildingSuperClass>().BuildingImg;
                unitCost.text = nowUnit.GetComponent<BuildingSuperClass>().Cost.ToString();
                break;
        }
        
    }
}
