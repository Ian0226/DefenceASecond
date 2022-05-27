using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthProjectiles : ProjectilesSuperClass
{
    private List<GameObject> healthAllies = new List<GameObject>();

    private void increaseHealth()
    {
        if(healthAllies.Count != 0)
        {
            foreach (GameObject allies in healthAllies)
            {
                allies.GetComponent<AllySuperClass>().Health += Damage;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Ally"))
        {
            healthAllies.Add(collision.gameObject);
            increaseHealth();
        }
    }
    public void Die()
    {
        Destroy(this.gameObject);
    }
}
