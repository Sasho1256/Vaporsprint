using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    [SerializeField]
    //private string sceneName;
    private AudioManager audioManager;

    public IEnumerator LoadGame()
    {
        while (audioManager.getAudioSource("Confirmation").isPlaying)
            yield return null;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public IEnumerator LoadSceneByName(string name)
    {
        audioManager.Play("Confirmation");
        while (audioManager.getAudioSource("Confirmation").isPlaying)
            yield return null;
        SceneManager.LoadScene(name);
    }

}
