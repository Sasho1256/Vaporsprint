using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Image blackOutSquare;

    private AudioManager audioManager;

    private void Start()
    {
        audioManager = AudioManager.instance;
        blackOutSquare = FindObjectOfType<Image>();
    }
    void Update()
    {
        if (GameOver.gameOver == true)
        {
            StartCoroutine(TransitionToDeathScreen());
        }
    }

    IEnumerator TransitionToDeathScreen()
    {
        yield return StartCoroutine(FadeBlackOutSquareIn(1f, 0.5f));


        SceneManager.LoadScene("GameOver");
    }

    IEnumerator FadeBlackOutSquareIn(float targetAlpha, float duration)
    {
        float alpha = blackOutSquare.color.a;

        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / duration)
        {
            Color newColor = new Color(blackOutSquare.color.r, blackOutSquare.color.g, blackOutSquare.color.b, Mathf.Lerp(alpha, targetAlpha, t));
            blackOutSquare.color = newColor;
            yield return null;
        }

        blackOutSquare.color = new Color(blackOutSquare.color.r, blackOutSquare.color.g, blackOutSquare.color.b, targetAlpha);
    }
}
