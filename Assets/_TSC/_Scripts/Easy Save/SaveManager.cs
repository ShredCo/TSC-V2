using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    private void Start()
    {
        if (GameObject.Find(LineUpController.NPCName))
            GameObject.Find(LineUpController.NPCName).transform.position = LineUpController.NPCPosition;
        LineUpController.NPCName = null;
    }
}
