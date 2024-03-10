using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{

    void Update()
    {
        if (transform.position.y < -30f)
        {
            Debug.Log("not yet");
        }
    }
}
