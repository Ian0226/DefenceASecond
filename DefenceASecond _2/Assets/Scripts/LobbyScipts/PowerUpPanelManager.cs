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
    [Header("顯示東西的框框")]
    public GameObject characterPanel;
    public GameObject materialsPanel;
    public GameObject chaUpgradeValuePanel;
    public Image chaImg;

    //框框內一次要顯示幾個物件
    private int count = 0;
    private int showChaMaxCount = 3;
    private int clickBtnTimes;

    public void OnEnable()
    {
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
        }
        else
        {
            chaImg.gameObject.SetActive(false);
        }
    }
    private void Upgrade()
    {
        
    }
    private void ShowChas()
    {
        GameObject obj;
        for (int i = count; i < showChaMaxCount; i++)
        {
            obj = Instantiate(unitBlock);
            obj.transform.SetParent(characterPanel.transform);
            obj.GetComponent<PowerUpPanelChaBtn>().numberInList = i;
            obj.transform.GetChild(0).GetComponent<Image>().sprite = pyCharacters[i].GetComponent<SpriteRenderer>().sprite;
            obj.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    private void ShowMaterial()
    {
        GameObject obj;
        for (int i = count; i < showChaMaxCount; i++)
        {
            obj = Instantiate(materialBlock);
            obj.transform.SetParent(materialsPanel.transform);
            obj.transform.GetChild(0).GetComponent<Image>().sprite = pyMaterials[i].transform.GetChild(0).GetComponent<Image>().sprite;
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

    }
}
