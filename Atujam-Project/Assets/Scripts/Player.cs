using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameInput gameInput;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float cameraSpeed = 5f;

    [SerializeField] private Camera playerCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessMove();
        ProcessLookAround();
    }




    private void ProcessMove()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        Vector3 moveDirection = new Vector3(inputVector.x, 0f, inputVector.y);

        Vector3 newMoveDirection = transform.TransformDirection(moveDirection);


        float moveDistance = moveSpeed * Time.deltaTime;
        
       // Debug.DrawRay(transform.position, transform.position + Vector3.up * playerHeight, Color.red);

        bool canMove = !Physics.Raycast(
            transform.position, transform.TransformDirection(Vector3.forward), moveDistance);


        this.transform.position += newMoveDirection * moveDistance;
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward));
    }


    private void ProcessLookAround()
    {
        Vector2 mouseInput = gameInput.GetMouseInput();

        
        playerCamera.transform.eulerAngles += new Vector3(-mouseInput.y, 0, 0) * cameraSpeed * Time.deltaTime;
        this.transform.eulerAngles += new Vector3(0, mouseInput.x, 0) * cameraSpeed * Time.deltaTime;
    }
}
