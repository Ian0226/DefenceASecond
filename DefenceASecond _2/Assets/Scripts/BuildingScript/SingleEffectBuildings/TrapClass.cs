using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Trap class on trap gameObject,inheritance BuildingSuperClass.
/// </summary>
public class TrapClass : BuildingSuperClass
{
    [SerializeField]
    private float restrictTime;
    [SerializeField]
    private float delay;
    private GameObject nowRestrictObj;
    protected override void UseFunction()
    {
        anim.SetBool("isAttack", true);
        nowRestrictObj.GetComponent<EnemySuperClass>().IsOnTrap = true;
        nowRestrictObj.GetComponent<EnemySuperClass>().MoveSpeed = 0;
        nowRestrictObj.GetComponent<EnemySuperClass>().Health -= Damage;
    }
    private void ReturnSpeed()
    {
        if(nowRestrictObj != null)
        {
            nowRestrictObj.GetComponent<EnemySuperClass>().IsOnTrap = false;
            nowRestrictObj.GetComponent<EnemySuperClass>().MoveSpeed =
            nowRestrictObj.GetComponent<EnemySuperClass>().StoreMoveSpeed;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            nowRestrictObj = collision.gameObject;
            Invoke("UseFunction", delay);
            Invoke("ReturnSpeed", restrictTime);
            Invoke("DestroyThis", restrictTime + 0.5f);
        }
    }
    private void DestroyThis()
    {
        Destroy(this.gameObject);
    }
    public void exitAnim()
    {
        this.gameObject.SetActive(false);
    }
    
}
