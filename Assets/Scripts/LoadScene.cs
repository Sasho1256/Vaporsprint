using System.Collections;
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

    public void loadSceneMenu(string sceneName)
    {
        loadScene(sceneName);
        UIManager.menuIsOpen = false;
    }

    public void reLoadScene()
    {
        loadScene(GameOver.curScene);
    }

    private IEnumerator waitForSoundAndLoad(string sceneName)
    {
        audioManager.Play(loadingSound);
        while (audioManager.getAudioSource(loadingSound).isPlaying)
            yield return null;
        SceneManager.LoadScene(sceneName);
    }
}
