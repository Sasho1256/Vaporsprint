using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public static bool gameOver = false;
    public static bool deathByObstacle;
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
        gameOver = true;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //audioManager.Play("Death");
        Debug.Log("Collision");
        gameOver = true;
        deathByObstacle = true;
    }
}
