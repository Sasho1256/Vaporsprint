using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class Complete : MonoBehaviour
{
    [HideInInspector]
    public UIManager uiManager;
    public static string level; //level passed by main 

    void NextLevel()
    {
        //load next level - note: need to change upper limit if level n is increased beyond 3

    }
}
