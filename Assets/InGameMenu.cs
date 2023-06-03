using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{   
    //sorry for this extra script, could be made cleaner by also not destroying UImanager on load
    //but then it gets weird with the menus... This circumvents having UIManager everywhere
    private AudioManager audioManager;

    private void Awake()
    {
        audioManager = AudioManager.instance;
    }

    public void Continue()
    {
        SceneManager.UnloadSceneAsync("TransparentOptionsMenu");
        Time.timeScale = 1.0f;
    }

    public void Mute()
    {
        audioManager.MuteOrUnmute();
    }
}
