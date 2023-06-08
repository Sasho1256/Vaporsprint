using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public static bool gameOver = false;
    public static bool deathByObstacle;
    public static string curScene;
    [HideInInspector]
    public AudioManager audioManager;

    void Start()
    {
        audioManager = AudioManager.instance;
        gameOver = false; //make sure gameOver state is reset on retry
        deathByObstacle = false;
    }

    //on death by falling
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision");
        curScene = SceneManager.GetActiveScene().name; //store current scene for "retry" button to load again
        gameOver = true;
    }

    //on death by enemy/obstacle
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collision");
        curScene = SceneManager.GetActiveScene().name;  //store current scene for "retry" button to load again
        gameOver = true;
        deathByObstacle = true;
    }
}
