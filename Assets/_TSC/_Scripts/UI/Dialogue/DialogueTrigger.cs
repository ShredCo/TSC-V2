using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public enum NpcType
{
    Neutral,
    Agressive,
    Workshop
}

public class DialogueTrigger : MonoBehaviour
{
    public static DialogueTrigger instance;
    
    public NPCInventory NPCInventory;
    public InventoryObject PlayerInventory;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    [SerializeField] public GameObject x_Text;
    
    public Dialogue dialogue;
    
    public NpcType NpcType;

    public DialogueState dialogueState;
    public bool IsTalking;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Interact with a NPC
            var gamepad = Gamepad.current;
            if (gamepad.buttonSouth.wasPressedThisFrame && IsTalking == false)
            {
                TriggerDialogue();
                x_Text.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            x_Text.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            x_Text.SetActive(false);
            IsTalking = false;
        }
    }
    public void TriggerDialogue()
    {
        if (NPCInventory != null)
        {
            NPCInventory.SetNPCLineUp();
            PlayerInventory.SavePlayerLineUp();
        }
        IsTalking = true;
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        FindObjectOfType<DialogueManager>().npcType = NpcType;
    }
}
