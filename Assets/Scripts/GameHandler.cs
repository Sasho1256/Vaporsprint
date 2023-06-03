using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameHandler : MonoBehaviour
{
    public string themeSoundName;

    public UIManager uiManager;
    [HideInInspector]
    public AudioManager audioManager;
    [HideInInspector]
    private bool transitionDone = false;

    // Start is called before the first frame update

    private void Awake()
    {
        audioManager = AudioManager.instance;
    }
    void Start()
    {
        Debug.Log("GameHandler Started");
        
        if (audioManager.getAudioSource(themeSoundName) == null || !audioManager.getAudioSource(themeSoundName).isPlaying)
        {
            audioManager.StopAll();
            audioManager.Play(themeSoundName);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameOver.gameOver == true)
        {   

            if (!transitionDone)
            {
                transitionDone = true;
                StartCoroutine(uiManager.TransitionToDeathScreen());
            }
        }
    }
}
