using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float movementRange; // movement to the left on the x-axis 
    public float speed; //speed of moving object
    public bool goRight; //is true if the object is headed to the right side
    public int enemyID;  // 0 = Bomb; 1 = Diagonal Laser; 2 = Horizontal Laser

    private Vector3 startpos;

    void Start()
    {
        if (goRight)
            if (enemyID == 0 || enemyID == 2)
                startpos = transform.position + new Vector3(movementRange, 0, 0);
            else
                startpos = transform.position + new Vector3(movementRange, movementRange, 0);
        else
            startpos = transform.position;
    }

    void Update() //handles the movement of all enemies depending on their IDs (is called once per frame)
    {
        if (!GameOver.gameOver)
            if (enemyID == 0)
                MoveBomb();
            else if (enemyID == 1)
                MoveDiagonalLaser();
            else if (enemyID == 2)
                MoveHorizontalLaser();
    }

    private void MoveHorizontalLaser()
    {
        if (goRight)
        {
            if (transform.position.x < startpos.x)
            {
                transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            }
            else
            {
                transform.position = startpos - new Vector3(movementRange, 0, 0);
            }
        }
        else
        {
            if (transform.position.x > startpos.x - movementRange)
            {
                transform.position += new Vector3(-1 * speed * Time.deltaTime, 0, 0);
            }
            else
            {
                transform.position = startpos;
            }
        }
    }

    private void MoveDiagonalLaser()
    {
        if (goRight)
        {
            if (transform.position.x < startpos.x)
            {
                transform.position += new Vector3(speed * Time.deltaTime, speed * Time.deltaTime, 0);
            }
            else
            {
                transform.position = startpos - new Vector3(movementRange, movementRange, 0);
            }
        }
        else
        {
            if (transform.position.x > startpos.x - movementRange)
            {
                transform.position += new Vector3(-1 * speed * Time.deltaTime, speed * Time.deltaTime, 0);
            }
            else
            {
                transform.position = startpos;
            }
        }
    }

    private void MoveBomb()
    {
        if (goRight)
        {
            if (transform.position.x < startpos.x)
            {
                transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            }
            else
            {
                goRight = false;
            }
        }
        else
        {
            if (transform.position.x > startpos.x - movementRange)
            {
                transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
            }
            else
            {
                goRight = true;
            }
        }
    }
}
