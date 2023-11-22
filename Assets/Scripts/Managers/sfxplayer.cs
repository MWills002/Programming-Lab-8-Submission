using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sfxplayer : MonoBehaviour
{
    public AudioSource src;

    public AudioClip shootsfx;

    public void button1()
    {
        src.clip = shootsfx;
        src.Play();

    }
}
