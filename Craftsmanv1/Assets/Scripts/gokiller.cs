using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gokiller : MonoBehaviour
{
    void Start()
    {
        transform.position = new Vector3(1f, -0.664f, -21.76f);
    }
    // Burası github tarafından algılandı.
    // Update is called once per frame
    void Update()
    {
        if (PlayerController.sayac == 0)
            transform.position = new Vector3(1.3835f, 0.8119f, -22.09f);
        else if(PlayerController.sayac!=0)
            transform.position = new Vector3(1f, -0.664f, -21.76f);
    }
}
