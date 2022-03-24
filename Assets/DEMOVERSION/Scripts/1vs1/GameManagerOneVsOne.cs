using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManagerOneVsOne : MonoBehaviour
{
    // Singleton
    public static GameManagerOneVsOne Instance;

    // creates an array of poles for the players
    [SerializeField] private PolesPlayer[] polesPlayer = new PolesPlayer[4];
    [SerializeField] private PolesAI[] polesAI = new PolesAI[4];

    [Header("currentPoles")]
    [SerializeField] private GameObject arrowOne;
    [SerializeField] private GameObject arrowTwo;


    // all players in a dictionary, player input as key, value is the id, can be simplified with only a list or array
    public Dictionary<PlayerInput, int> players = new Dictionary<PlayerInput, int>();

    public int ScorePlayer1;
    public int ScorePlayer2;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        Cursor.visible = false;
        ScorePlayer1 = 0;
        ScorePlayer2 = 0;   
    }

    // Event for Player Input Manager 
    public void OnPlayerJoin(PlayerInput player)
    {
        if (!players.TryGetValue(player, out int value)) // if player doesn't exist
        {
            if (players.Count < 2) // if limit isnt reached
            {
                int id = players.Count + 1;
                players.Add(player, id);

                // Player receives his team
                PlayerController playerController = player.GetComponent<PlayerController>();
                playerController.ReceivePolesPlayer(polesPlayer);
                playerController.ReceiveArrow(arrowOne);

               
                // AI receives its team
                PlayerControllerAI playerControllerAI = player.GetComponent<PlayerControllerAI>();
                playerControllerAI.ReceivePolesAI(polesAI);
                playerControllerAI.ReceiveArrowAI(arrowOne);

                player.gameObject.name = "Player_" + id;
            }
        }
        else
            Debug.LogWarning("Player already joined");
    }
    public void OnPlayerLeave(PlayerInput player)
    {
        players.Remove(player);
    }

    
}
