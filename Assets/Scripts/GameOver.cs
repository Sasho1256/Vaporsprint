using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{   
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Test");

        // Destroy AudioManager instance
        if (AudioManager.instance != null)
            Destroy(AudioManager.instance.gameObject);

        SceneManager.LoadScene("GameOver");
    }
}
