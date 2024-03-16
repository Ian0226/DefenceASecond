using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Component on close range enemy,inheritance EnemySuperClass.
/// </summary>
public class CloseRangeEnemy : EnemySuperClass
{
    private void Update()
    {
        if (i > 0)
        {
            Move();
        }
        if (Health <= 0)
        {
            Die();
        }
        //Continue moving when not on trap and has no attck target.
        if (detectList.GetComponent<DetectController>().CollisionObj.Count == 0 && IsOnTrap == false)
        {
            IsOnAttack = false;
            MoveSpeed = StoreMoveSpeed;
            anim.SetBool("isAttack", false);
        }
        if (IsOnAttack == true && Time.time >= AttackSpeed)
        {
            Attack();
            AttackSpeed = Time.time + AttackBtwAttackSp;
        }
    }
    public override void Attack()
    {
        if(detectList.GetComponent<DetectController>().GetCollisionObj().CompareTag("Ally"))
        {
            detectList.GetComponent<DetectController>().GetCollisionObj().GetComponent<AllySuperClass>().Health -= Damage;
        }
        else
        {
            //detectList.GetComponent<DetectController>().GetCollisionObj().GetComponent<DefenceTowerClass>().Health -= Damage;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(chaColider.IsTouchingLayers(128))
        {
            if(collision.CompareTag("Ally"))
            {
                MoveSpeed = 0;
                IsOnAttack = true;
                anim.SetBool("isAttack", true);
            }
        }
        /*if(chaColider.IsTouchingLayers(512))
        {
            if(collision.CompareTag("Building"))
            {
                AttackDefenceTower(collision.gameObject);
            }
        }
        */
    }
}
