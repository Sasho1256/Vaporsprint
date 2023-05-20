using UnityEngine;
using System.Collections;

public class PlaySound : MonoBehaviour
{
    public AudioSource myAudioSource;
    public MainMenu sceneLoader;

    public void PlayAudio()
    {
        StartCoroutine(PlayAudioAndWait());
    }

    IEnumerator PlayAudioAndWait()
    {
        myAudioSource.Play();
        while (myAudioSource.isPlaying)
            yield return null;

        sceneLoader.Play();
    }
}
