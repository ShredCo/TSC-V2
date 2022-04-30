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

public enum TalkState
{
    TalkWithX,
    SelfTrigger
}

public class DialogueTrigger : MonoBehaviour
{
    public static DialogueTrigger Instance;
    
    public NPCInventorySO NPCInventory;
    public InventoryObject PlayerInventory;

    public WaypointNavigator WaypointNavigator;
    GameObject player;

    Rigidbody rigidbody;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        rigidbody = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    [SerializeField] public GameObject x_Text;
    
    public Dialogue dialogue;
    public Dialogue AfterMatchDialogue;
    public Dialogue LostDialogue;

    public TalkState TalkState;
    public NpcType NpcType;
    public MapType MapType;

    public int MoneyReward;
    public DefaultCardObject DefaultCardReward;

    public DialogueState dialogueState;
    public bool IsTalking = false;
    public bool IsWalking = false;
    public bool DidLoose = false;

    private float distanceToPlayer;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switch (TalkState)
            {
                case TalkState.TalkWithX:
                    x_Text.SetActive(true);
                    // Interact with a NPC
                    var gamepad = Gamepad.current;
                    if (gamepad.buttonSouth.wasPressedThisFrame && IsTalking == false)
                    {
                        GetComponent<Animator>().SetBool("IsWalking", false);
                        RotatePlayerTowardsNPC();
                        RotateNPCTowardsPlayer(other.transform.position);
                        TriggerDialogue();
                        x_Text.SetActive(false);
                    
                        // pause the game
                        GameState currentGameState = GameStateManager.Instance.CurrentGameState;
                        GameState newGameState = currentGameState == GameState.Gameplay
                            ? GameState.Paused
                            : GameState.Gameplay;
                    
                        GameStateManager.Instance.SetState(newGameState);
                    }
                    break;
                case TalkState.SelfTrigger:
                    if (NpcType == NpcType.Agressive && IsTalking == false && IsWalking == true)
                    {
                        if (distanceToPlayer > 1f)
                        {
                            WalkTowardsPlayer(other.transform.position);
                            RotatePlayerTowardsNPC();
                        }
                        else
                        {
                            GetComponent<Animator>().SetBool("IsWalking", false);
                            TriggerDialogue();
                            //x_Text.SetActive(false);
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }
    public void WalkTowardsPlayer(Vector3 playerPosition)
    {
        Vector3 direction = playerPosition - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;
        transform.position = Vector3.Lerp(transform.position, playerPosition, 0.01f);
    }

    public void RotateNPCTowardsPlayer(Vector3 playerPosition)
    {
        Vector3 direction = playerPosition - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;
    }

    void RotatePlayerTowardsNPC()
    {
        Vector3 direction =  transform.position - player.transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        player.transform.rotation = Quaternion.Lerp(player.transform.rotation, rotation, 0.1f);
    }

    private void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && NpcType == NpcType.Agressive && TalkState == TalkState.SelfTrigger)
        {
            // pause game
            GameState currentGameState = GameStateManager.Instance.CurrentGameState;
            GameState newGameState = currentGameState == GameState.Gameplay
                ? GameState.Paused
                : GameState.Gameplay;
            GameStateManager.Instance.SetState(newGameState);

            IsWalking = true;
            //x_Text.SetActive(true);
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
        IsTalking = true;
        LineUpController.NPCPosition = transform.position;
        LineUpController.NPCName = name;
        if (NPCInventory != null)
        {
            NPCInventory.SetNPCLineUp();
            PlayerInventory.SavePlayerLineUp();
        }
        if (DidLoose == true)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(LostDialogue);
            FindObjectOfType<DialogueManager>().npcType = NpcType;
        }
        else
        {
            LineUpController.MapType = MapType;
            LineUpController.AfterMatchDialogue = AfterMatchDialogue;
            LineUpController.MoneyReward = MoneyReward;
            LineUpController.DefaultCardReward = DefaultCardReward;
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            FindObjectOfType<DialogueManager>().npcType = NpcType;
        }
    }
}
