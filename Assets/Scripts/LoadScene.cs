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
    public string loadingSound = "Confirmation";
    private AudioManager audioManager;

    public void Start()
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
        audioManager.Play(loadingSound);
        while (audioManager.getAudioSource(loadingSound).isPlaying)
            yield return null;
        SceneManager.LoadScene(sceneName);
    }
}
