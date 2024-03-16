using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Component on enemy home.
/// </summary>
public class EnemyHome : MonoBehaviour
{
    [SerializeField]
    private PlayerHome playerHome;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Ally"))
        {
            //Give player money when player character into enemy home.
            playerHome.PlayerMoney += collision.gameObject.GetComponent<AllySuperClass>().Cost;
            Destroy(collision.gameObject);
        }
    }
}
