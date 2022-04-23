using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    private void Start()
    {
        if (GameObject.Find(LineUpController.NPCName))
        {
            GameObject.Find(LineUpController.NPCName).transform.position = LineUpController.NPCPosition;
            GameObject.Find(LineUpController.NPCName).GetComponent<DialogueTrigger>().IsTalking = true;

            GameObject.FindGameObjectWithTag("Player").transform.position = LineUpController.PlayerPosition;
        }
        LineUpController.NPCName = null;
    }
}
