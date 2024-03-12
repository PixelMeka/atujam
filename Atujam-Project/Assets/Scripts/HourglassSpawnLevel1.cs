using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HourglassSpawnLevel1 : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    public GameObject tpAnim;
    public GameObject tpAnim2;

    public bool nextLevel = false;
    public float tpTime = 1f;

    public GameObject objectToSpawn;
    public Vector3 spawnArea;
    private GameObject currentObject;
    private int hourglassCounter = 0;

    public GameObject level1;
    public GameObject boss;

    void Start()
    {
        SpawnObject();
    }

    void SpawnObject()
    {
        Vector3 randomPosition = new Vector3(
            Random.Range(-12f, 25f),
            Random.Range(-873f, -870f),
            Random.Range(5f, 15f)
        );

        currentObject = Instantiate(objectToSpawn, randomPosition, Quaternion.identity);
    
    }

    public void CollectObject()
    {
        hourglassCounter++;

        Destroy(currentObject);
        SpawnObject();
        GetComponent<AudioSource>().Play();
    }


    void Update()
    {
        //Bir sonraki levela geç
        if (hourglassCounter >= 5 && nextLevel == false)
        {
            player1.SetActive(false);
            player2.SetActive(true);
            boss.SetActive(false);

            nextLevel = true;
        }

        if(nextLevel)
        {
            tpTime -= Time.deltaTime;

            if (tpTime <= 0)
            {
                tpAnim.SetActive(false);
                tpAnim2.SetActive(false);

                nextLevel = false;
            }
        }
    }

}