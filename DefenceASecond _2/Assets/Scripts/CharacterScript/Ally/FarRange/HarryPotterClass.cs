using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Component on HarryPotter(一種魔法師角色類型) type character.
/// </summary>
public class HarryPotterClass : FarRangeAlly
{
    private float standardPos;
    private void Awake()
    {
        standardPos = transform.position.y;
    }
    public override void Attack()
    {
        if (detectList.GetComponent<DetectController>().CollisionObj.Count > 0)
        {
            CreateBigRangeProjectiles(detectList.GetComponent<DetectController>().GetCollisionObj().transform.position, Damage);
        }
            
    }
    private void Update()
    {
        if (i != moveTarget.Count)
        {
            Move();
        }

        if (Health <= 0)
        {
            transform.position =new Vector2(transform.position.x, standardPos);
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

    /// <summary>
    /// Use on animation event.
    /// </summary>
    public void SetPositionUp()
    {
        this.gameObject.transform.position = new Vector2(transform.position.x, transform.position.y + 1.099f);
    }

    /// <summary>
    /// Use on animation event.
    /// </summary>
    public void SetPositionDown()
    {
        this.gameObject.transform.position = new Vector2(transform.position.x, transform.position.y - 1.099f);
    }
}
