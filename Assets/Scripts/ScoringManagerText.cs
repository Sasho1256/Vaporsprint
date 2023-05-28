using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoringManagerText : MonoBehaviour
{
    TextMeshProUGUI inputField;
    // Start is called before the first frame update
    void Start()
    {
        inputField = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        float score = GameScore.gameScore;
        score = Mathf.FloorToInt(score);
        if (GameOver.gameOver)
        {
            inputField.text = score.ToString() + " Percent";
        }
    }
}
