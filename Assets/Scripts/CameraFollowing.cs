using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    public Transform player;
    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y >= -6)
        {
            transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        } else
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        }
    }
}
