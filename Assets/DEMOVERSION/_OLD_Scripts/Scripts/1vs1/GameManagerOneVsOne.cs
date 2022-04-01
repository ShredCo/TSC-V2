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
    [SerializeField] private SpecialCharacter[] specialCharacter = new SpecialCharacter[4];


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
    private void Update()
    {
        if (ScorePlayer1 == 10 || ScorePlayer2 == 10)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(1);
        }
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
                playerController.ReceiveAbility(specialCharacter);
  

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

    public void ScorePlayer()
    {
        if (ScorePlayer1 < 10)
        {
            ScorePlayer1 += 1;
            BallManager.Instance.ballInGame = false;
            print("ball in game:");
        }
    }
        public void ScoreEnemy()
    {
        if (ScorePlayer2 < 10)
        {
            ScorePlayer2 += 1;
            BallManager.Instance.ballInGame = false;
            print("ball in game:");
        }
    }
}
