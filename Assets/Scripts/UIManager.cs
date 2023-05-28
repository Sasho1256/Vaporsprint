using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Image blackOutSquare;
    private AudioManager audioManager;
    public GameObject menuScreen;

    private void Start()
    {
        audioManager = AudioManager.instance;
        Time.timeScale = 1f; //make sure time is never stopped on start
    }

    private void Awake()
    {
        menuScreen.SetActive(false); //disable pause menu on start
    }

    void Update()
    {

        //open/close menu on esc
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menuScreen.activeInHierarchy)
            {
                //close menu
                menuScreen.SetActive(false);
                Time.timeScale = 1f; //resume time
            }
            else
            {
                //open menu
                menuScreen.SetActive(true);
                Time.timeScale = 0f; //stop time
            }
        }
    }

    public IEnumerator TransitionToDeathScreen()
    {
        yield return StartCoroutine(FadeBlackOutSquareIn(1f, 0.5f));
        audioManager.StopAll();
        audioManager.Play("GameOverTheme");
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
