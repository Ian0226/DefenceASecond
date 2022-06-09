using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarRangeAlly : AllySuperClass
{
    [SerializeField]
    private GameObject projectiles;
    
    protected void CreateShootProjectiles(Vector3 insPos,int damage,GameObject target)
    {
        if(target != null)
        {
            projectiles.GetComponent<ShootProjectiles>().Damage = damage;
            projectiles.GetComponent<ShootProjectiles>().Target = target;
            Instantiate(projectiles, insPos, Quaternion.identity);
        }
        
    }
    protected void CreateHealthProjectiles(Vector3 insPos, int damage)
    {
        projectiles.GetComponent<HealthProjectiles>().Damage = damage;
        Instantiate(projectiles, insPos, Quaternion.identity);
    }
    protected void CreateBigRangeProjectiles(Vector3 insPos,int damage)
    {
        projectiles.GetComponent<BigRangeProjectiles>().Damage = damage;
        Instantiate(projectiles, insPos, Quaternion.identity);
    }
    public override void Attack()
    {
        //暫不實作，留給子類
    }
    
}
