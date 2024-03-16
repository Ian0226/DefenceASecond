using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Component on landmine,use to detect now collision object,add them to the collision object list in LandmineClass.
/// </summary>
public class MultipleTargetBuildingDetect : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            this.gameObject.GetComponentInParent<LandmineClass>().NowCollisionObj.Add(collision.gameObject);
        }
    }
}
