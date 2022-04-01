using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class DialogueTrigger : MonoBehaviour
{
    
    [SerializeField] public GameObject x_Text;
    
    public Dialogue dialogue;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var gamepad = Gamepad.current;
            if (gamepad.buttonSouth.wasPressedThisFrame)
            {
                Debug.Log("Triggered Dialogue");
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
        }
    }
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
