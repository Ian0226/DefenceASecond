using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    
    protected List<GameObject> moveTarget = new List<GameObject>();
    protected int i = 0;

    
    private void Start()
    {
        moveTarget.AddRange(GameObject.FindGameObjectsWithTag("moveTarget"));
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
