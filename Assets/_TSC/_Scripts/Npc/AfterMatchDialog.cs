using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterMatchDialog : MonoBehaviour
{
    void Start()
    {
        if (LineUpController.DidWin == true)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(LineUpController.AfterMatchDialogue);
        }
    }
}
