using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HourglassLevel1 : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {   

        if (other.tag == "Player")
            GameObject.FindWithTag("HourglassCollectTag").GetComponent<HourglassSpawnLevel1>().CollectObject();
    }
}
