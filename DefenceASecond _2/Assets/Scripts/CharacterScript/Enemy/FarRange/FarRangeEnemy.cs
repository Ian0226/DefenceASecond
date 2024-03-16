using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Parent script for far range enemy,EneShooterClass inheritance this.
/// </summary>
public class FarRangeEnemy : EnemySuperClass
{
    [SerializeField]
    private GameObject projectiles;

    /// <summary>
    /// Create projectiles.
    /// </summary>
    /// <param name="insPos">Projectiles instantiate position.</param>
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
