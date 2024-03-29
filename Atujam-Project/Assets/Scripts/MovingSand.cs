using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSand : MonoBehaviour
{

    [SerializeField] private Texture2D[] frames;
    [SerializeField] private float fps = 10.0f;

    private Material mat;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    void Update()
    {
        int index = (int)(Time.time * fps);
        index = index % frames.Length;
        mat.mainTexture = frames[index];
    }
}
