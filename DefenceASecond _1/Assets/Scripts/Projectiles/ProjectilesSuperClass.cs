using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilesSuperClass : MonoBehaviour
{
    [SerializeField]
    private string chaType;
    public string ChaType
    {
        get { return chaType; }
    }
    [SerializeField]
    private int damage;
    public int Damage
    {
        get { return damage; }
        set { damage = value; }
    }
    [SerializeField]
    private float lifeTime;
    
    public float LifeTime
    {
        get { return lifeTime; }
        set { lifeTime = value; }
    }
    
}
