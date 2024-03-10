using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLevel1HeadMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("LaunchRedLaser", 5.0f, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
