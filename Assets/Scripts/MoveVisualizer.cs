using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveVisualizer : MonoBehaviour
{
    public Transform player;

    //public float y;
    //public float z;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
    }
}
