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
    private AudioManager audioManager;

    public void Awake()
    {
       audioManager = AudioManager.instance;
    }

    public void loadScene(string sceneName)
    {
        StartCoroutine(waitForSoundAndLoad(sceneName));
        foreach (string sound in soundsToStop)
        {
            audioManager.StopPlaying(sound);
        }

    }

    private IEnumerator waitForSoundAndLoad(string sceneName)
    {   
        while (audioManager.getAudioSource("Confirmation").isPlaying)
            yield return null;
        SceneManager.LoadScene(sceneName);
    }
}
