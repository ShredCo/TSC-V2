using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManagerOneVsOne : MonoBehaviour
{
    // Singleton
    public static GameManagerOneVsOne Instance;

    // Poles per side
    [SerializeField] private Pole[] polesPlayerOne = new Pole[4];
    [SerializeField] private Pole[] polesPlayerTwo = new Pole[4];

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
                PlayerController playerController = player.GetComponent<PlayerController>();
                playerController.ReceivePoles(id == 1 ? polesPlayerOne : polesPlayerTwo);
                playerController.ReceiveArrow(id == 1 ? arrowOne : arrowTwo);

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
