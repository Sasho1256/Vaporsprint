using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScore : MonoBehaviour
{
    public static float gameScore;

    private void Update() //calculates the progress of the player within a level in %
    {
        if(GameOver.gameOver)
        {
            float tmp = 0;
            float distanceLeftToPlayer = Mathf.Abs(GameObject.Find("LeftMapBound").transform.position.x) + GameObject.Find("Player").transform.position.x; //already covered distance by the player
            float totalLevelDistance = GameObject.Find("RightMapBound").transform.position.x - GameObject.Find("LeftMapBound").transform.position.x; //total distance on the x-axis of the level
            tmp = (distanceLeftToPlayer / totalLevelDistance) * 100;
            if(tmp > 100) //handles the case of the player jumping beyond the end portal
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
