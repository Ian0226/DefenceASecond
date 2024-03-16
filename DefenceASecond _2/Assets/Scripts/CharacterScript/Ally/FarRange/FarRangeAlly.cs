using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Parent class of far range ally characters.
/// </summary>
public class FarRangeAlly : AllySuperClass
{
    [SerializeField]
    private GameObject projectiles;
    
    /// <summary>
    /// Create projectiles for shooter type character.
    /// </summary>
    /// <param name="insPos">Projectiles instantiate position.</param>
    /// <param name="damage">Projectiles damage.</param>
    /// <param name="target">Set projectiles target.</param>
    protected void CreateShootProjectiles(Vector3 insPos,int damage,GameObject target)
    {
        if(target != null)
        {
            projectiles.GetComponent<ShootProjectiles>().Damage = damage;
            projectiles.GetComponent<ShootProjectiles>().Target = target;
            Instantiate(projectiles, insPos, Quaternion.identity);
        }
        
    }

    /// <summary>
    /// Create projectiles for sup type character.
    /// </summary>
    /// <param name="insPos">Projectiles instantiate position.</param>
    /// <param name="damage">Projectiles damage,this will change to health.</param>
    protected void CreateHealthProjectiles(Vector3 insPos, int damage)
    {
        projectiles.GetComponent<HealthProjectiles>().Damage = damage;
        Instantiate(projectiles, insPos, Quaternion.identity);
    }

    /// <summary>
    /// Create projectiles for big range shooter type character.
    /// </summary>
    /// <param name="insPos">Projectiles instantiate position.</param>
    /// <param name="damage">Projectiles damage.</param>
    protected void CreateBigRangeProjectiles(Vector3 insPos,int damage)
    {
        projectiles.GetComponent<BigRangeProjectiles>().Damage = damage;
        Instantiate(projectiles, insPos, Quaternion.identity);
    }
    public override void Attack(){}
    
}
