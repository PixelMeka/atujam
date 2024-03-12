using UnityEngine;
using System.Collections;

public class AudioFadeOut : MonoBehaviour
{

    public AudioSource music;

    void Start()
    {
        IEnumerator fadeSound1 = AudioFadeOut.FadeOut(music, 20f);
        StartCoroutine(fadeSound1);
    }
    

    public static IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume;
    }

}
