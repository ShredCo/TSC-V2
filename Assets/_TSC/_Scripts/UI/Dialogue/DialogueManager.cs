using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class DialogueManager : MonoBehaviour
{
    public InventoryObject PlayerInventory;
    public GameObject PlayerGameObject;

    public Text nameText;
    public Text dialogueText;
    public GameObject firstSelectedButtonDialoge;

    public Animator animator;
    public UserInterfaceOverworld userInterfaceOverworld;
    public DialogueTrigger dialogueTrigger;
    public bool dialogueStarted = false;
    
    public NpcType npcType;
    public WorkshopUI workshopUI;
    
    private DialogueState dialogueState;
    //made with Brackeys tutorial
    private Queue<string> sentences;
    // Start is called before the first frame update
    
    void Start()
    {
        PlayerGameObject = GameObject.FindGameObjectWithTag("Player");
        sentences = new Queue<string>();
        //PlayerInventory = FindObjectOfType<InventoryObject>();
    }
    public void StartDialogue(Dialogue dialogue)
    {
        if (!dialogueStarted)
        {
            Player.Instance.DialogueState = DialogueState.Talking;
            dialogueStarted = true;
            EventSystem.current.SetSelectedGameObject(firstSelectedButtonDialoge);
            Time.timeScale = 1;
            userInterfaceOverworld.CanvasDialoge.SetActive(true);
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
        Player.Instance.DialogueState = DialogueState.Avaiable;
        animator.SetBool("IsOpen", false);
        userInterfaceOverworld.Resume();
        if (LineUpController.DidWin == false)
        {
            if (npcType == NpcType.Agressive)
            {
                LineUpController.PlayerPosition = PlayerGameObject.transform.position;
                StartCoroutine(LevelTransitionManager.Instance.StartTransition());
            }
            if (npcType == NpcType.Neutral)
            {
                StartCoroutine(CooldownDialogue());
            }
            if (npcType == NpcType.Workshop)
            {
                workshopUI.OpenWorkshopUI();
                InventoryUI.Instance.UpdatePoleCardList();
                InventoryUI.Instance.UpdateAbilityCardList();
                InventoryUI.Instance.UpdateLineUpCards();
            }
        }
        else
        {
            LineUpController.DidWin = false;
            PlayerInventory.AddMoney(LineUpController.MoneyReward);
            //PlayerInventory.AddDefaultCard(LineUpController.DefaultCardReward, 1);
        }
        dialogueStarted = false;
    }

    public IEnumerator CooldownDialogue()
    {
        yield return new WaitForSeconds(1f);
        dialogueStarted = false;
        DialogueTrigger.Instance.IsTalking = false;
    }
}
