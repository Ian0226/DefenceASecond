using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
