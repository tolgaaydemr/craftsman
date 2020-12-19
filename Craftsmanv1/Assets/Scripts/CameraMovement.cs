using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //public GameObject player;
    private Transform player;

    private float yOffset = 2.03f;
    private float zOffset = -1.92f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y + yOffset, player.position.z + zOffset);

    }
}
