using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if(Health <= 0)
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
            collisionEnemy[0].GetComponent<EnemySuperClass>().Health -= Damage;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            collisionEnemy.Add(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collisionEnemy.Remove(collision.gameObject);
        }
    }

    private void ShowLazer()
    {
        lazerObj.SetActive(true);
        Invoke("UseFunction", 0.3f);
    }
    private void CloseLazer()
    {
        lazerObj.SetActive(false);
    }
    
}
