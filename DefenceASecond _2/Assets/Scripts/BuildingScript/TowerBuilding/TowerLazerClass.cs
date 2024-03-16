using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Component on lazer gameObject,is the child object of DefenceTower.
/// </summary>
public class TowerLazerClass : MonoBehaviour
{
    [SerializeField]
    private GameObject target;
    public GameObject Target
    {
        get { return target; }
        set { target = value; }
    }
    [SerializeField]
    private Transform pivot;
    [SerializeField]
    private Transform lazer;
    private int damage;
    public int Damage
    {
        get { return damage; }
        set { damage = value; }
    }

    /// <summary>
    /// Set the lazer face to enemy.
    /// </summary>
    private void LookAtEnemy()
    {
        if(target != null)
        {
            Vector2 relative = target.transform.position - pivot.position;
            float angle = Mathf.Atan2(relative.y, relative.x) * Mathf.Rad2Deg;
            Vector3 newRotation = new Vector3(0, 0, angle+180);
            pivot.localRotation = Quaternion.Euler(newRotation);
        }
    }
    
    private void Update()
    {
        LookAtEnemy();
    }
    
}
