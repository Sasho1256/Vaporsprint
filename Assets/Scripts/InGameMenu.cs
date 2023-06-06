using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{   
    //sorry for this extra script, could be made cleaner by also not destroying UImanager on load
    //but then it gets weird with the menus... This circumvents having UIManager everywhere
    private AudioManager audioManager;

    [HideInInspector]
    public static string level;

    private void Awake()
    {
        audioManager = AudioManager.instance;
    }

    public void Continue()
    {
        Scene mainScene = SceneManager.GetSceneByName(level);
        if (mainScene.IsValid() && mainScene.isLoaded)
        {
            UIManager.menuIsOpen = false;
        }
        SceneManager.UnloadSceneAsync("TransparentOptionsMenu");
        Time.timeScale = 1.0f;
    }

    public void Mute()
    {
        audioManager.MuteOrUnmute();
    }
}
