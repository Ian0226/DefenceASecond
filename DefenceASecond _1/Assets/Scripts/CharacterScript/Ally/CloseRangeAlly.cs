using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseRangeAlly : AllySuperClass
{
    private void Update()
    {
        if (i != moveTarget.Count)
        {
            Move();
        }
        if (Health <= 0)
        {
            Die();
        }
        if (detectList.GetComponent<DetectController>().CollisionObj.Count == 0)
        {
            IsOnAttack = false;
            MoveSpeed = StoreMoveSpeed;
            anim.SetBool("isAttack", false);
        }
        if(IsOnAttack == true && Time.time >= AttackSpeed)
        {
            Attack();
            AttackSpeed = Time.time + AttackBtwAttackSp;
        }
        SetHealth();
    }
    public override void Attack()
    {
        detectList.GetComponent<DetectController>().GetCollisionObj().GetComponent<EnemySuperClass>().Health -= Damage; 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(chaColider.IsTouchingLayers(256))
        {
            if(collision.gameObject.CompareTag("Enemy"))
            {
                MoveSpeed = 0;
                anim.SetBool("isAttack", true);
                IsOnAttack = true;
            }
        }
    }
}
