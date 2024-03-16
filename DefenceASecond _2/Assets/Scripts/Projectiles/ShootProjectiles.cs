using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Component on shooter projectiles,inheritance ProjectilesSuperClass.
/// </summary>
public class ShootProjectiles : ProjectilesSuperClass
{
    [SerializeField]
    private GameObject target;
    public GameObject Target
    {
        get { return target; }
        set { target = value; }
    }
    private Vector3 targetPos;
    
    [SerializeField]
    private float speed;

    private void Attack(GameObject attackObj,string damageType)
    {
        if (damageType == "enemy")
        {
            attackObj.GetComponent<EnemySuperClass>().Health -= Damage;
            Destroy(gameObject);
        }
        if(damageType == "ally")
        {
            attackObj.GetComponent<AllySuperClass>().Health -= Damage;
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(ChaType == "Ally" && collision.gameObject.tag == "Enemy")
        {
            Attack(collision.gameObject,"enemy");
        }
        else if(ChaType == "Enemy" && collision.gameObject.tag == "Ally")
        {
            Attack(collision.gameObject,"ally");
        }
        
    }
    private void Awake()
    {
        targetPos = target.transform.position;
        Die();
    }
    private void Update()
    {
        Move();
        if(Target == null)
        {
            Destroy(gameObject, 0.5f);
        }
    }

    /// <summary>
    /// Handle projectiles moving.
    /// </summary>
    private void Move()
    {
        
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        if(transform.position == targetPos && target == null)
        {
            Destroy(this.gameObject);
        }
    }
    private void Die()
    {
        Destroy(this.gameObject, LifeTime);
    }
}
