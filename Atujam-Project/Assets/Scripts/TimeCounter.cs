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
    public GameObject player;
    public GameObject playerBoss;
    public GameObject playerbaby;
    public GameObject player2;
    public bool pleaseStop = false;
    public float stopTimer = 1;
    public bool pleaseStop2 = false;
    public float stopTimer2 = 0.2f;
    public GameObject[] orbs;
    public bool orbPhase = false;

    public GameObject boss;
    public GameObject bossShield;
    public GameObject bossCollider;
    public GameObject bossAnomalies;
    Animator bossAnim;
    public bool bossDead = false;

    public float bossStunTimer = 0f;

    public float orbTimer = 10f;

    public TMP_Text timeText;

    public bool done1 = false;
    public bool done2 = false;
    public bool done3 = false;

    //Level 3 start
    public bool level3 = false;
    public float level3Timer = 1f;
    public GameObject tpAnim;
    public GameObject tpAnim2;
    public GameObject level3map;

    public GameObject level1;
    public GameObject level2music;
    public GameObject level3music;
    public AudioSource level4music;
    public AudioSource level4musicloop;

    public AudioSource clockSound;
    public GameObject alarmSound;

    public GameObject level3Ctrl;

    void Start()
    {
        timeText = timeText.GetComponent<TextMeshProUGUI>();
        //player = GameObject.FindWithTag("Player3");

        bossAnim = boss.GetComponentInChildren<Animator>();
    }

    void Update()
    {
        orbs = GameObject.FindGameObjectsWithTag("EnemyOrb");

        timeRemainingInt = (int)timeRemaining;
        timeText.text = timeRemainingInt.ToString();

        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (timeRemaining > 0 && bossDead == false)
        {
            timeRemaining -= Time.deltaTime;
        }

        if(timeRemaining <= 0)
        {
            timeRemaining = 0;

            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }

        if(bossDead)
        {
            timeText.enabled = false;
            bossAnomalies.SetActive(false);
            level4musicloop.Stop();
            clockSound.Stop();
        }

        if(timeRemaining <= 5)
        {
            alarmSound.SetActive(true);
        }

        if(level3Ctrl.GetComponent<Level3Controller>().levelFinal == false)
        {
            if (player.GetComponent<PlayerStats>().hit == true && player.GetComponent<PlayerStats>().hitStopper == false)
            {
                if (pleaseStop == false)
                {
                    timeRemaining -= 5;
                    stopTimer = 1;
                    pleaseStop = true;
                }
            }
        }

        if (level3Ctrl.GetComponent<Level3Controller>().levelFinal == true)
        {
            if (playerBoss.GetComponent<PlayerStats>().hit == true && playerBoss.GetComponent<PlayerStats>().hitStopper == false)
            {
                if (pleaseStop == false)
                {
                    timeRemaining -= 5;
                    stopTimer = 1;
                    pleaseStop = true;
                }
            }
        }

        if (bossCollider.GetComponent<BossCollider>().hit == true && bossCollider.GetComponent<BossCollider>().hitStopper == false)
        {
            if (pleaseStop2 == false)
            {
                timeRemaining += 10;
                stopTimer2 = 0.2f;
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
            orbTimer = 10f;
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

        //For Level 2
        if(player2.GetComponent<Level2Collision>().one == true && !done1)
        {
            timeRemaining += 5;
            done1 = true;
        }
        if (player2.GetComponent<Level2Collision>().two == true && !done1)
        {
            timeRemaining -= 10;
            done1 = true;
        }
        if (player2.GetComponent<Level2Collision>().three == true && !done2)
        {
            timeRemaining += 15;
            done2 = true;
        }
        if (player2.GetComponent<Level2Collision>().four == true && !done2)
        {
            timeRemaining -= 5;
            done2 = true;
        }
        if (player2.GetComponent<Level2Collision>().five == true && !done3)
        {
            timeRemaining += 10;
            done3 = true;
        }
        if (player2.GetComponent<Level2Collision>().six == true && !done3)
        {
            timeRemaining += 5;
            done3 = true;
        }

        if (player2.GetComponent<Level2Collision>().endLevel2 == true)
        {
            player2.SetActive(false);
            level1.SetActive(false);
            level3map.SetActive(true);
            level3 = true;
        }

        if(level3 == true)
        {
            level3Timer -= Time.deltaTime;

            if(level3Timer <= 0)
            {
                tpAnim.SetActive(false);
                tpAnim2.SetActive(false);
            }
        }
    }
}
