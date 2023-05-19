using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveVisualizer : MonoBehaviour
{
    public Transform player;

    public int x;
    public int y;
    public int z;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, 0, 0);
    }
}
