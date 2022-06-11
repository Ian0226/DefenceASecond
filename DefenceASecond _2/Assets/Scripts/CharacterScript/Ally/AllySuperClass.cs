using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllySuperClass : CharacterSuperClass
{
    [SerializeField]
    private string characterType;
    public string CharacterType
    {
        get { return characterType; }
    }
    [SerializeField]
    private Sprite characterTypeImg;
    public Sprite CharacterTypeImg
    {
        get { return characterTypeImg; }
    }
    [SerializeField]
    private Sprite characterBigHead;
    public Sprite CharacterBigHead
    {
        get { return characterBigHead; }
    }
    [SerializeField]
    private int cost;
    public int Cost
    {
        get { return cost; }
        set { cost = value; }
    }
    [SerializeField]
    protected List<GameObject> moveTarget = new List<GameObject>();
    private GameObject moveTargets;
    protected int i = 0;

    private int chaLevel;
    public int ChaLevel
    {
        get { return chaLevel; }
        set { chaLevel = value; }
    }
    /// <summary>
    /// 強化需要的素材
    /// </summary>
    [Header("強化素材的名稱跟數量")]
    public string[] upgradeMaterialsName;
    public int[] upgradeMaterialsAmount;
    public float[] upgradeValue;
    
    //public int 

    private void Start()
    {
        moveTargets = GameObject.Find("MoveTarget");
        for (int i = 0; i < moveTargets.transform.childCount; i++)
        {
            moveTarget.Add(moveTargets.transform.GetChild(i).gameObject);
        }
        StoreMoveSpeed = MoveSpeed;
        AttackBtwAttackSp = AttackSpeed;
        MaxHealth = Health;
    }
    protected void SetHealth()
    {
        if(Health > MaxHealth)
        {
            Health = MaxHealth;
        }
    }
    public override void Move()
    {
        if(moveTarget.Count != 0)
        this.gameObject.transform.position = Vector3.MoveTowards(transform.position,moveTarget[i].transform.position, MoveSpeed*Time.deltaTime);
        if(transform.position == moveTarget[i].transform.position)
        {
            i++;
        }
        anim.SetFloat("moveSpeed", MoveSpeed);
    }
    public override void Attack()
    {
        
    }
    public override void Die()
    {
        Instantiate(deathEffect, new Vector2(transform.position.x, transform.position.y + 0.5f), Quaternion.identity);
        Destroy(this.gameObject);
        
    }
    
    
}
