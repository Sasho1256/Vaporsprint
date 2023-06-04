using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveVisualizer : MonoBehaviour
{
    public Transform player;
    public int backgroundID;

    //public float y;
    //public float z;

    // Update is called once per frame
    void Update()
    {
        if(player.position.y > -3){
            if (backgroundID == 0)
            {
                transform.position = new Vector3(player.transform.position.x, (player.transform.position.y+5.86f*2)/2, transform.position.z);
            }
            if (backgroundID == 1)
            {
                transform.position = new Vector3(player.transform.position.x, (player.transform.position.y+5.37f*2)/2, transform.position.z);
            }
            if (backgroundID == 2)
            {
                transform.position = new Vector3(player.transform.position.x, (player.transform.position.y-5.52f*2)/2, transform.position.z);
            }
            if (backgroundID == 3)
            {
                transform.position = new Vector3(player.transform.position.x, (player.transform.position.y-16.63f*2)/2, transform.position.z);
            }
        }
        else{
            transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        }
    }
}
