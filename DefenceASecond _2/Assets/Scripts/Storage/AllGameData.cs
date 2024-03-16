using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handle game data operations.
/// </summary>
public class AllGameData : MonoBehaviour
{
    private static int playerMoney = 100;
    public int i;
    [SerializeField]
    private List<GameObject> allAliesIns = new List<GameObject>();
    [SerializeField]
    private List<GameObject> allBuildingsIns = new List<GameObject>();

    private static List<GameObject> allAllies = new List<GameObject>();
    private static List<GameObject> allBuildings = new List<GameObject>();

    [SerializeField]
    private List<GameObject> playerCanBuyAllies = new List<GameObject>();
    [SerializeField]
    private List<GameObject> playerCanBuyBuildings = new List<GameObject>();

    private static GameObject[] playerSelectAlly = new GameObject[5];
    private static GameObject[] playerSelectBuilding = new GameObject[5];

    private static List<GameObject> playerItems = new List<GameObject>();
    [SerializeField]
    PlayerData data;
    private void Awake()
    {
        if (allAllies.Count < allAliesIns.Count)
        {
            allAllies.AddRange(allAliesIns);
        }
        if (allBuildings.Count < allBuildingsIns.Count)
        {
            allBuildings.AddRange(allBuildingsIns);
        }
    }

    public static List<GameObject> getAllAllies()
    {
        return allAllies;
    }
    public static List<GameObject> getAllBuildings()
    {
        return allBuildings;
    }
    public static List<GameObject> getPlayerItems()
    {
        return playerItems;
    }

    public static GameObject[] getPlayerSelectAlly()
    {
        return playerSelectAlly;
    }
    public static GameObject findPlayerSelectAllyByIndex(int index)
    {
        return playerSelectAlly[index];
    }
    public static void setPlayerSelectAllyByIndex(int index,GameObject obj)
    {
        playerSelectAlly[index] = obj;
    }

    public static GameObject[] getPlayerSelectBuilding()
    {
        return playerSelectBuilding;
    }
    public static GameObject findPlayerSelectBuildingByIndex(int index)
    {
        return playerSelectBuilding[index];
    }
    public static void setPlayerSelectBuildingByIndex(int index, GameObject obj)
    {
        playerSelectBuilding[index] = obj;
    }

    public static GameObject getPlayerItemByIndex(int i)
    {
        return playerItems[i];
    }
    public static GameObject getPlayerItemByName(string name)
    {
        GameObject item = new GameObject();
        foreach(GameObject obj in playerItems)
        {
            if(obj.name == name)
            {
                item = obj;
            }
        }
        return item;
    }

    //遊戲機制中有強化系統，當玩家強化角色後，角色將永久獲得強化效果，因此必須角色數值儲存起來。
    /// <summary>
    /// 將AllGameData內資料放進PlayerData class中，並將PlayerData資料存成Json檔。
    /// </summary>
    public void SaveData()
    {
        ClearData();
        data.pyMoney = playerMoney;
        foreach (GameObject obj in allAllies)
        {
            data.chaDamage.Add(obj.GetComponent<AllySuperClass>().Damage);
            data.chaHealth.Add(obj.GetComponent<AllySuperClass>().Health);
            data.chaMoveSpeed.Add(obj.GetComponent<AllySuperClass>().MoveSpeed);
        }
        PlayerPrefs.SetString("jsonData", JsonUtility.ToJson(data));
    }

    /// <summary>
    /// 將Json檔轉回PlayerData物件，再將PlayerData資料存入AllGameData。
    /// </summary>
    public void LoadData()
    {
        data = JsonUtility.FromJson<PlayerData>(PlayerPrefs.GetString("jsonData"));
        playerMoney = data.pyMoney;
        for(int i=0;i<data.chaDamage.Count;i++)
        {
            allAllies[i].GetComponent<AllySuperClass>().Damage = data.chaDamage[i];
            allAllies[i].GetComponent<AllySuperClass>().Health = data.chaHealth[i];
            allAllies[i].GetComponent<AllySuperClass>().MoveSpeed = data.chaMoveSpeed[i];
        }
    }
    private void Update()
    {
        i = playerMoney;
        if(Input.GetKeyDown(KeyCode.S))
        {
            SaveData();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadData();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            ClearData();
        }
        if(Input.GetKeyDown(KeyCode.U))
        {
            playerMoney += 100;
        }
    }
    private void ClearData()
    {
        data.pyMoney = 0;
        data.chaDamage.Clear();
        data.chaHealth.Clear();
        data.chaMoveSpeed.Clear();
    }

    [System.Serializable]
    public class PlayerData
    {
        public int pyMoney;
        public List<int> chaDamage;
        public List<int> chaHealth;
        public List<float> chaMoveSpeed;
    }
}
