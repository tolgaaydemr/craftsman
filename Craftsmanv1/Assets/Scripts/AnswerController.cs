using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerController : MonoBehaviour
{

    public void trueAns()
    {
        PlayerController.ans = "Dogru";
    }
    public void falseAns()
    {
        PlayerController.ans = "Yanlis";
    }
}
