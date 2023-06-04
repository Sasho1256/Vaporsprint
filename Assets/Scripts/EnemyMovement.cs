using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float movementRange; // movement to the left on the x-axis 
    public float speed;
    public bool goRight; //is true if the object is headed to the right side
    private Vector3 startpos;

    void Start()
    {
        if (goRight)
            startpos = transform.position + new Vector3(movementRange, 0, 0);
        else 
            startpos = transform.position;
    }

    void Update()
    {
        if (IsInCameraView() && !GameOver.gameOver)
            Move();
    }

    private void Move()
    {
        if (!goRight)
        {
            if (transform.position.x > startpos.x - movementRange)
            {
                transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
            } else
            {
                goRight = true;
            }
        }
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
    }

    private bool IsInCameraView()
    {
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position);
        if (screenPoint.z >= 0 && screenPoint.x >= -3 && screenPoint.x <= 3 && screenPoint.y >= -3 && screenPoint.y <= 3)
        {
            // The object is in the range of the camera + an overhead
            return true;
        }
        else
        {
            return false;
        }
    }
}
