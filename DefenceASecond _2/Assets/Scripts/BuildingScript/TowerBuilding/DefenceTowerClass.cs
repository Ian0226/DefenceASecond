using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Component on Defence tower,inheritance BuildingSuperClass. 
/// </summary>
public class DefenceTowerClass : BuildingSuperClass
{
    [SerializeField]
    private int health;
    public int Health
    {
        get { return health; }
        set { health = value; }
    }
    [SerializeField]
    private TowerLazerClass lazer;
    [SerializeField]
    private GameObject lazerObj;
    [SerializeField]
    private List<GameObject> collisionEnemy = new List<GameObject>();

    private void Awake()
    {
        lazer.Damage = Damage;
    }
    private void Update()
    {
        //Enemy can attack tower,but not done this game mechanics yet.
        if (Health <= 0)
        {
            Destroy(gameObject);
        }

        if(collisionEnemy.Count > 0)
        {
            lazer.Target = collisionEnemy[0];
        }
        if(collisionEnemy.Count > 0)
        {
            anim.SetBool("isAttack", true);
        }
        else
        {
            anim.SetBool("isAttack", false);
        }
        if(collisionEnemy.Count > 0 && collisionEnemy[0] == null)
        {
            collisionEnemy.RemoveAt(0);
        }
    }
    protected override void UseFunction()
    {
        if(lazer.Target != null)
        {
            //Attack the first enemy in list.
            collisionEnemy[0].GetComponent<EnemySuperClass>().Health -= Damage;
        }
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Add enemy object to collisionEnemy list.
        if(collision.gameObject.CompareTag("Enemy"))
        {
            collisionEnemy.Add(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //Remove enemy object from collisionEnemy list if enemy move out tower attack range.
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collisionEnemy.Remove(collision.gameObject);
        }
    }

    /// <summary>
    /// Create lazer animation,use on animation event.
    /// </summary>
    private void ShowLazer()
    {
        lazerObj.SetActive(true);
        Invoke("UseFunction", 0.3f);
    }

    /// <summary>
    /// Close laser animation,use on animation event.
    /// </summary>
    private void CloseLazer()
    {
        lazerObj.SetActive(false);
    }
}
