using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPencil : MonoBehaviour
{

    public AudioSource attack;

    void AudioAttack()
    {
        attack.Play();
    }
}
