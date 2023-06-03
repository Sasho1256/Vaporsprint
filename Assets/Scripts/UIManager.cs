using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Image blackOutSquare;
    private AudioManager audioManager;
    private string menu = "TransparentOptionsMenu";
    private bool menuIsOpen = false;

    private void Start()
    {
        audioManager = AudioManager.instance;
        Time.timeScale = 1f; //make sure time is never stopped on start
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        //open/close menu on esc
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menuIsOpen) 
            {
                StartCoroutine(CloseInGameMenu());
            }
            else
            {
                StartCoroutine(OpenInGameMenu());
            }
        }
    }

    public IEnumerator OpenInGameMenu()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(menu, LoadSceneMode.Additive);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        Time.timeScale = 0f;
        menuIsOpen = true;
    }

    public IEnumerator CloseInGameMenu()
    {
        AsyncOperation asyncUnLoad = SceneManager.UnloadSceneAsync(menu);
        while (!asyncUnLoad.isDone)
        {
            yield return null;
        }
        Time.timeScale = 1f;
        menuIsOpen = false;
    }

    public IEnumerator TransitionToDeathScreen()
    {
        yield return StartCoroutine(FadeBlackOutSquareIn(1f, 0.5f));
        audioManager.StopAll();
        audioManager.Play("GameOverTheme");
        SceneManager.LoadScene("GameOver");
        Destroy(this.gameObject);
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
