using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject wave2;
    public GameObject wave3;

    public GameObject player3;
    public GameObject player3Boss;
    public GameObject bossFinal;

    public GameObject[] sands;

    public float tpTime = 3f;
    public float tpTime2 = 1f;
    public GameObject playerHitAnim;
    public GameObject playerTpAnim;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sands = GameObject.FindGameObjectsWithTag("SandBoom");

        if(sands.Length == 7)
        {
            wave2.SetActive(true);
        }

        if (sands.Length == 17)
        {
            wave3.SetActive(true);
        }

        if (sands.Length == 24)
        {
            tpTime -= Time.deltaTime;

            if(tpTime <= 0)
            {
                tpTime2 -= Time.deltaTime;

                player3.SetActive(false);
                player3Boss.SetActive(true);
                bossFinal.SetActive(true);

                if (tpTime2 <= 0)
                {
                    playerTpAnim.SetActive(false);
                    playerHitAnim.SetActive(false);
                }
            }
        }
    }
}
