using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{

    [SerializeField]
    private string sceneName;
    public string[] soundsToStop;
    public string loadingSound = "Confirmation"; //sound to play on button press / scene loading
    private AudioManager audioManager;

    public void Start()
    {
       audioManager = AudioManager.instance;
    }

    //play loadingSound, afterwards stop specified sounds in scene and load new scene
    public void loadScene(string sceneName) 
    {
        StartCoroutine(waitForSoundAndLoad(sceneName));
        foreach (string sound in soundsToStop)
        {
            audioManager.StopPlaying(sound);
        }
    }

    //used for "continue" button in pause menu. Will unload the menu without "esc" press and updates state
    public void loadSceneMenu(string sceneName)
    {
        loadScene(sceneName);
        UIManager.menuIsOpen = false;
    }

    public void reLoadScene()
    {
        loadScene(GameOver.curScene);
    }

    //plays loadingsound and loads a scene afterwards
    private IEnumerator waitForSoundAndLoad(string sceneName)
    {
        audioManager.Play(loadingSound);
        while (audioManager.getAudioSource(loadingSound).isPlaying)
            yield return null;
        SceneManager.LoadScene(sceneName);
    }
}
