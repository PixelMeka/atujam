using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Collision : MonoBehaviour
{
    public bool gate1 = false;
    public bool gate2 = false;
    public bool gate3 = false;

    public bool one = false;
    public bool two = false;
    public bool three = false;
    public bool four = false;
    public bool five = false;
    public bool six = false;

    public bool endLevel2 = false;

    public GameObject kapi1;
    public GameObject kapi2;
    public GameObject kapi3;

    public AudioSource gatePass;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gate1)
        {
            kapi1.SetActive(false);
        }

        if (gate2)
        {
            kapi2.SetActive(false);
        }

        if (gate3)
        {
            kapi3.SetActive(false);
        }
    }

    //The values are different in the game; these are just tags
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "bolu2") //+5
        {
            gate1 = true;

            one = true;

            gatePass.Play();
        }

        if (other.tag == "-3") //-10
        {
            gate1 = true;

            two = true;

            gatePass.Play();
        }

        if (other.tag == "+3") //+15
        {
            gate2 = true;

            three = true;

            gatePass.Play();
        }

        if (other.tag == "x2") //-5
        {
            gate2 = true;

            four = true;

            gatePass.Play();
        }

        if (other.tag == "+4") //+10
        {
            gate3 = true;

            five = true;

            gatePass.Play();
        }

        if (other.tag == "-5") //+5
        {
            gate3 = true;

            six = true;

            gatePass.Play();
        }

        if(other.tag == "Hedef")
        {
            endLevel2 = true;
        }
    }
}
