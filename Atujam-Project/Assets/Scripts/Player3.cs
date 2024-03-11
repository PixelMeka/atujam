using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3 : MonoBehaviour
{
    float speed;
    float walk = 50;
    float air = 20;
    public float jump;
    //Different gravities, one for the ground, the other is for the air (to solve slope bump problems)
    public float gravity;
    public float gravityAir;

    public bool isRunning = false;
    public bool isAir = false;

    Vector3 direction;
    CharacterController controller;

    public GameObject attackCol;
    public GameObject meleeSwing;
    public GameObject meleeSwing2;
    public int t;
    public bool attacking = false;
    public float attackTime = 0.5f;

    [SerializeField] private float cameraSpeed = 5f;
    float xAxisClamp = 0;
    public GameObject playerMid;

    public AudioSource audioSwing;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

        // To keep the cursor locked
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        ProcessLookAround();
        float rightleft = Input.GetAxis("Horizontal");   //Right and left, sideways
        float forback = Input.GetAxis("Vertical");      //Forward and backward

        isAir = true;
        isRunning = false;

        //If player is on the ground
        if (controller.isGrounded)
        {
            isAir = false;
            MoveFunc();
            //Gravity to pull down if the player is on the ground (solves slope bump)
            direction.y -= gravity;
        }
        //If player is in the air, play the falling animation
        if (isAir == true)
        {
            speed = air;
            //Gravity for when the player is airborne. Multiplied by Time.deltaTime and 0.5 to solve frame related gravity issues.
            direction.y -= gravityAir * Time.deltaTime * 0.5f;
        }

        //Attack
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            t = Random.Range(1, 3);
            
            if(t == 2)
            {
                meleeSwing.SetActive(true);
            }
            else
            {
                meleeSwing2.SetActive(true);
            }

            audioSwing.Play();
            attackCol.SetActive(true);
            attacking = true;
            attackTime = 0.5f;
        }
        if (attacking)
        {
            attackTime -= Time.deltaTime;

            if (attackTime <= 0)
            {
                attackTime = 0;
                attackCol.SetActive(false);
                meleeSwing.SetActive(false);
                meleeSwing2.SetActive(false);
                attacking = false;
            }
        }

        controller.Move(direction * Time.deltaTime);
    }

    void MoveFunc()
    {
        float rightleft = Input.GetAxis("Horizontal");
        float forback = Input.GetAxis("Vertical");

        direction = new Vector3(rightleft, 0, forback);
        direction = transform.TransformDirection(direction);
        direction *= speed;

        speed = walk;

        //If space is pressed - jump and play the jump animation
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isRunning = false;
            direction.y += jump;
        }
    }

    private void ProcessLookAround()
    {
        //Mouse inputs
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        float rotAmountX = mouseX * cameraSpeed;
        float rotAmountY = mouseY * cameraSpeed;

        //Prevents the camera from going way too up or down
        xAxisClamp -= rotAmountY;

        Vector3 rotPlayerMid = playerMid.transform.rotation.eulerAngles;
        Vector3 rotPlayer = this.transform.rotation.eulerAngles;

        //Moving camera and the player
        rotPlayerMid.x -= rotAmountY;
        rotPlayerMid.z = 0;
        rotPlayer.y += rotAmountX;

        //Prevents the camera from going way too up or down
        if (xAxisClamp > 90)
        {
            xAxisClamp = 90;
            rotPlayerMid.x = 90;
        }
        else if (xAxisClamp < -90)
        {
            xAxisClamp = -90;
            rotPlayerMid.x = 270;
        }

        playerMid.transform.rotation = Quaternion.Euler(rotPlayerMid);
        this.transform.rotation = Quaternion.Euler(rotPlayer);
    }
}
