using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EneShooterClass : FarRangeEnemy
{
    [SerializeField]
    private GameObject laser;
    public override void Attack()
    {
        if (detectList.GetComponent<DetectController>().CollisionObj.Count > 0)
            CreateShootProjectiles(transform.position);
    }
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
        if (detectList.GetComponent<DetectController>().CollisionObj.Count != 0)
        {
            MoveSpeed = 0;
            laser.SetActive(true);
            anim.SetBool("isAttack", true);
        }
        else
        {
            MoveSpeed = StoreMoveSpeed;
            laser.SetActive(false);
            anim.SetBool("isAttack", false);
        }
    }
}
