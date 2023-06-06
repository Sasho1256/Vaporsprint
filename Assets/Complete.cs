using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;

public class Complete : MonoBehaviour
{
    [HideInInspector]
    public UIManager uiManager;
    public static string nextLevel; //level passed by main 

    //buttons to modify
    public Button menuBtn;
    public Button nextBtn;

    //util 
    private static bool hasNextLevel;
    private AudioManager audioManager;



    private void Start()
    {
        Debug.Log(nextLevel);
        audioManager = AudioManager.instance;
        hasNextLevel = nextLevel != null;
        //if there is no next level, disable button
        if (!hasNextLevel)
        {
            Debug.Log("no next lvl");
            nextBtn.transform.SetParent(null);

            //Set the x position to 0
            Vector3 newPosition = new Vector3(0f, menuBtn.transform.localPosition.y, menuBtn.transform.localPosition.z);
            //Apply the updated position to the button
            menuBtn.transform.localPosition = newPosition;
        }
    }

    public void NextLevel()
    {
            audioManager.StopAll();
            SceneManager.LoadScene(nextLevel);
    }
}
