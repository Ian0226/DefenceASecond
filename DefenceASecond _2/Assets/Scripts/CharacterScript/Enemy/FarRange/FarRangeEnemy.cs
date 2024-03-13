using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarRangeEnemy : EnemySuperClass
{
    [SerializeField]
    private GameObject projectiles;

    protected void CreateShootProjectiles(Vector3 insPos)
    {
        ShootProjectiles psc = projectiles.GetComponent<ShootProjectiles>();
        psc.Damage = Damage;
        psc.Target = detectList.GetComponent<DetectController>().CollisionObj[0];
        Instantiate(projectiles, insPos, Quaternion.identity);
    }
    protected void CreateProjectiles(Vector3 insPos, ProjectilesSuperClass ps)
    {
        //����n���t�~��ا�g��

    }
    public override void Attack(){}
}
