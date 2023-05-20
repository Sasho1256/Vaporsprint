using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    public AudioSource myAudioSource;

    public void Play()
    {
        StartCoroutine(LoadScene());
    }

    private IEnumerator LoadScene()
    {
        myAudioSource.Play();
        while (myAudioSource.isPlaying)
            yield return null;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
