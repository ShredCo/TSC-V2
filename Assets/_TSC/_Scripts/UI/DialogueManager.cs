using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public GameObject firstSelectedButtonDialoge;

    public Animator animator;
    public UserInterfaceOverworld userInterfaceOverworld;
    public DialogueTrigger dialogueTrigger;
    bool dialogueStarted = false;


    //made with Brackeys tutorial
    private Queue<string> sentences;
    // Start is called before the first frame update
    
    void Start()
    {
        sentences = new Queue<string>();

    }
    public void StartDialogue(Dialogue dialogue)
    {
        if (!dialogueStarted)
        {
            dialogueStarted = true;
            EventSystem.current.SetSelectedGameObject(firstSelectedButtonDialoge);
            Time.timeScale = 1;
            userInterfaceOverworld.canvasDialoge.SetActive(true);
            animator.SetBool("IsOpen", true);
            nameText.text = dialogue.name;
            sentences.Clear();

            foreach (string sentence in dialogue.sentences)
            {
                sentences.Enqueue(sentence);

            }
            DisplayNextSentence();

        }
        
    }
    public void DisplayNextSentence() 
    {
        if (sentences.Count ==0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }
    IEnumerator TypeSentence(string sentence) 
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;

        }
    }
    void EndDialogue() 
    {
        dialogueStarted = false;
        animator.SetBool("IsOpen", false);
        userInterfaceOverworld.Resume();
        //SceneManager.LoadScene(2);
    }

}
