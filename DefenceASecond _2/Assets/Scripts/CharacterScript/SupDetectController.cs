using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Component on detect object for sup character.
/// </summary>
public class SupDetectController : DetectController
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Ally"))
            CollisionObj.Add(collision.gameObject); 
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ally"))
            CollisionObj.Remove(collision.gameObject);
            
    }
}
