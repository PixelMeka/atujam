using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayOff : MonoBehaviour
{

    public GameObject ray;

    void RayOn()
    {
        ray.SetActive(true);
    }

    void RayOfff()
    {
        ray.SetActive(false);
    }
}