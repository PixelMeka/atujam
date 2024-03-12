using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayOff : MonoBehaviour
{
    public AudioSource deathSound;
    public AudioSource raySound;

    public GameObject ray;

    void RayOn()
    {
        ray.SetActive(true);
        raySound.Play();
    }

    void RayOfff()
    {
        ray.SetActive(false);
    }

    void DeathSound()
    {
        deathSound.Play();
    }
}
