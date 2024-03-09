using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debugger : MonoBehaviour
{
    private Vector3 previousTransform;
    private Vector3 lastSafeTransform;
    [SerializeField] private float difference = 5f;
    private BoxCollider boxCollider;


    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();

        lastSafeTransform = transform.position;

        InvokeRepeating("AssignNewPosition", 2.5f, 2.5f);

    }

    void AssignNewPosition()
    {
        lastSafeTransform = transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 2)
            transform.position = lastSafeTransform;

    }
}
