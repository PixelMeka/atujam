using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BabyCollider : MonoBehaviour
{
    public bool hit = false;
    public bool hit2 = false;
    public GameObject hitAnim;
    public GameObject hitAnim2;

    public GameObject player;
    public GameObject spawnPoint1;

    public bool hitStopper = false;
    public float hitTimer = 0;
    public float hitTimer2 = 0;
    public float hitTimer3 = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hit == true && hit2 == false)
        {
            hitTimer = 0.1f;
            hit = false;
            hit2 = true;
            hitAnim.SetActive(true);
            hitAnim2.SetActive(true);
        }

        if (hitTimer > 0)
        {
            hitTimer -= Time.deltaTime;

            if (hitTimer <= 0)
            {
                player.GetComponent<Player>().enabled = true;
                hit = false;
                hitStopper = true;
                hitTimer = 0;
                hitTimer2 = 1;
                hitTimer3 = 0.5f;
                hitAnim2.SetActive(false);
            }
        }

        if (hitTimer2 > 0)
        {
            hitTimer2 -= Time.deltaTime;

            if (hitTimer2 <= 0)
            {
                hitStopper = false;
                hitTimer2 = 0;
                hit2 = false;
            }
        }

        if (hitTimer3 > 0)
        {
            hitTimer3 -= Time.deltaTime;

            if (hitTimer3 <= 0)
            {
                hitTimer3 = 0;
                hitAnim.SetActive(false);
                
                Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.name);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Respawn" && hitStopper == false)
        {
            player.GetComponent<Player>().enabled = false;
            player.transform.position = spawnPoint1.transform.position;
            hit = true;
        }
    }
}
