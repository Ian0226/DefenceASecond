using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySuperClass : CharacterSuperClass
{
    [SerializeField]
    private int killReward;
    public int KillReward
    {
        get { return killReward; }
        set { killReward = value; }
    }
    private GameObject moveTargets;
    [SerializeField]
    protected List<GameObject> moveTarget = new List<GameObject>();
    protected int i;
    private bool isOnTrap;
    public bool IsOnTrap
    {
        get { return isOnTrap; }
        set { isOnTrap = value; }
    }
    [SerializeField]
    private bool isAttackingDfTower;
    public bool IsAttackingDfTower
    {
        get { return isAttackingDfTower; }
        set { isAttackingDfTower = value; }
    }
    [SerializeField]
    private GameObject targetBuildingPos;
    public GameObject TargetBuildingPos
    {
        get { return targetBuildingPos; }
        set { targetBuildingPos = value; }
    }

    private void Start()
    {
        moveTargets = GameObject.Find("MoveTarget");
        for(int i=0;i<moveTargets.transform.childCount;i++)
        {
            moveTarget.Add(moveTargets.transform.GetChild(i).gameObject);
        }
        moveTarget.Reverse();
        i = moveTarget.Count;
        StoreMoveSpeed = MoveSpeed;
        AttackBtwAttackSp = AttackSpeed;
    }
    
    public override void Move()
    {
        if (moveTarget.Count != 0)
            this.gameObject.transform.position = Vector3.MoveTowards(transform.position, moveTarget[i-1].transform.position, MoveSpeed * Time.deltaTime);
        if (transform.position == moveTarget[i-1].transform.position)
        {
            i--;
        }
        anim.SetFloat("moveSpeed", MoveSpeed);
    }
    public override void Attack()
    {

    }
    public override void Die()
    {
        PlayerHome playerHome = GameObject.Find("PlayerCastle").GetComponent<PlayerHome>();
        playerHome.GetKillReward(killReward);
        Instantiate(deathEffect, new Vector2(transform.position.x, transform.position.y + 0.5f), Quaternion.identity);
        Destroy(this.gameObject);

    }
    protected void AttackDefenceTower(GameObject tower)
    {
        //transform.position = Vector3.MoveTowards(transform.position, tower.transform.GetChild(0).transform.position, MoveSpeed * Time.deltaTime);
        //TargetBuildingPos = tower.transform.GetChild(0).gameObject;
        //IsAttackingDfTower = true;
        //Debug.Log("1");
    }
}
