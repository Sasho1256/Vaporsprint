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
            float distanceLeftToPlayer = Mathf.Abs(GameObject.Find("LeftMapBound").transform.position.x) + GameObject.Find("Player").transform.position.x;
            float totalLevelDistance = GameObject.Find("RightMapBound").transform.position.x - GameObject.Find("LeftMapBound").transform.position.x;
            gameScore = (distanceLeftToPlayer / totalLevelDistance) * 100;
        }
    }
}
