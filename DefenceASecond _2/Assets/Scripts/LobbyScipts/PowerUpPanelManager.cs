using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpPanelManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> pyCharacters = new List<GameObject>();
    [SerializeField]
    private List<GameObject> pyMaterials = new List<GameObject>();
    //當前選中的角色
    private static int nowSelectChaNumber = -1;
    public static int NowSelectChaNumber
    {
        get { return nowSelectChaNumber; }
        set { nowSelectChaNumber = value; }
    }

    public GameObject unitBlock;
    public GameObject materialBlock;

    //放遊戲中UI物件的變數
    [Header("Display item")]
    public GameObject characterPanel;
    public GameObject materialsPanel;
    public GameObject chaUpgradeValuePanel;
    public GameObject chaUpMaterialPanel;
    public Image chaImg;
    public Text[] beforeUp;
    public Text[] afterUp;

    //框框內一次要顯示幾個物件
    private int count = 0;
    private int showChaMaxCount = 3;
    private int clickBtnTimes;

    private bool bo = true;
    private bool upgradeCondition;

    public void OnEnable()
    {
        ClearCha();
        ClearMaterial();
        pyCharacters = AllGameData.getAllAllies();
        pyMaterials = AllGameData.getPlayerItems();
        clickBtnTimes = pyCharacters.Count / 3;
        ShowChas();
        if(pyMaterials.Count != 0)
        {
            ShowMaterial();
        }
    }
    private void Update()
    {
        //Debug.Log(PowerUpPanelManager.NowSelectChaNumber);
        if(nowSelectChaNumber!=-1)
        {
            chaImg.gameObject.SetActive(true);
            chaImg.sprite = pyCharacters[nowSelectChaNumber].GetComponent<SpriteRenderer>().sprite;
            if(bo)
            {
                DisplayChaUpMaterial();
                bo = false;
            }
            
        }
        else
        {
            chaImg.gameObject.SetActive(false);
        }
        DisplayChaValue();
    }
    public void Upgrade()
    {
        
        if (AllGameData.getPlayerItemByName(pyCharacters[nowSelectChaNumber].GetComponent<AllySuperClass>().upgradeMaterialsName[0]).transform.GetChild(0).GetComponent<ItemClass>().itemAmountValue > 0 &&
             AllGameData.getPlayerItemByName(pyCharacters[nowSelectChaNumber].GetComponent<AllySuperClass>().upgradeMaterialsName[1]).transform.GetChild(0).GetComponent<ItemClass>().itemAmountValue > 0 &&
             AllGameData.getPlayerItemByName(pyCharacters[nowSelectChaNumber].GetComponent<AllySuperClass>().upgradeMaterialsName[2]).transform.GetChild(0).GetComponent<ItemClass>().itemAmountValue > 0)
        {
            pyCharacters[nowSelectChaNumber].GetComponent<AllySuperClass>().Damage += (int)(pyCharacters[nowSelectChaNumber].GetComponent<AllySuperClass>().upgradeValue[0]);
            pyCharacters[nowSelectChaNumber].GetComponent<AllySuperClass>().Health += (int)(pyCharacters[nowSelectChaNumber].GetComponent<AllySuperClass>().upgradeValue[1]);
            pyCharacters[nowSelectChaNumber].GetComponent<AllySuperClass>().MoveSpeed += pyCharacters[nowSelectChaNumber].GetComponent<AllySuperClass>().upgradeValue[2];
            if (AllGameData.getPlayerItemByName(pyCharacters[nowSelectChaNumber].GetComponent<AllySuperClass>().upgradeMaterialsName[0]))
            {
                AllGameData.getPlayerItemByName(pyCharacters[nowSelectChaNumber].GetComponent<AllySuperClass>().upgradeMaterialsName[0]).transform.GetChild(0).GetComponent<ItemClass>().itemAmountValue
                      -= pyCharacters[nowSelectChaNumber].GetComponent<AllySuperClass>().upgradeMaterialsAmount[0];
            }
            if (AllGameData.getPlayerItemByName(pyCharacters[nowSelectChaNumber].GetComponent<AllySuperClass>().upgradeMaterialsName[1]))
            {
                AllGameData.getPlayerItemByName(pyCharacters[nowSelectChaNumber].GetComponent<AllySuperClass>().upgradeMaterialsName[1]).transform.GetChild(0).GetComponent<ItemClass>().itemAmountValue
                      -= pyCharacters[nowSelectChaNumber].GetComponent<AllySuperClass>().upgradeMaterialsAmount[1];
            }
            if (AllGameData.getPlayerItemByName(pyCharacters[nowSelectChaNumber].GetComponent<AllySuperClass>().upgradeMaterialsName[2]))
            {
                AllGameData.getPlayerItemByName(pyCharacters[nowSelectChaNumber].GetComponent<AllySuperClass>().upgradeMaterialsName[2]).transform.GetChild(0).GetComponent<ItemClass>().itemAmountValue
                      -= pyCharacters[nowSelectChaNumber].GetComponent<AllySuperClass>().upgradeMaterialsAmount[2];
            }
            ClearMaterial();
            ShowMaterial();
        }
    }
    private void ShowChas()
    {
        GameObject obj;
        for (int i = count; i < showChaMaxCount; i++)
        {
            obj = Instantiate(unitBlock);
            obj.transform.SetParent(characterPanel.transform);
            obj.GetComponent<PowerUpPanelChaBtn>().numberInList = i;
            if(pyCharacters[i].GetComponent<AllySuperClass>().ChaLevel != 0)
            {
                obj.GetComponent<PowerUpPanelChaBtn>().levelText.text = "+" + pyCharacters[i].GetComponent<AllySuperClass>().ChaLevel.ToString();
            }
            else
            {
                obj.GetComponent<PowerUpPanelChaBtn>().levelText.text = "";
            }
            obj.transform.GetChild(0).GetComponent<Image>().sprite = pyCharacters[i].GetComponent<SpriteRenderer>().sprite;
            obj.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    private void ShowMaterial()
    {
        GameObject obj;
        for (int i = count; i < showChaMaxCount; i++)
        {
            obj = Instantiate(pyMaterials[i]);
            obj.transform.SetParent(materialsPanel.transform);
            //obj.transform.GetChild(0).GetComponent<Image>().sprite = pyMaterials[i].transform.GetChild(0).GetComponent<Image>().sprite;
        }
    }
    private void ClearCha()
    {
        for(int i = 0;i < characterPanel.transform.childCount; i++)
        {
            Destroy(characterPanel.transform.GetChild(i).gameObject);
        }
    }
    private void ClearMaterial()
    {
        for (int i = 0; i < materialsPanel.transform.childCount; i++)
        {
            Destroy(materialsPanel.transform.GetChild(i).gameObject);
        }
    }
    public void ChangeChaBtn()
    {
        ClearCha();
        if(showChaMaxCount < pyCharacters.Count)
        {
            count += 3;
            if (pyCharacters.Count % 3 == 0)
            {
                showChaMaxCount += 3;
            }
            else
            {
                clickBtnTimes--;
                if(clickBtnTimes-1 >= 0)
                {
                    showChaMaxCount += 3;
                }
                else
                {
                    showChaMaxCount += pyCharacters.Count % 3;
                }
                
            }
        }
        else
        {
            count = 0;
            showChaMaxCount = 3;
            clickBtnTimes = pyCharacters.Count / 3;
        }
        ShowChas();
    }
    private void ChangeMaterialBtn()
    {
        ClearMaterial();
        if (showChaMaxCount < pyMaterials.Count)
        {
            count += 3;
            if (pyMaterials.Count % 3 == 0)
            {
                showChaMaxCount += 3;
            }
            else
            {
                clickBtnTimes--;
                if (clickBtnTimes - 1 >= 0)
                {
                    showChaMaxCount += 3;
                }
                else
                {
                    showChaMaxCount += pyMaterials.Count % 3;
                }

            }
        }
        else
        {
            count = 0;
            showChaMaxCount = 3;
            clickBtnTimes = pyMaterials.Count / 3;
        }
        ShowMaterial();
    }
    private void DisplayChaValue()
    {
        if(nowSelectChaNumber != -1)
        {
            beforeUp[0].text = pyCharacters[nowSelectChaNumber].GetComponent<AllySuperClass>().Damage.ToString();
            beforeUp[1].text = pyCharacters[nowSelectChaNumber].GetComponent<AllySuperClass>().Health.ToString();
            beforeUp[2].text = pyCharacters[nowSelectChaNumber].GetComponent<AllySuperClass>().MoveSpeed.ToString();

            afterUp[0].text = (pyCharacters[nowSelectChaNumber].GetComponent<AllySuperClass>().Damage +
                    pyCharacters[nowSelectChaNumber].GetComponent<AllySuperClass>().upgradeValue[0]).ToString();
            afterUp[1].text = (pyCharacters[nowSelectChaNumber].GetComponent<AllySuperClass>().Health +
                    pyCharacters[nowSelectChaNumber].GetComponent<AllySuperClass>().upgradeValue[1]).ToString();
            afterUp[2].text = (pyCharacters[nowSelectChaNumber].GetComponent<AllySuperClass>().MoveSpeed +
                    pyCharacters[nowSelectChaNumber].GetComponent<AllySuperClass>().upgradeValue[2]).ToString();
        }
        else
        {
            beforeUp[0].text = "";
            beforeUp[1].text = "";
            beforeUp[2].text = "";

            afterUp[0].text = "";
            afterUp[1].text = "";
            afterUp[2].text = "";
        }
    }
    private void DisplayChaUpMaterial()
    {
        string[] upMaterialName = new string[3];
        for (int i=0;i<3;i++)
        {
            upMaterialName[i] = pyCharacters[nowSelectChaNumber].GetComponent<AllySuperClass>().upgradeMaterialsName[i];
        }
        
        for (int i=0;i<AllGameData.getPlayerItems().Count;i++)
        {
            
            if (AllGameData.getPlayerItemByIndex(i).name == upMaterialName[0])
            {
                GameObject obj = Instantiate(AllGameData.getPlayerItemByIndex(i));
                obj.transform.SetParent(chaUpMaterialPanel.transform);
                obj.transform.GetChild(0).GetComponent<ItemClass>().itemAmountValue = pyCharacters[nowSelectChaNumber].GetComponent<AllySuperClass>().upgradeMaterialsAmount[0];
                upMaterialName[0] = "";

            }
            else if (AllGameData.getPlayerItemByIndex(i).name == upMaterialName[1])
            {
                GameObject obj = Instantiate(AllGameData.getPlayerItemByIndex(i));
                obj.transform.SetParent(chaUpMaterialPanel.transform);
                obj.transform.GetChild(0).GetComponent<ItemClass>().itemAmountValue = pyCharacters[nowSelectChaNumber].GetComponent<AllySuperClass>().upgradeMaterialsAmount[1];
                upMaterialName[1] = "";
            }
            else if (AllGameData.getPlayerItemByIndex(i).name == upMaterialName[2])
            {
                GameObject obj = Instantiate(AllGameData.getPlayerItemByIndex(i));
                obj.transform.SetParent(chaUpMaterialPanel.transform);
                obj.transform.GetChild(0).GetComponent<ItemClass>().itemAmountValue = pyCharacters[nowSelectChaNumber].GetComponent<AllySuperClass>().upgradeMaterialsAmount[2];
                upMaterialName[2] = "";
            }

        }
        
    }
}
