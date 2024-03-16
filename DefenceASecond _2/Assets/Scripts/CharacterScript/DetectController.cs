using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Use to detect character in detect range,is component in DetectObj.
/// </summary>
public class DetectController : MonoBehaviour
{
    private List<GameObject> collisionObj = new List<GameObject>();
    public List<GameObject> CollisionObj
    {
        get { return collisionObj; }
    }
    /// <summary>
    /// Change type to this object's parent character type.
    /// </summary>
    [SerializeField] private string type;

    public GameObject GetCollisionObj()
    {
        return collisionObj[0];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(type == "Ally")
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                collisionObj.Add(collision.gameObject);
            }
        }
        else if(type == "Enemy")
        {
            if(collision.gameObject.CompareTag("Ally"))
            {
                collisionObj.Add(collision.gameObject);
            }
            /*else if(collision.gameObject.CompareTag("Building") && this.GetComponent<BoxCollider2D>().IsTouchingLayers(512))
            {
                collisionObj.Add(collision.gameObject);
            }*/
        }
        
    }
    private void Update()
    {
        if(collisionObj.Count > 0 && collisionObj[0] == null)
        {
            collisionObj.RemoveAt(0);
        }
    }
}
