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

        // Line Up
        // Get static Line Up Arrays from the LineUpController script

        playerDefaultCardLineUP = LineUpController.PlayerDefaultCardLineUP;
        playerSpecialCardLineUP = LineUpController.PlayerSpecialCardLineUP;
        AIDefaultCardLineUP = LineUpController.AIDefaultCardLineUP;
        AISpecialCardLineUP = LineUpController.AISpecialCardLineUP;

        SpawnPlayerLineUp();
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

    #region Line Up
    // Arrays to store the Line Ups
    [SerializeField] CardObject[] playerDefaultCardLineUP = new CardObject[4];
    [SerializeField] CardObject[] playerSpecialCardLineUP = new CardObject[4];
    [SerializeField] CardObject[] AIDefaultCardLineUP = new CardObject[4];
    [SerializeField] CardObject[] AISpecialCardLineUP = new CardObject[4];

    [SerializeField] GameObject spawnPointMainPole;
    [SerializeField] GameObject spawnPointCrewPole1_1;
    [SerializeField] GameObject spawnPointCrewPole1_2;
    [SerializeField] GameObject spawnPointCrewPole2_1;
    [SerializeField] GameObject spawnPointCrewPole2_2;
    [SerializeField] GameObject spawnPointCrewPole2_3;
    [SerializeField] GameObject spawnPointCrewPole2_4;
    [SerializeField] GameObject spawnPointCrewPole2_5;
    [SerializeField] GameObject spawnPointCrewPole3_1;
    [SerializeField] GameObject spawnPointCrewPole3_2;
    [SerializeField] GameObject spawnPointCrewPole3_3;

    public void SpawnPlayerLineUp()
    {
        GameObject spawnedPlayer;

        // SpawnMainPole
        spawnedPlayer = Instantiate(playerDefaultCardLineUP[0].PlayerPrefab);
        spawnedPlayer.transform.SetParent(spawnPointMainPole.transform);
        spawnedPlayer.transform.position = spawnPointMainPole.transform.position;
        spawnedPlayer.transform.rotation = Quaternion.Euler(0, -90, 0);

        // SpawnCrewPole1
        spawnedPlayer = Instantiate(playerDefaultCardLineUP[1].PlayerPrefab);
        spawnedPlayer.transform.SetParent(spawnPointCrewPole1_1.transform);
        spawnedPlayer.transform.position = spawnPointCrewPole1_1.transform.position;
        spawnedPlayer.transform.rotation = Quaternion.Euler(0, -90, 0);

        spawnedPlayer = Instantiate(playerDefaultCardLineUP[1].PlayerPrefab);
        spawnedPlayer.transform.SetParent(spawnPointCrewPole1_2.transform);
        spawnedPlayer.transform.position = spawnPointCrewPole1_2.transform.position;
        spawnedPlayer.transform.rotation = Quaternion.Euler(0, -90, 0);

        // SpawnCrewPole2
        spawnedPlayer = Instantiate(playerDefaultCardLineUP[2].PlayerPrefab);
        spawnedPlayer.transform.SetParent(spawnPointCrewPole2_1.transform);
        spawnedPlayer.transform.position = spawnPointCrewPole2_1.transform.position;
        spawnedPlayer.transform.rotation = Quaternion.Euler(0, -90, 0);

        spawnedPlayer = Instantiate(playerDefaultCardLineUP[2].PlayerPrefab);
        spawnedPlayer.transform.SetParent(spawnPointCrewPole2_2.transform);
        spawnedPlayer.transform.position = spawnPointCrewPole2_2.transform.position;
        spawnedPlayer.transform.rotation = Quaternion.Euler(0, -90, 0);

        spawnedPlayer = Instantiate(playerDefaultCardLineUP[2].PlayerPrefab);
        spawnedPlayer.transform.SetParent(spawnPointCrewPole2_3.transform);
        spawnedPlayer.transform.position = spawnPointCrewPole2_3.transform.position;
        spawnedPlayer.transform.rotation = Quaternion.Euler(0, -90, 0);

        spawnedPlayer = Instantiate(playerDefaultCardLineUP[2].PlayerPrefab);
        spawnedPlayer.transform.SetParent(spawnPointCrewPole2_4.transform);
        spawnedPlayer.transform.position = spawnPointCrewPole2_4.transform.position;
        spawnedPlayer.transform.rotation = Quaternion.Euler(0, -90, 0);

        spawnedPlayer = Instantiate(playerDefaultCardLineUP[2].PlayerPrefab);
        spawnedPlayer.transform.SetParent(spawnPointCrewPole2_5.transform);
        spawnedPlayer.transform.position = spawnPointCrewPole2_5.transform.position;
        spawnedPlayer.transform.rotation = Quaternion.Euler(0, -90, 0);

        // SpawnCrewPole3
        spawnedPlayer = Instantiate(playerDefaultCardLineUP[3].PlayerPrefab);
        spawnedPlayer.transform.SetParent(spawnPointCrewPole3_1.transform);
        spawnedPlayer.transform.position = spawnPointCrewPole3_1.transform.position;
        spawnedPlayer.transform.rotation = Quaternion.Euler(0, -90, 0);

        spawnedPlayer = Instantiate(playerDefaultCardLineUP[3].PlayerPrefab);
        spawnedPlayer.transform.SetParent(spawnPointCrewPole3_2.transform);
        spawnedPlayer.transform.position = spawnPointCrewPole3_2.transform.position;
        spawnedPlayer.transform.rotation = Quaternion.Euler(0, -90, 0);

        spawnedPlayer = Instantiate(playerDefaultCardLineUP[3].PlayerPrefab);
        spawnedPlayer.transform.SetParent(spawnPointCrewPole3_3.transform);
        spawnedPlayer.transform.position = spawnPointCrewPole3_3.transform.position;
        spawnedPlayer.transform.rotation = Quaternion.Euler(0, -90, 0);
    }
    #endregion
}
