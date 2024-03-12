using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCollider : MonoBehaviour
{
    public bool hit = false;
    public bool hit2 = false;
    public bool hitStopper = false;
    public float hitTimer = 0;
    public float hitTimer2 = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hit && !hit2)
        {
            hitTimer = 0.1f;
            hit = false;
            hit2 = true;
        }

        if (hitTimer > 0)
        {
            hitTimer -= Time.deltaTime;

            if (hitTimer <= 0)
            {
                hit = false;
                hitStopper = true;
                hitTimer = 0;
                hitTimer2 = 0.1f;
            }
        }

        if (hitTimer2 > 0)
        {
            hitTimer2 -= Time.deltaTime;

            if (hitTimer2 <= 0)
            {
                hitStopper = false;
                hitTimer2 = 0;
                hit2 = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Attack" && hitStopper == false)
        {
            hit = true;
        }
    }
}
