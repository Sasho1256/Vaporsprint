using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScore : MonoBehaviour
{
    public static float gameScore;

    private void Update()
    {
        if(GameOver.gameOver)
        {
            float tmp = 0;
            float distanceLeftToPlayer = Mathf.Abs(GameObject.Find("LeftMapBound").transform.position.x) + GameObject.Find("Player").transform.position.x;
            float totalLevelDistance = GameObject.Find("RightMapBound").transform.position.x - GameObject.Find("LeftMapBound").transform.position.x;
            tmp = (distanceLeftToPlayer / totalLevelDistance) * 100;
            if(tmp > 100)
            {
                gameScore = 99;
            } else if(tmp < 0)
            {
                gameScore = 0;
            } else
            {
                gameScore = tmp;
            }
        }
    }
}
