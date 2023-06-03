using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class OptionsMenu : MonoBehaviour
{
    private AudioManager audioManager;

    private void Awake()
    {
        audioManager = AudioManager.instance;
    }

    public void Mute()
    {   
        audioManager.MuteOrUnmute();
    }

    public void MainMenu()
    {
        StartCoroutine(LoadSceneByName("MainMenu"));
    }

    private IEnumerator LoadSceneByName(string name)
    {
        audioManager.Play("Confirmation");
        while (audioManager.getAudioSource("Confirmation").isPlaying)
            yield return null;
        SceneManager.LoadScene(name);
    }
}
