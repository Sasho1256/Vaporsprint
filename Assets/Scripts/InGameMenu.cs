using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{   
    private AudioManager audioManager;

    [HideInInspector]
    public static string level; //current level passed by UIManager

    private void Awake()
    {
        audioManager = AudioManager.instance;
    }

    public void Continue()
    {
        Scene mainScene = SceneManager.GetSceneByName(level);
        if (mainScene.IsValid() && mainScene.isLoaded) //if the level is still valid and loaded allow closing of pause menu
        {
            UIManager.menuIsOpen = false;
            SceneManager.UnloadSceneAsync("TransparentOptionsMenu"); //unload the pause menu
            Time.timeScale = 1.0f;
        }
    }

    //method for the mute button
    public void Mute()
    {
        audioManager.MuteOrUnmute();
    }
}
