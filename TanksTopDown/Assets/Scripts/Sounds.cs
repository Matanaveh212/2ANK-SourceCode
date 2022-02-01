using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip shot;
    [SerializeField] AudioClip hit;
    [SerializeField] AudioClip death;

    [SerializeField] AudioClip wood;
    [SerializeField] AudioClip metal;

    public void PlayShotSound()
    {
        source.PlayOneShot(shot);
    }

    public void PlayHitSound()
    {
        source.PlayOneShot(hit);
    }

    public void PlayDeathSound()
    {
        source.PlayOneShot(death);
    }

    public void PlayWoodSound()
    {
        source.PlayOneShot(wood);
    }

    public void PlayMetalSound()
    {
        source.PlayOneShot(metal);
    }
}
