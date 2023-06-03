using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    private AudioManager audioManager;
    
    private void Awake()
    {
        audioManager = AudioManager.instance;
    }

    public void Play()
    {
        StartCoroutine(LoadGame());
    }

    private IEnumerator LoadGame()
    {
        audioManager.Play("Confirmation");
        while (audioManager.getAudioSource("Confirmation").isPlaying)
            yield return null;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        audioManager.Play("Confirmation");
        Application.Quit();
    }
}
