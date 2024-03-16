using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Component on sup type character.
/// </summary>
public class SupportClass : FarRangeAlly
{
    public override void Attack()
    {
        if (detectList.GetComponent<SupDetectController>().CollisionObj.Count > 0)
            CreateHealthProjectiles(detectList.GetComponent<SupDetectController>().GetCollisionObj().transform.position, Damage);
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
        if (detectList.GetComponent<SupDetectController>().CollisionObj.Count > 0)
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
