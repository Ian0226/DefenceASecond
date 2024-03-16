using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The parent class of building.
/// </summary>
public abstract class BuildingSuperClass : MonoBehaviour
{
    [SerializeField]
    private string buildingType;
    public string BuildingType
    {
        get { return buildingType; }
    }
    [SerializeField]
    private Sprite buildingImg;
    public Sprite BuildingImg
    {
        get { return buildingImg; }
    }
    [SerializeField]
    private int damage;
    public int Damage
    {
        get { return damage; }
        set { damage = value; }
    }
    [SerializeField]
    private int cost;
    public int Cost
    {
        get { return cost; }
        set { cost = value; }
    }
    [SerializeField]
    public Animator anim;

    protected abstract void UseFunction();
    
}
