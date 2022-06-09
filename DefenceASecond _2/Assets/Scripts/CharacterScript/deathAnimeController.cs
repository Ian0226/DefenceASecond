using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathAnimeController : MonoBehaviour
{
    public void destroyThis()
    {
        Destroy(this.gameObject);
    }
}
