using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class BossMusic : MonoBehaviour
{
    public AudioSource intro;
    public AudioSource loop;
    private bool startedLoop;

    void FixedUpdate()
    {
        if (!intro.isPlaying && !startedLoop)
        {
            loop.Play();
            startedLoop = true;
        }
    }
}
