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
            GameStateManager.Instance.SetState(GameState.Paused);

            GameObject.Find(LineUpController.NPCName).transform.position = LineUpController.NPCPosition;
            GameObject.Find(LineUpController.NPCName).GetComponent<DialogueTrigger>().IsTalking = true;
            GameObject.Find(LineUpController.NPCName).GetComponent<DialogueTrigger>().DidLoose = true;
            GameObject.Find(LineUpController.NPCName).GetComponent<DialogueTrigger>().NpcType = NpcType.Neutral;
            GameObject.Find(LineUpController.NPCName).GetComponent<DialogueTrigger>().TalkState = TalkState.TalkWithX;
            GameObject.Find(LineUpController.NPCName).GetComponent<SphereCollider>().enabled = true;
            GameObject.Find(LineUpController.NPCName).GetComponent<BoxCollider>().enabled = false;

            GameObject.FindGameObjectWithTag("Player").transform.position = LineUpController.PlayerPosition;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().DialogueState = DialogueState.Talking;

            Vector3 npcDirection = GameObject.FindGameObjectWithTag("Player").transform.position - GameObject.Find(LineUpController.NPCName).transform.position;
            Quaternion npcRotation = Quaternion.LookRotation(npcDirection);
            GameObject.Find(LineUpController.NPCName).transform.rotation = npcRotation;

            Vector3 playerDirection = GameObject.Find(LineUpController.NPCName).transform.position - GameObject.FindGameObjectWithTag("Player").transform.position;
            Quaternion playerRotation = Quaternion.LookRotation(playerDirection);
            GameObject.FindGameObjectWithTag("Player").transform.rotation = playerRotation;

            GameObject.Find(LineUpController.NPCName).GetComponent<Animator>().SetBool("IsWalking", false);
        }
        LineUpController.NPCName = null;
    }

    public void SaveGame()
    {
        ES3AutoSaveMgr.Current.Save();
    }
}
