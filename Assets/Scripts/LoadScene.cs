using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{

    [SerializeField]
    private string sceneName;
    public string[] soundsToStop;
    private AudioManager audioManager = AudioManager.instance;

    public void loadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        //audioManager = AudioManager.instance;
        foreach (string sound in soundsToStop)
        {
            audioManager.StopPlaying(sound);
        }
    }

    public void LoadSceneWithConfirmationSound(string sceneName)
    {
        StartCoroutine(LoadSceneByName(sceneName));
    }

    private IEnumerator LoadSceneByName(string name)
    {
        audioManager.Play("Confirmation");
        while (audioManager.getAudioSource("Confirmation").isPlaying)
            yield return null;
        loadScene(sceneName);
    }
}
