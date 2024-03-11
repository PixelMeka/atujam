using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameInput gameInput;

    // Movement stuff
    private Vector3 playerVelocity;
    [SerializeField] private float speed;
    private CharacterController characterController;
    private bool isGrounded;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float gravity = -9.8f;

    // Rotation stuff
    [SerializeField] private Camera cam;
    private float rotationX = 0f;
    [SerializeField] private float mouseSensitivity = 30f;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        gameInput = GetComponent<GameInput>();

        // To keep the cursor locked
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        isGrounded = characterController.isGrounded;

    }

    public void ProcessMove(Vector2 input)
    {
        
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        characterController.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);

        playerVelocity.y += gravity * Time.deltaTime;

        if (isGrounded && playerVelocity.y < 0)
            playerVelocity.y = -2f;

        characterController.Move(playerVelocity * Time.deltaTime);

    }

    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;

        rotationX -= mouseY * Time.deltaTime * mouseSensitivity;
        rotationX = Mathf.Clamp(rotationX, -80f, 80f);

        cam.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);

        transform.Rotate(Vector2.up * (mouseX * Time.deltaTime) * mouseSensitivity);
    }


    public void Jump()
    {
        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * gravity * -jumpHeight);
        }

    }
}
