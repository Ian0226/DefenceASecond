using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHome : MonoBehaviour
{
    [Header("Player money in battle")]
    [SerializeField]private int playerMoney;
    public int PlayerMoney
    {
        get { return playerMoney; }
        set { playerMoney = value; }
    }

    public Text playerMonerText;

    [SerializeField]
    private Image[] castleLevelImage;

    [SerializeField]
    private Image[] castleLevelBtnImage;

    private int createMoney;

    private float createMoneySpeed;

    private float storeCreateMoneySpeed;

    /// <summary>
    /// ª±®aª÷¹ô¤W­­
    /// </summary>
    private int maxPlayerMoney;

    [Header("Player castle hleath")]
    [SerializeField]private int castleHealth;
    public int CastleHealth
    {
        get { return castleHealth; }
    }

    [Header("Player castle level")]
    [SerializeField]private int castleLevel;

    private int upgradeCastleCost;

    

    private void Start()
    {
        CastleLevelControl(1);
        storeCreateMoneySpeed = createMoneySpeed;
        createMoneySpeed += Time.time;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            if(collision.gameObject.name.Contains("BOSS"))
            {
                castleHealth -= castleHealth;
                Destroy(collision.gameObject);
            }
            else
            {
                castleHealth--;
                Destroy(collision.gameObject);
            }
            
        }
    }
    private void Update()
    {
        
        playerMonerText.text = playerMoney.ToString();
        
        if(playerMoney > maxPlayerMoney)
        {
            playerMoney = maxPlayerMoney;
        }
        if(Time.time >= createMoneySpeed)
        {
            playerMoney += createMoney;
            createMoneySpeed = Time.time + storeCreateMoneySpeed;
        }
    }
    public void GetKillReward(int reward)
    {
        playerMoney += reward;
    }
    public void UpgradeCastleLevel()
    {
        if (castleLevel < 5 && playerMoney >= upgradeCastleCost)
        {
            castleLevel++;
            playerMoney -= upgradeCastleCost;
            CastleLevelControl(castleLevel);
        }
    }
    private void CastleLevelControl(int level)
    {
        switch(level)
        {
            case 1:
                createMoney = 1;
                createMoneySpeed = 8;
                maxPlayerMoney = 20;
                upgradeCastleCost = 20;
                break;
            case 2:
                createMoney = 1;
                createMoneySpeed = 7;
                maxPlayerMoney = 30;
                upgradeCastleCost = 30;
                castleLevelImage[0].transform.GetChild(0).gameObject.SetActive(true);
                castleLevelBtnImage[0].gameObject.SetActive(false);
                castleLevelBtnImage[1].gameObject.SetActive(true);
                break;
            case 3:
                createMoney = 1;
                createMoneySpeed = 6;
                maxPlayerMoney = 40;
                upgradeCastleCost = 40;
                castleLevelImage[1].transform.GetChild(0).gameObject.SetActive(true);
                castleLevelBtnImage[1].gameObject.SetActive(false);
                castleLevelBtnImage[2].gameObject.SetActive(true);
                break;
            case 4:
                createMoney = 1;
                createMoneySpeed = 5;
                maxPlayerMoney = 50;
                upgradeCastleCost = 50;
                castleLevelImage[2].transform.GetChild(0).gameObject.SetActive(true);
                castleLevelBtnImage[2].gameObject.SetActive(false);
                castleLevelBtnImage[3].gameObject.SetActive(true);
                break;
            case 5:
                createMoney = 1;
                createMoneySpeed = 3;
                maxPlayerMoney = 60;
                castleLevelImage[3].transform.GetChild(0).gameObject.SetActive(true);
                castleLevelBtnImage[3].gameObject.SetActive(false);
                castleLevelBtnImage[4].gameObject.SetActive(true);
                break;
        }
    }
}
