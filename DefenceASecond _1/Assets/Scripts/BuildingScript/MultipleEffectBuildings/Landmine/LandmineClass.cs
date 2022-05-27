using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandmineClass : BuildingSuperClass
{
    private List<GameObject> nowCollisiontObj = new List<GameObject>();
    public List<GameObject> NowCollisionObj
    {
        get { return nowCollisiontObj; }
    }
    [SerializeField]
    private GameObject explosionObj;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            UseFunction();
            Destroy(gameObject);
        }
    }
    protected override void UseFunction()
    {
        Instantiate(explosionObj, transform.position, Quaternion.identity);
        for(int i=0; i< nowCollisiontObj.Count; i++)
        {
            if(nowCollisiontObj[i]!=null)
            {
                nowCollisiontObj[i].GetComponent<EnemySuperClass>().Health -= Damage;
            }
            
        }
    }
}
