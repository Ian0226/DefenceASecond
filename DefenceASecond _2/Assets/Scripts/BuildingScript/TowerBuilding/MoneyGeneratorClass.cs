using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Component on MoneyGenerator,inheritance BuildingSuperClass.
/// </summary>
public class MoneyGeneratorClass : BuildingSuperClass
{
    [SerializeField]
    private int increaseMoneyMin;
    public int IncreaseMoneyMin
    {
        get { return increaseMoneyMin; }
        set { increaseMoneyMin = value; }
    }

    [SerializeField]
    private int increaseMoneyMax;
    public int IncreaseMoneyMax
    {
        get { return increaseMoneyMax; }
        set { increaseMoneyMax = value; }
    }

    [SerializeField]
    private float generateCD;
    public float GenerateCD
    {
        get { return generateCD; }
        set { generateCD = value; }
    }
    private float storeGenerateCD;

    [SerializeField]
    private PlayerHome PH;

    private void Start()
    {
        storeGenerateCD = generateCD;
    }
    protected override void UseFunction()
    {
        //每隔一段時間生成金幣，生成量為生成最大值與最小值間隨機取一個值。
        if(Time.timeSinceLevelLoad >= generateCD)
        {
            PH.PlayerMoney += Random.Range(increaseMoneyMin, increaseMoneyMax + 1);
            generateCD = Time.timeSinceLevelLoad + storeGenerateCD;
        }
    }
    private void Update()
    {
        UseFunction();
    }
}
