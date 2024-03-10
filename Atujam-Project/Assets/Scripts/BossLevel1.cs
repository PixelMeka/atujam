using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLevel1 : MonoBehaviour
{
    GameObject player;
    Animator anim;
    public GameObject ray;
    public float timer = 5;
    public float timer2 = 0;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();

        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 place = new Vector3(player.transform.position.x - this.transform.position.x, 0f, player.transform.position.z - this.transform.position.z); //The place to look at, y is neglected.
        Quaternion rot = Quaternion.LookRotation(place); //Tells the boss to look at that place.
        this.transform.rotation = rot; //Rotate the boss to that place.

        if (timer > 0)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                anim.SetTrigger("Eye");
                timer2 = 15;
            }
        }

        if (timer2 > 0)
        {
            timer2 -= Time.deltaTime;

            if (timer2 <= 0)
            {
                timer2 = 0;
                timer = 5;
            }
        }
    }
}
