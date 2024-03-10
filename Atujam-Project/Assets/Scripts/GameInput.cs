using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    [SerializeField] private PlayerInputActions playerInputActions;
    private PlayerInputActions.OnFootActions onFoot;
    private Player player;


    void Awake()
    {
        playerInputActions = new PlayerInputActions();
        onFoot = playerInputActions.OnFoot;
        player = GetComponent<Player>();

        onFoot.Jump.performed += ctx => player.Jump();
    }
    

    // Update is called once per frame
    void Update()
    {
        player.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
        player.ProcessLook(onFoot.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        onFoot.Enable();
    }

    private void OnDisable()
    {
        onFoot.Disable();
    }
}
