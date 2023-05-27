using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public static bool gameOver = false;
    public static bool deathByObstacle;

    void Start()
    {
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
        Debug.Log("Collision");
        gameOver = true;
        deathByObstacle = true;
    }
}
