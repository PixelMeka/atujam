using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFinal : MonoBehaviour
{
    GameObject player;
    Animator anim;
    public GameObject ray;
    public GameObject sandOrb;
    public GameObject point1;
    public GameObject point2;
    public GameObject point3;
    public GameObject point4;
    public GameObject point5;
    public bool orbed;

    public float timer = 5;
    public float timer2 = 0;
    public float timer3 = 10;
    public float timer4 = 0;

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

        //Eye beam phase
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


        //Orb phase
        if(timer3 > 0 && !orbed)
        {
            timer3 -= Time.deltaTime;

            if(timer3 <= 0)
            {
                var orb = Instantiate(sandOrb, point1.transform.position, point1.transform.rotation);
                var orb2 = Instantiate(sandOrb, point2.transform.position, point2.transform.rotation);
                var orb3 = Instantiate(sandOrb, point3.transform.position, point3.transform.rotation);
                var orb4 = Instantiate(sandOrb, point4.transform.position, point4.transform.rotation);
                var orb5 = Instantiate(sandOrb, point5.transform.position, point5.transform.rotation);
                orbed = true;
                timer4 = 10f;
            }
        }

        if(timer4 > 0)
        {
            timer4 -= Time.deltaTime;

            if(timer4 <= 0)
            {
                timer3 = 10f;
                timer4 = 0f;
                orbed = false;
            }
        }
    }
}

