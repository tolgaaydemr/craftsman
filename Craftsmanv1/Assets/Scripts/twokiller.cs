using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class twokiller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(1f, -0.664f, -21.76f);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.sayac == 2)
            transform.position = new Vector3(1f, 1.03f, -21.76f);
        else
            transform.position = new Vector3(1f, -0.664f, -21.76f);
    }
}
