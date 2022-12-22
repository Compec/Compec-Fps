using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;
    private void OnCollisionEnter(Collision collision)
    {
        source.PlayOneShot(clip);
        Destroy(collision.gameObject);
        Destroy(this.gameObject);
    }
}
