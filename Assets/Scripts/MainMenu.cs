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
        StartCoroutine(LoadSelector()); 
    }

    //plays button press sound and then loads the level selector
    private IEnumerator LoadSelector()
    {
        audioManager.Play("Confirmation");
        while (audioManager.getAudioSource("Confirmation").isPlaying)
            yield return null;
        //LoadScene executes once "Confirmation" sound has finished playing
        SceneManager.LoadScene("LvlSelect");
    }

    //closes the game on press of the "Quit" button
    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit(); 
        #endif

    }

}