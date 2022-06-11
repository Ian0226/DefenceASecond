using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private Image[] allyBigHeadImg;

    [SerializeField]
    private Image[] allyTypeImg;

    [SerializeField]
    private Text[] allyCost;

    [SerializeField]
    private GameObject insPos;

    [SerializeField]
    private GameObject enemyInsPos;

    //全部該關卡要生成的怪物
    [SerializeField]
    private GameObject[] createdEnemy;

    [Header("每一種敵人循環生成時間")]
    [SerializeField]
    private float[] createEnemyTime;
    [SerializeField]
    private float[] storeCreateEnemyTime;

    [SerializeField]
    private PlayerHome playerHome;

    [SerializeField]
    private float waveTime;
    private float storeWaveTime;

    //準備時間包括在波數時間裡
    [SerializeField]
    private float wavePrepareTime;
    private float storeWavePrepareTime;

    public int nowWave = 1;

    private bool playerLose;

    public Text waveText;

    [SerializeField]
    private List<GameObject> insEnemy = new List<GameObject>();//所有生成在場上的敵人

    public GameObject winPanel;
    public GameObject losePanel;

    [Header("關卡掉落獎勵")]
    [SerializeField]
    private GameObject[] levelReward;
    [SerializeField]
    private int[] levelRewardCount;

    public GameObject winGameRewardPanel;

    private int layerforAlly = 1;
    private int layerforEnemy = 1;
    [SerializeField]
    public int[] enemyCount;
    
    private bool prepareStatus;
    public Text prepareStatusText;
    public float wavePrepareTextTime = 2;

    public void Awake()
    {
        Time.timeScale = 1;
        storeWaveTime = waveTime;
        storeWavePrepareTime = wavePrepareTime;
        
    }
    public void CreateAlly(int i)
    {
        if (AllGameData.findPlayerSelectAllyByIndex(i) != null && playerHome.PlayerMoney >= AllGameData.findPlayerSelectAllyByIndex(i).GetComponent<AllySuperClass>().Cost)
        {
            GameObject obj = Instantiate(AllGameData.findPlayerSelectAllyByIndex(i), insPos.transform.position, Quaternion.identity);
            obj.GetComponent<SpriteRenderer>().sortingOrder += layerforAlly;
            layerforAlly++;
            if (layerforAlly == 15)
            {
                layerforAlly = 0;
            }
            playerHome.PlayerMoney -= AllGameData.findPlayerSelectAllyByIndex(i).GetComponent<AllySuperClass>().Cost;
        }
    }
    private void Start()
    {
        for(int i=0;i<5;i++)
        {
            if(AllGameData.findPlayerSelectAllyByIndex(i) != null)
            {
                allyBigHeadImg[i].sprite = AllGameData.findPlayerSelectAllyByIndex(i).GetComponent<AllySuperClass>().CharacterBigHead;
                allyTypeImg[i].sprite = AllGameData.findPlayerSelectAllyByIndex(i).GetComponent<AllySuperClass>().CharacterTypeImg;
                allyCost[i].text = AllGameData.findPlayerSelectAllyByIndex(i).GetComponent<AllySuperClass>().Cost.ToString();
            }
            if(allyBigHeadImg[i].sprite==null)
            {
                allyBigHeadImg[i].gameObject.SetActive(false);
            }
            if (allyTypeImg[i].sprite == null)
            {
                allyTypeImg[i].gameObject.SetActive(false);
            }
        }
    }
    private void Update()
    {
        if(prepareStatus == false)
        {
            CreateEnemyControl();
        }
        WaveControl();
        
        if (nowWave > 5)
        {
            nowWave = 5;
            waveText.text = "";
            playerLose = false;
            winPanel.SetActive(true);
            DisplayWinGameReward();

            //AddLevelRewardToGameData();

            //Debug.Log(AllGameData.getPlayerItemByIndex(0));
            Time.timeScale = 0;
        }
        if (playerHome.CastleHealth <= 0)
        {
            //輸惹
            playerLose = true;
            losePanel.SetActive(true);
            Time.timeScale = 0;
        }/*
        if(playerHome.CastleHealth >= 0 && nowWave == 5 && insEnemy.Count == 0)
        {
            waveText.text = "";
            playerLose = false;
            winPanel.SetActive(true);
            DisplayWinGameReward();
            AllGameData.getPlayerItems().AddRange(levelReward);
            //Debug.Log(AllGameData.getPlayerItemByIndex(0));
            Time.timeScale = 0;
        }*/
        //測試用
        if(Input.GetKeyDown(KeyCode.O))
        {
            playerLose = true;
            losePanel.SetActive(true);
            Time.timeScale = 0;
        }
        if(Input.GetKeyDown(KeyCode.W))
        {
            playerLose = false;
            winPanel.SetActive(true);
            DisplayWinGameReward();

            AddLevelRewardToGameData();


            //Debug.Log(AllGameData.getPlayerItemByIndex(0));
            Time.timeScale = 0;
        }
        
    }
    //把關卡獎勵存入AllGameData
    private void AddLevelRewardToGameData()
    {
        if(AllGameData.getPlayerItems().Count > 0)
        {
            for(int i = 0; i < AllGameData.getPlayerItems().Count; i++)
            {
                for(int j = 0; j < levelReward.Length;j++)
                {
                    if (AllGameData.getPlayerItemByIndex(i).name == levelReward[j].name)
                    {
                        AllGameData.getPlayerItemByIndex(i).transform.GetChild(0).GetComponent<ItemClass>().itemAmountValue += levelRewardCount[j];
                    }
                    else
                    {
                        continue;
                    }
                }
                
            }
        }
        else
        {
            for(int i=0;i<levelReward.Length;i++)
            {
                levelReward[i].transform.GetChild(0).GetComponent<ItemClass>().itemAmountValue += levelRewardCount[i];
                AllGameData.getPlayerItems().Add(levelReward[i]);
            }
            
        }
        
    }
    private void WavePrepareTimeCounter()
    {
        wavePrepareTime -= 1*Time.deltaTime;
        prepareStatus = true;
        prepareStatusText.gameObject.SetActive(true);
        if(wavePrepareTime <= 28)
        {
            ClosePrepareText();
        }
    }
    private void ClosePrepareText()
    {
        prepareStatusText.gameObject.SetActive(false);
    }
    private void WaveControl()
    {
        waveText.text = "第 "+nowWave.ToString()+" 波";
        if(enemyCount[nowWave-1]<=0)
        {
            WavePrepareTimeCounter();
            if(wavePrepareTime<=0)
            {
                ChangeWave();
                wavePrepareTime = storeWavePrepareTime;
                prepareStatus = false;
            }
        }
    }
    private void ChangeWave()
    {
        nowWave++;
    }
    private void CreateEnemyControl()
    {
        switch(nowWave)
        {
            case 1:
                CreateEnemy(0);
                CreateEnemy(1);
                break;
            case 2:
                CreateEnemy(0);
                CreateEnemy(1);
                CreateEnemy(2);
                break;
            case 3:
                CreateEnemy(0);
                CreateEnemy(1);
                CreateEnemy(2);
                CreateEnemy(3);
                break;
            case 4:
                CreateEnemy(0);
                CreateEnemy(1);
                CreateEnemy(2);
                CreateEnemy(4);
                break;
            case 5:
                CreateEnemy(0);
                CreateEnemy(1);
                CreateEnemy(2);
                CreateEnemy(3);
                //createEnemyTime[3] -= 5;
                CreateEnemy(4);
                break;
        }
    }
    private void CreateEnemy(int i)
    {
        if (Time.timeSinceLevelLoad > createEnemyTime[i])
        {
            enemyCount[nowWave - 1]--;
            GameObject obj = Instantiate(createdEnemy[i], enemyInsPos.transform.position, Quaternion.identity);
            insEnemy.Add(obj);
            obj.GetComponent<SpriteRenderer>().sortingOrder += layerforEnemy;
            layerforEnemy++;
            if (layerforEnemy == 15)
            {
                layerforEnemy = 0;
            }
            createEnemyTime[i] = Time.timeSinceLevelLoad + storeCreateEnemyTime[i];
        }
    }
    private void CreateBoss()
    {
        Instantiate(createdEnemy[4], enemyInsPos.transform.position, Quaternion.identity);
    }
    public void BackToLobby()
    {
        Time.timeScale = 1;
        nowWave = 1;
        Application.LoadLevel("LobbyScene");
    }
    private void DisplayWinGameReward()
    {
        for(int i = 0;i<levelReward.Length;i++)
        {
            GameObject gameObj = Instantiate(levelReward[i]);
            gameObj.transform.SetParent(winGameRewardPanel.transform);
            gameObj.transform.GetChild(0).GetComponent<ItemClass>().itemAmountValue = levelRewardCount[i];

            //AllGameData.getPlayerItems().Add(gameObj);
        }
        

    }
}
