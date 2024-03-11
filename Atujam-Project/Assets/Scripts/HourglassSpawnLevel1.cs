using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HourglassSpawnLevel1 : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Vector3 spawnArea;
    private GameObject currentObject;
    private int hourglassCounter = 0;

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
        if (hourglassCounter >= 5)
        {

        }
    }

}