using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Image blackOutSquare; //the square covering the view
    private AudioManager audioManager;
    private string menu = "TransparentOptionsMenu"; //the scene to be loaded in as the pause menu
    [HideInInspector]
    public static bool menuIsOpen = false;

    private void Start()
    {
        audioManager = AudioManager.instance;
        Time.timeScale = 1f; //make sure time is never stopped on start
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

    public IEnumerator OpenInGameMenu() //will load the in game menu and pause activity until it is loaded
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(menu, LoadSceneMode.Additive);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        Time.timeScale = 0f; //stop time / pause game
        menuIsOpen = true;
        Scene pauseMenu = SceneManager.GetSceneByName(menu);
        if (pauseMenu.IsValid() && pauseMenu.isLoaded)
        {
            InGameMenu.level = SceneManager.GetActiveScene().name; //pass the level variable to the pause menu
        }
    }

    public IEnumerator CloseInGameMenu() //will unload the in game menu and pause activity until it is done
    {
        AsyncOperation asyncUnLoad = SceneManager.UnloadSceneAsync(menu);
        while (!asyncUnLoad.isDone)
        {
            yield return null;
        }
        Time.timeScale = 1f; //start time / unpause game
        menuIsOpen = false;
    }

    public IEnumerator TransitionToDeathScreen() //begins the transition to death screen
    {
        if(GameOver.deathByObstacle) //if player died to an obstacle (as opposed to falling) play a death noise
        {
            audioManager.Play("Death");
        }
        yield return StartCoroutine(FadeBlackOutSquareIn(1f, 0.5f)); //start transitioning screen to black
        //this will execute once screen is blacked out
        audioManager.StopAll(); 
        audioManager.Play("GameOverTheme"); //start playing the game over theme
        SceneManager.LoadScene("GameOver"); //load game over scene
        Destroy(this.gameObject);
    }

    public IEnumerator TransitionToCompleteScreen()
    {
        yield return StartCoroutine(FadeBlackOutSquareIn(1f, 0.5f));

        //this will execute once screen is blacked out
        SceneManager.LoadScene("LvlComplete", LoadSceneMode.Additive);
           
        //getting the scene name at next buildindex
        int nextSceneBuildIndex = SceneManager.GetActiveScene().buildIndex + 1;
        string nextScenePath = SceneUtility.GetScenePathByBuildIndex(nextSceneBuildIndex);
        string nextLevel = System.IO.Path.GetFileNameWithoutExtension(nextScenePath);

        //finding the next level for the "next level" button in the "level complete" scene
        if (nextLevel.Contains("Level")) 
        {
            Complete.nextLevel = nextLevel; //passing the level name to the "level complete" scene
        } else
        {
            Complete.nextLevel = null; //passing null -> no next level
        }
        Time.timeScale = 0f;
    }

    //gradually fades in the usually invisible black square covering the view (to a given darkness/alpha value)
    public IEnumerator FadeBlackOutSquareIn(float targetAlpha, float duration)
    {
        float alpha = blackOutSquare.color.a; //getting current álpha channel value of square

        //increase the alpha value bit by Time.deltaTime / duration each iteration
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / duration)
        {
            Color newColor = new Color(blackOutSquare.color.r, blackOutSquare.color.g, blackOutSquare.color.b, Mathf.Lerp(alpha, targetAlpha, t));
            blackOutSquare.color = newColor;
            yield return null;
        }

        blackOutSquare.color = new Color(blackOutSquare.color.r, blackOutSquare.color.g, blackOutSquare.color.b, targetAlpha);
    }
}
