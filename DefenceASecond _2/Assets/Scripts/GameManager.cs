using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Component on GameManager object.
/// </summary>
public class GameManager : MonoBehaviour
{
    /// <summary>
    /// Use on change scene button events.
    /// </summary>
    /// <param name="sceneName">Scene name you want to change.</param>
    public void LoadScene(string sceneName)
    {
        Application.LoadLevel(sceneName);
    }
}
