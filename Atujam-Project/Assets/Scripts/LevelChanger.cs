using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;
    private int levelToLoad;
    string sceneName;

    float timer = 19f;
    
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        sceneName = currentScene.name;

        Cursor.visible = false;
    }


    void Update()
    {
        Debug.Log(Time.timeAsDouble);

        if (Time.timeAsDouble >= (double) 12f && sceneName == "BeginningScene")
        {
            FadeToLevel(1);
        }
        else if (Time.timeAsDouble >= (double) 18f && sceneName == "Beginning2Scene")
        {
            FadeToLevel(2);
        }

        else if (Time.timeAsDouble >= (double) 23f && sceneName == "Beginning3Scene")
        {
            FadeToLevel(3);
        }

        else if (sceneName == "EndScene")
        {
            timer -= Time.deltaTime;

            if(timer <= 0)
            {
                FadeToLevel(5);
            }
        }
    }

    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");

    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
