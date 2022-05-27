using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHome : MonoBehaviour
{
    [SerializeField]
    private PlayerHome playerHome;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Ally"))
        {
            playerHome.PlayerMoney += collision.gameObject.GetComponent<AllySuperClass>().Cost;
            Destroy(collision.gameObject);
        }
    }
}
