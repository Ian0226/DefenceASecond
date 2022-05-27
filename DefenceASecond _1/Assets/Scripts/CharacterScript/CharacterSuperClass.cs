using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class CharacterSuperClass : MonoBehaviour
{
    
    [SerializeField]
    private int damage;
    public int Damage
    {
        get { return damage; }
        set { damage = value; }
    }
    [SerializeField]
    private int health;
    public int Health
    {
        get { return health; }
        set { health = value; }
    }
    [SerializeField]
    private float moveSpeed;
    public float MoveSpeed
    {
        get { return moveSpeed; }
        set { moveSpeed = value; }
    }
    [SerializeField]
    private float attackSpeed;
    public float AttackSpeed
    {
        get { return attackSpeed; }
        set { attackSpeed = value; }
    }
    private float attackBtwAttackSp;
    public float AttackBtwAttackSp
    {
        get { return attackBtwAttackSp; }
        set { attackBtwAttackSp = value; }
    }

    [SerializeField] protected GameObject deathEffect;
    [SerializeField] protected Animator anim;
    [SerializeField] protected GameObject detectList;
    [SerializeField] protected BoxCollider2D chaColider;
    private float storeMoveSpeed;
    public float StoreMoveSpeed
    {
        get { return storeMoveSpeed; }
        set { storeMoveSpeed = value; }
    }
    private int maxHealth;
    public int MaxHealth
    {
        get { return maxHealth; }
        set { maxHealth = value; }
    }
    private bool isOnAttack;
    public bool IsOnAttack
    {
        get { return isOnAttack; }
        set { isOnAttack = value; }
    }
    
    public abstract void Move();
    public abstract void Attack();
    public abstract void Die();
}
