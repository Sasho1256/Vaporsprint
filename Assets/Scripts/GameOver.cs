using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public static bool gameOver = false;

    void Start()
    {
        gameOver = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision");
        gameOver = true;
    }
}
