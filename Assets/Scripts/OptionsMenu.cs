using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class OptionsMenu : MonoBehaviour
{
    public AudioSource myAudioSource;

    public void MusicUpload()
    {
        
    }

    public void MainMenu()
    {
        StartCoroutine(LoadSceneByName("MainMenu"));
    }

    private IEnumerator LoadSceneByName(string name)
    {
        myAudioSource.Play();
        while (myAudioSource.isPlaying)
            yield return null;
        SceneManager.LoadScene(name);
    }
}
