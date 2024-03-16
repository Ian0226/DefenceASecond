using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Component on shooter type character.
/// </summary>
public class ShooterClass : FarRangeAlly
{
    
    public override void Attack()
    {
        if(detectList.GetComponent<DetectController>().CollisionObj.Count > 0)
            CreateShootProjectiles(transform.position,Damage,detectList.GetComponent<DetectController>().CollisionObj[0]);
    }
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
        if (detectList.GetComponent<DetectController>().CollisionObj.Count != 0)
        {
            MoveSpeed = 0;    
            anim.SetBool("isAttack", true);
        }
        else
        {
            MoveSpeed = StoreMoveSpeed;
            anim.SetBool("isAttack", false);
        }
        SetHealth();
    }
}
