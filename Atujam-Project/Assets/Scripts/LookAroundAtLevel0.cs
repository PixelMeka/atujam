using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class LookAroundAtLevel0 : MonoBehaviour
{
    [SerializeField] private PlayerInputActions playerInputActions;


    void Awake()
    {
        playerInputActions = new PlayerInputActions();
    }

    void Update()
    {
        ProcessLook();
    }

    public void ProcessLook()
    {
       Vector2 mouseInput = playerInputActions.OnFoot.Look.ReadValue<Vector2>();
       Debug.Log(mouseInput);
    }

}
