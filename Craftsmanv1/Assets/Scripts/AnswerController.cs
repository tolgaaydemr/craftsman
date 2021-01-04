using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerController : MonoBehaviour
{

    public void trueAns()
    {
        PlayerController.ans = "Dogru";
        //Debug.Log(ans);
    }
    public void falseAns()
    {
        PlayerController.ans = "Yanlis";
        //Debug.Log(ans);
    }
}
