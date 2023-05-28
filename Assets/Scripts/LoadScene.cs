using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{

    [SerializeField]
    private string sceneName;
    public string[] soundsToStop;
    private AudioManager audioManager;

    public void loadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        audioManager = AudioManager.instance;
        foreach (string sound in soundsToStop)
        {
            audioManager.StopPlaying(sound);
        }
    }


}
