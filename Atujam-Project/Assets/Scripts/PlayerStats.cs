using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public bool hit = false;
    public bool hit2 = false;
    public bool end = false;
    public float endTimer = 3f;
    public GameObject hitAnim;
    public GameObject hitAnim2;
    public GameObject hitAnim3;

    public GameObject player;
    public GameObject spawnPoint3;

    public bool hitStopper = false;
    public float hitTimer = 0;
    public float hitTimer2 = 0;
    public float hitTimer3 = 0.5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(hit && !hit2)
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
                player.GetComponent<Player3>().enabled = true;
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
            }
        }

        if(end)
        {
            endTimer -= Time.deltaTime;

            hitAnim.SetActive(true);
            hitAnim3.SetActive(true);

            if (endTimer <= 0)
            {
                Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.name);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Hit" && hitStopper == false)
        {
            hit = true;
        }

        if (other.tag == "RayRed" && hitStopper == false)
        {
            hit = true;
        }

        if (other.tag == "Respawn" && hitStopper == false)
        {
            player.GetComponent<Player3>().enabled = false;
            player.transform.position = spawnPoint3.transform.position;
            hit = true;
        }

        if (other.tag == "Anomaly")
        {
            Time.timeScale = 0.5f;
        }

        if (other.tag == "Anomaly2")
        {
            Time.timeScale = 1.5f;
        }

        if (other.tag == "Hourglass")
        {
            end = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Hit" && hitStopper == false)
        {
            hit = true;
        }

        if (other.tag == "RayRed" && hitStopper == false)
        {
            hit = true;
        }

        if (other.tag == "Anomaly")
        {
            Time.timeScale = 0.3f;
        }

        if (other.tag == "Anomaly2")
        {
            Time.timeScale = 1.7f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Anomaly" || other.tag == "Anomaly2")
        {
            Time.timeScale = 1.0f;
        }
    }
}
