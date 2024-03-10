using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBoss : MonoBehaviour
{
    public GameObject boss;
    public GameObject hourglass;

    void Dead()
    {
        Destroy(boss);
        hourglass.SetActive(true);
    }
}
