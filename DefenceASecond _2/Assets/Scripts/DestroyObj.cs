using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Component on landmine's explsion object.
/// </summary>
public class DestroyObj : MonoBehaviour
{
    /// <summary>
    /// Use on animation event.
    /// </summary>
    public void DestroyThis()
    {
        Destroy(this.gameObject);
    }
}
