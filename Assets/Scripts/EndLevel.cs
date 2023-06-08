using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    public UIManager uiManager;

    //this script is used on the portal GameObject
    //therefore the function below checks for collision with the player,
    //i.e. player enters portal/reaches end of level, and then loads the "level complete" screen
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(uiManager.TransitionToCompleteScreen());
        }
    }
}
