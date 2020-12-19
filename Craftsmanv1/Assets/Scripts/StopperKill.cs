using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopperKill : MonoBehaviour
{
    void Start()
    {
        transform.position = new Vector3(1.139f, 0.200f, -22.842f);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.sayac == 0)
            transform.position = new Vector3(1.139f, -0.663f, -22.842f);
        else
            transform.position = new Vector3(1.139f, 0.200f, -22.842f);
    }
}
