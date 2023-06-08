using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Recorder;
using UnityEngine;
using UnityEngine.UI;

public class ScoringManagerImage : MonoBehaviour
{
    Image imageField;

    // Start is called before the first frame update
    void Start()
    {
        imageField = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        float score = GameScore.gameScore; 
        score = Mathf.FloorToInt(score); //gets the score in %

        if(GameOver.gameOver) //chooses the image with a certain amount of golden stars depending on the score
        {

            if (score < 25)
            {
                Sprite score_0 = Resources.Load <Sprite>("score_0");
                imageField.sprite = score_0;
            } else if(score < 50)
            {
                Sprite score_25 = Resources.Load<Sprite>("score_25");
                imageField.sprite = score_25;
            } else if(score < 75)
            {
                Sprite score_50 = Resources.Load<Sprite>("score_50");
                imageField.sprite = score_50;
            } else if(score < 100)
            {
                Sprite score_75 = Resources.Load<Sprite>("score_75");
                imageField.sprite = score_75;
            } else if(score == 100)
            {
                Sprite score_100 = Resources.Load<Sprite>("score_100");
                imageField.sprite = score_100;
            }
        }
    }
}
