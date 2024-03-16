using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Component on big range projectiles,inheritance ProjectilesSuperClass.
/// </summary>
public class BigRangeProjectiles : ProjectilesSuperClass
{
    private List<GameObject> attackEnemies = new List<GameObject>();
    
    private void Attak()
    {
        if(attackEnemies.Count > 0)
        {
            foreach(GameObject enemies in attackEnemies)
            {
                enemies.GetComponent<EnemySuperClass>().Health -= Damage;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            attackEnemies.Add(collision.gameObject);
            if(attackEnemies.Count > 0)
                Attak();
        }
    }
    public void Die()
    {
        Destroy(this.gameObject);
    }
    private void Update()
    {
        for(int i=0;i<attackEnemies.Count;i++)
        {
            if(attackEnemies[i] == null)
            {
                attackEnemies.RemoveAt(i);
            }
            
        }
    }
}
