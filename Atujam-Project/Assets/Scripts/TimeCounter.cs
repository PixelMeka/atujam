using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 100;
    public float timeRemainingInt;
    [SerializeField] GameObject player;
    public bool pleaseStop = false;
    public float stopTimer = 1;
    public bool pleaseStop2 = false;
    public float stopTimer2 = 1;
    public GameObject[] orbs;
    public bool orbPhase = false;

    public GameObject boss;
    public GameObject bossShield;
    public GameObject bossCollider;
    Animator bossAnim;
    public bool bossDead = false;

    public float bossStunTimer = 0f;

    public float orbTimer = 15f;

    public TMP_Text timeText;

    void Start()
    {
        timeText = timeText.GetComponent<TextMeshProUGUI>();
        //player = GameObject.FindWithTag("Player");

        bossAnim = boss.GetComponentInChildren<Animator>();
    }

    void Update()
    {
        orbs = GameObject.FindGameObjectsWithTag("EnemyOrb");

        timeRemainingInt = (int)timeRemaining;
        timeText.text = timeRemainingInt.ToString();

        if (timeRemaining > 0 && bossDead == false)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            timeRemaining = 0;
        }

        if(player.GetComponent<PlayerStats>().hit == true && player.GetComponent<PlayerStats>().hitStopper == false)
        {
            if(pleaseStop == false)
            {
                timeRemaining -= 5;
                stopTimer = 1;
                pleaseStop = true;
            }
        }

        if (bossCollider.GetComponent<BossCollider>().hit == true && bossCollider.GetComponent<BossCollider>().hitStopper == false)
        {
            if (pleaseStop2 == false)
            {
                timeRemaining += 20;
                stopTimer2 = 1;
                pleaseStop2 = true;
            }
        }

        if (pleaseStop == true)
        {
            stopTimer -= Time.deltaTime;

            if(stopTimer <= 0)
            {
                stopTimer = 0;
                pleaseStop = false;
            }
        }

        if (pleaseStop2 == true)
        {
            stopTimer2 -= Time.deltaTime;

            if (stopTimer2 <= 0)
            {
                stopTimer2 = 0;
                pleaseStop2 = false;
            }
        }

        if (orbs.Length >= 5 && orbPhase == false)
        {
            orbPhase = true;
            orbTimer = 15f;
        }

        if(orbTimer > 0)
        {
            orbTimer -= Time.deltaTime;

            if(orbTimer <= 0)
            {
                orbPhase = false;
            }
        }

        if(orbPhase == true && orbs.Length <= 0)
        {
            timeRemaining += 50;
            orbPhase = false;
        }

        //Boss attack phase
        if(timeRemaining >= 200)
        {
            bossShield.SetActive(false);
            bossCollider.SetActive(true);
        }

        if(timeRemaining < 200)
        {
            bossShield.SetActive(true);
            bossCollider.SetActive(false);
        }

        if(timeRemaining >= 400)
        {
            bossAnim.SetBool("Dead", true);
            bossDead = true;
        }
    }
}
