using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelData : MonoBehaviour
{
    [SerializeField]
    private string levelName;
    public string LevelName
    {
        get { return levelName; }
    }

    [SerializeField]
    private Sprite levelBossImg;
    public Sprite LevelBossImg
    {
        get { return levelBossImg; }
    }

    [SerializeField]
    private Sprite[] levelRewardItemImg;
    public Sprite[] LevelRewardItemImg
    {
        get { return levelRewardItemImg; }
    }
}
