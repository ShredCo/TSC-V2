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
            GameObject.Find(LineUpController.NPCName).GetComponent<DialogueTrigger>().DidLoose = true;
            GameObject.Find(LineUpController.NPCName).GetComponent<DialogueTrigger>().NpcType = NpcType.Neutral;

            GameObject.FindGameObjectWithTag("Player").transform.position = LineUpController.PlayerPosition;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().DialogueState = DialogueState.Talking;

            GameStateManager.Instance.SetState(GameState.Paused);
        }
        LineUpController.NPCName = null;
    }
}
