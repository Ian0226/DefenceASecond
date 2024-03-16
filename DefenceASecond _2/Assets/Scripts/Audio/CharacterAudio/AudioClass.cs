using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Use on character gameObject,control audios.
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class AudioClass : MonoBehaviour
{
    public AudioClip impactSFX1;
    public AudioClip impactSFX2;
    AudioSource audiosource;

    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ally")
        {
            audiosource.PlayOneShot(impactSFX1);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            audiosource.PlayOneShot(impactSFX2);
        }
    }
}
