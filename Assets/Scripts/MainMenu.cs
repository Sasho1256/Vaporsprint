using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    private AudioManager audioManager;
    private void Awake()
    {
        audioManager = AudioManager.instance;
        audioManager.Play("MainMenuTheme");
    }

    public void Play()
    {
        StartCoroutine(LoadScene());
    }

    public void Settings()
    {
        StartCoroutine(LoadSceneByName("OptionsMenu"));
    }

    private IEnumerator LoadScene()
    {
        audioManager.Play("Confirmation");
        while (audioManager.getAudioSource("Confirmation").isPlaying)
            yield return null;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private IEnumerator LoadSceneByName(string name)
    {
        audioManager.Play("Confirmation");
        while (audioManager.getAudioSource("Confirmation").isPlaying)
            yield return null;
        SceneManager.LoadScene(name);
    }
}
