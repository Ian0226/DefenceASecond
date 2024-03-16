using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Component on death animation object,use on animation event.
/// </summary>
public class deathAnimeController : MonoBehaviour
{
    public void destroyThis()
    {
        Destroy(this.gameObject);
    }
}
