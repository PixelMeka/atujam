using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandOrbBoss : MonoBehaviour
{
    private Vector3 followPlayer;
    public float speed = 30;
    public bool dead = false;
    public GameObject explosion;
    public bool deadOrb = false;
    GameObject player;

    public float orbLife = 16f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        followPlayer = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);

        transform.position = Vector3.MoveTowards(transform.position, followPlayer, speed * Time.deltaTime);

        orbLife -= Time.deltaTime;

        if(orbLife <= 0)
        {
            Destroy(gameObject);

            var deadExplosion = Instantiate(explosion, transform.position, transform.rotation);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Attack")
        {
            Destroy(gameObject);

            var deadExplosion = Instantiate(explosion, transform.position, transform.rotation);
        }
    }
}
