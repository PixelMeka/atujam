using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BookEnemy : MonoBehaviour
{
    GameObject player;
    public GameObject hitCol;
    Animator anim;
    private NavMeshAgent agent;

    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = player.transform.position;

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            anim.SetTrigger("Attack");
            hitCol.SetActive(true);
        }

        if (other.tag == "Attack")
        {
            Destroy(gameObject);

            var deadExplosion = Instantiate(explosion, transform.position, transform.rotation);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            anim.SetTrigger("Attack");
            hitCol.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            anim.SetTrigger("Attack");
            hitCol.SetActive(false);
        }
    }
}
