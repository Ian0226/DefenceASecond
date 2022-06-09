using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelInfoPanelController : MonoBehaviour
{
    [SerializeField]
    private LobbyPanelController lobbyPanel;

    [SerializeField]
    private LevelData levelDataObj;

    [SerializeField]
    private Text levelNameText;

    [SerializeField]
    private Image levelBoss;

    [SerializeField]
    private Image[] levelRewardImg;

    private void OnEnable()
    {
        DisplayLevelData();
    }
    private void DisplayLevelData()
    {
        //Debug.Log(lobbyPanel.NowSelectLevel);
        levelDataObj = lobbyPanel.NowSelectLevel.gameObject.GetComponent<LevelData>();
        //Debug.Log(levelDataObj);
        if (levelDataObj != null)
        {
            levelNameText.text = levelDataObj.LevelName;
            levelBoss.sprite = levelDataObj.LevelBossImg;
            for (int i = 0; i < levelDataObj.LevelRewardItemImg.Length; i++)
            {
                levelRewardImg[i].sprite = levelDataObj.LevelRewardItemImg[i];
            }
        }
        
    }
}
