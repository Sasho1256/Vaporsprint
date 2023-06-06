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
        gameOver = false;
        deathByObstacle = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision");
        curScene = SceneManager.GetActiveScene().name;
        gameOver = true;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collision");
        curScene = SceneManager.GetActiveScene().name;
        gameOver = true;
        deathByObstacle = true;
    }
}
