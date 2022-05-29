using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using TMPro;

public class GameManagerClashLokalMultiplayer : MonoBehaviour
{
    
    #region Singleton
    public static GameManagerClashLokalMultiplayer Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    #endregion

    #region References
    [Header("Players/Poles")]
    //// Player 1
    //[SerializeField] private PolesPlayer[] polesPlayer1 = new PolesPlayer[4];
    //[SerializeField] private SpecialCharacter[] specialCharacterPlayer1 = new SpecialCharacter[4];
    //[SerializeField] private GameObject arrowPlayer1;
    //
    //// Player 2
    //[SerializeField] private PolesPlayer[] polesPlayer2 = new PolesPlayer[4];
    //[SerializeField] private SpecialCharacter[] specialCharacterPlayer2 = new SpecialCharacter[4];
    //[SerializeField] private GameObject arrowPlayer2;
    //
    //// Player 3
    //[SerializeField] private PolesPlayer[] polesPlayer3 = new PolesPlayer[4];
    //[SerializeField] private SpecialCharacter[] specialCharacterPlayer3 = new SpecialCharacter[4];
    //[SerializeField] private GameObject arrowPlayer3;
    //
    //// Player 4
    //[SerializeField] private PolesPlayer[] polesPlayer4 = new PolesPlayer[4];
    //[SerializeField] private SpecialCharacter[] specialCharacterPlayer4 = new SpecialCharacter[4];
    //[SerializeField] private GameObject arrowPlayer4;
    
    // Player 1
    [SerializeField] private List<PolesPlayer> polesPlayer1 = new List<PolesPlayer>();
    [SerializeField] private List<SpecialCharacter> specialCharacterPlayer1 = new List<SpecialCharacter>();
    
    // Player 2
    [SerializeField] private List<PolesPlayer> polesPlayer2 = new List<PolesPlayer>();
    [SerializeField] private List<SpecialCharacter> specialCharacterPlayer2 = new List<SpecialCharacter>();
    
    // Player 3
    [SerializeField] private List<PolesPlayer> polesPlayer3 = new List<PolesPlayer>();
    [SerializeField] private List<SpecialCharacter> specialCharacterPlayer3 = new List<SpecialCharacter>();
    
    // Player 4
    [SerializeField] private List<PolesPlayer> polesPlayer4 = new List<PolesPlayer>();
    [SerializeField] private List<SpecialCharacter> specialCharacterPlayer4 = new List<SpecialCharacter>();

    // Steering Wheels
    // Steering Wheels
    [SerializeField] private GameObject player1_SteeringWheelLeftHand;
    [SerializeField] private GameObject player1_SteeringWheelRightHand;
    [SerializeField] private GameObject player2_SteeringWheelLeftHand;
    [SerializeField] private GameObject player2_SteeringWheelRightHand;
    [SerializeField] private GameObject player3_SteeringWheelLeftHand;
    [SerializeField] private GameObject player3_SteeringWheelRightHand;
    [SerializeField] private GameObject player4_SteeringWheelLeftHand;
    [SerializeField] private GameObject player4_SteeringWheelRightHand;
    
    // all players in a dictionary, player input as key, value is the id, can be simplified with only a list or array
    public Dictionary<PlayerInput, int> players = new Dictionary<PlayerInput, int>();

    [Header("Counts/Scores")]
    public int ScorePlayer1;
    public int ScorePlayer2;
    private int ScoreToWin = 5;
    public int powerpointsCountRed = 0;
    public int powerpointsCountBlue = 0;
    
    // Win / Lose Display
    public TextMeshProUGUI WinLoseText;
    public GameObject WinLosePanel;
    #endregion

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        LevelTransitionManager.Instance.EndTransition();

        //TODO: Load Map depending on choosed Map
        switch (LineUpController.MapType)
        {
            case MapType.Route1_1:
                SceneManager.LoadScene("Route1_1", LoadSceneMode.Additive);
                break;
            case MapType.Route1_2:
                SceneManager.LoadScene("Route1_2", LoadSceneMode.Additive);
                break;
            case MapType.OkinaShores_Default:
                SceneManager.LoadScene("OkinaShores_DefaultMap", LoadSceneMode.Additive);
                break;
            case MapType.OkinaShores_Arena:
                SceneManager.LoadScene("OkinaShores_Arena", LoadSceneMode.Additive);
                break;
        }
        
        Cursor.visible = false;
        ScorePlayer1 = 0;
        ScorePlayer2 = 0;

        // Get and spawn Line Ups
        GetLineUps();
        SpawnPlayerLineUp();
        SpawnAILineUp();
    }
    private void Update()
    {
        if (ScorePlayer1 >= ScoreToWin)
        {
            WinLoseText.text = "YOU WIN";
            LineUpController.DidWin = true;
            Time.timeScale = 1f;
            FindObjectOfType<ClashHUD>().SavePoleHealth();
            StartCoroutine(EndGame());
        }
        else if (ScorePlayer2 >= ScoreToWin)
        {
            WinLoseText.text = "YOU LOSE";
            LineUpController.DidWin = false;
            Time.timeScale = 1f;
            FindObjectOfType<ClashHUD>().SavePoleHealth();
            StartCoroutine(EndGame());
        }
        
        
    }

    public IEnumerator EndGame()
    {
        WinLosePanel.SetActive(true);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(1);
    }

    #region Event for Player Input Manager
    public void OnPlayerJoin(PlayerInput player)
    {
        if (!players.TryGetValue(player, out int value)) // if player doesn't exist
        {
            if (players.Count < 1) // first player -> Team Red
            {
                int id = players.Count + 1;
                players.Add(player, id);
                
                // Player receives his team
                PlayerController playerController = player.GetComponent<PlayerController>();
                playerController.ReceivePolesPlayer(polesPlayer1);
                playerController.ReceiveAbility(specialCharacterPlayer1);
                playerController.ReceiveArrow(player1_SteeringWheelLeftHand, player1_SteeringWheelRightHand);

                player.gameObject.name = "Player_" + id;
            }
            else if (players.Count == 1) // first player -> Team Blue
            {
                int id = players.Count + 1;
                players.Add(player, id);
                PlayerController playerController = player.GetComponent<PlayerController>();

                playerController.ReceivePolesPlayer(polesPlayer2);
                playerController.ReceiveAbility(specialCharacterPlayer2);
                playerController.ReceiveArrow(player2_SteeringWheelLeftHand, player2_SteeringWheelRightHand);
                
                player.gameObject.name = "Player_" + id;
            }
            else if (players.Count == 2) // second Player -> Team Red
            {
                int id = players.Count + 1;
                players.Add(player, id);
                PlayerController playerController = player.GetComponent<PlayerController>();
                
                polesPlayer1.RemoveAt(3);
                polesPlayer1.RemoveAt(2);
                playerController.ReceivePolesPlayer(polesPlayer3);
                playerController.ReceiveAbility(specialCharacterPlayer3);
                playerController.ReceiveArrow(player3_SteeringWheelLeftHand, player3_SteeringWheelRightHand);
                player3_SteeringWheelLeftHand.SetActive(true);
                player3_SteeringWheelRightHand.SetActive(true);
                
                player.gameObject.name = "Player_" + id;
            }
            else if (players.Count == 3) // second Player -> Team Blue
            {
                int id = players.Count + 1;
                players.Add(player, id);
                PlayerController playerController = player.GetComponent<PlayerController>();

                polesPlayer2.RemoveAt(3);
                polesPlayer2.RemoveAt(2);
                playerController.ReceivePolesPlayer(polesPlayer4);
                playerController.ReceiveAbility(specialCharacterPlayer4);
                playerController.ReceiveArrow(player3_SteeringWheelLeftHand, player3_SteeringWheelRightHand);
                player3_SteeringWheelLeftHand.SetActive(true);
                player3_SteeringWheelRightHand.SetActive(true);
                
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
    #endregion

    #region Scores
    public void ScorePlayer()
    {
        if (ScorePlayer1 < 10)
        {
            ScorePlayer1 += 1;
            BallManager.Instance.BallInGame = false;
            print("ball in game:");
        }
    }
    public void ScoreEnemy()
    {
        if (ScorePlayer2 < 10)
        {
            ScorePlayer2 += 1;
            BallManager.Instance.BallInGame = false;
            print("ball in game:");
        }
    }
    #endregion

    #region Line Up
    
    [Header("Line Up Arrays")]
    // Player 1
    [SerializeField] CardObject[] player1_defaultCardLineUP = new CardObject[4];
    [SerializeField] CardObject[] player1_specialCardLineUP = new CardObject[4];
    // Player 2
    [SerializeField] CardObject[] player2_defaultCardLineUp = new CardObject[4];
    [SerializeField] CardObject[] player2_specialCardLineUp = new CardObject[4];
    
    [Header("Player 1 Spawn Points")]
    [SerializeField] GameObject player1_spawnPoint1;
    [SerializeField] GameObject player1_spawnPoint2;
    [SerializeField] GameObject player1_spawnPoint3;
    [SerializeField] GameObject player1_spawnPoint4;
    [SerializeField] GameObject player1_spawnPoint5;
    [SerializeField] GameObject player1_spawnPoint6;
    [SerializeField] GameObject player1_spawnPoint7;
    [SerializeField] GameObject player1_spawnPoint8;
    [SerializeField] GameObject player1_spawnPoint9;
    [SerializeField] GameObject player1_spawnPoint10;
    [SerializeField] GameObject player1_spawnPoint11;
    
    [Header("Player 2 Spawn Points")]
    [SerializeField] GameObject player2_spawnPoint1;
    [SerializeField] GameObject player2_spawnPoint2;
    [SerializeField] GameObject player2_spawnPoint3;
    [SerializeField] GameObject player2_spawnPoint4;
    [SerializeField] GameObject player2_spawnPoint5;
    [SerializeField] GameObject player2_spawnPoint6;
    [SerializeField] GameObject player2_spawnPoint7;
    [SerializeField] GameObject player2_spawnPoint8;
    [SerializeField] GameObject player2_spawnPoint9;
    [SerializeField] GameObject player2_spawnPoint10;
    [SerializeField] GameObject player2_spawnPoint11;

    public void SpawnPlayerLineUp()
    {
        GameObject spawnedPlayer;

        // Spawn Pole 1
        if (player1_defaultCardLineUP[0] != null)
        {
            spawnedPlayer = Instantiate(player1_defaultCardLineUP[0].PlayerPrefab);
            spawnedPlayer.transform.SetParent(player1_spawnPoint1.transform);
            spawnedPlayer.transform.position = player1_spawnPoint1.transform.position;
            spawnedPlayer.transform.rotation = Quaternion.Euler(0, -90, 0);
        }

        // Spawn Pole 2
        if (player1_defaultCardLineUP[1] != null)
        {
            spawnedPlayer = Instantiate(player1_defaultCardLineUP[1].PlayerPrefab);
            spawnedPlayer.transform.SetParent(player1_spawnPoint2.transform);
            spawnedPlayer.transform.position = player1_spawnPoint2.transform.position;
            spawnedPlayer.transform.rotation = Quaternion.Euler(0, -90, 0);

            spawnedPlayer = Instantiate(player1_defaultCardLineUP[1].PlayerPrefab);
            spawnedPlayer.transform.SetParent(player1_spawnPoint3.transform);
            spawnedPlayer.transform.position = player1_spawnPoint3.transform.position;
            spawnedPlayer.transform.rotation = Quaternion.Euler(0, -90, 0);
        }


        // Spawn Pole 3
        if (player1_defaultCardLineUP[2] != null)
        {
            spawnedPlayer = Instantiate(player1_defaultCardLineUP[2].PlayerPrefab);
            spawnedPlayer.transform.SetParent(player1_spawnPoint4.transform);
            spawnedPlayer.transform.position = player1_spawnPoint4.transform.position;
            spawnedPlayer.transform.rotation = Quaternion.Euler(0, -90, 0);

            spawnedPlayer = Instantiate(player1_defaultCardLineUP[2].PlayerPrefab);
            spawnedPlayer.transform.SetParent(player1_spawnPoint5.transform);
            spawnedPlayer.transform.position = player1_spawnPoint5.transform.position;
            spawnedPlayer.transform.rotation = Quaternion.Euler(0, -90, 0);

            spawnedPlayer = Instantiate(player1_defaultCardLineUP[2].PlayerPrefab);
            spawnedPlayer.transform.SetParent(player1_spawnPoint6.transform);
            spawnedPlayer.transform.position = player1_spawnPoint6.transform.position;
            spawnedPlayer.transform.rotation = Quaternion.Euler(0, -90, 0);

            spawnedPlayer = Instantiate(player1_defaultCardLineUP[2].PlayerPrefab);
            spawnedPlayer.transform.SetParent(player1_spawnPoint7.transform);
            spawnedPlayer.transform.position = player1_spawnPoint7.transform.position;
            spawnedPlayer.transform.rotation = Quaternion.Euler(0, -90, 0);

            spawnedPlayer = Instantiate(player1_defaultCardLineUP[2].PlayerPrefab);
            spawnedPlayer.transform.SetParent(player1_spawnPoint8.transform);
            spawnedPlayer.transform.position = player1_spawnPoint8.transform.position;
            spawnedPlayer.transform.rotation = Quaternion.Euler(0, -90, 0);
        }

        // Spawn Pole 4
        if (player1_defaultCardLineUP[3] != null)
        {
            spawnedPlayer = Instantiate(player1_defaultCardLineUP[3].PlayerPrefab);
            spawnedPlayer.transform.SetParent(player1_spawnPoint9.transform);
            spawnedPlayer.transform.position = player1_spawnPoint9.transform.position;
            spawnedPlayer.transform.rotation = Quaternion.Euler(0, -90, 0);

            spawnedPlayer = Instantiate(player1_defaultCardLineUP[3].PlayerPrefab);
            spawnedPlayer.transform.SetParent(player1_spawnPoint10.transform);
            spawnedPlayer.transform.position = player1_spawnPoint10.transform.position;
            spawnedPlayer.transform.rotation = Quaternion.Euler(0, -90, 0);

            spawnedPlayer = Instantiate(player1_defaultCardLineUP[3].PlayerPrefab);
            spawnedPlayer.transform.SetParent(player1_spawnPoint11.transform);
            spawnedPlayer.transform.position = player1_spawnPoint11.transform.position;
            spawnedPlayer.transform.rotation = Quaternion.Euler(0, -90, 0);
        }
    }

    public void SpawnAILineUp()
    {
        GameObject spawnedPlayer;

        // Spawn Pole 1
        if (player2_defaultCardLineUp[0] != null)
        {
            spawnedPlayer = Instantiate(player2_defaultCardLineUp[0].PlayerPrefab);
            spawnedPlayer.transform.SetParent(player2_spawnPoint1.transform);
            spawnedPlayer.transform.position = player2_spawnPoint1.transform.position;
            spawnedPlayer.transform.rotation = Quaternion.Euler(0, 90, 0);
        }

        // Spawn Pole 2
        if (player2_defaultCardLineUp[1] != null)
        {
            spawnedPlayer = Instantiate(player2_defaultCardLineUp[1].PlayerPrefab);
            spawnedPlayer.transform.SetParent(player2_spawnPoint2.transform);
            spawnedPlayer.transform.position = player2_spawnPoint2.transform.position;
            spawnedPlayer.transform.rotation = Quaternion.Euler(0, 90, 0);

            spawnedPlayer = Instantiate(player2_defaultCardLineUp[1].PlayerPrefab);
            spawnedPlayer.transform.SetParent(player2_spawnPoint3.transform);
            spawnedPlayer.transform.position = player2_spawnPoint3.transform.position;
            spawnedPlayer.transform.rotation = Quaternion.Euler(0, 90, 0);
        }


        // Spawn Pole 3
        if (player2_defaultCardLineUp[2] != null)
        {
            spawnedPlayer = Instantiate(player2_defaultCardLineUp[2].PlayerPrefab);
            spawnedPlayer.transform.SetParent(player2_spawnPoint4.transform);
            spawnedPlayer.transform.position = player2_spawnPoint4.transform.position;
            spawnedPlayer.transform.rotation = Quaternion.Euler(0, 90, 0);

            spawnedPlayer = Instantiate(player2_defaultCardLineUp[2].PlayerPrefab);
            spawnedPlayer.transform.SetParent(player2_spawnPoint5.transform);
            spawnedPlayer.transform.position = player2_spawnPoint5.transform.position;
            spawnedPlayer.transform.rotation = Quaternion.Euler(0, 90, 0);

            spawnedPlayer = Instantiate(player2_defaultCardLineUp[2].PlayerPrefab);
            spawnedPlayer.transform.SetParent(player2_spawnPoint6.transform);
            spawnedPlayer.transform.position = player2_spawnPoint6.transform.position;
            spawnedPlayer.transform.rotation = Quaternion.Euler(0, 90, 0);

            spawnedPlayer = Instantiate(player2_defaultCardLineUp[2].PlayerPrefab);
            spawnedPlayer.transform.SetParent(player2_spawnPoint7.transform);
            spawnedPlayer.transform.position = player2_spawnPoint7.transform.position;
            spawnedPlayer.transform.rotation = Quaternion.Euler(0, 90, 0);

            spawnedPlayer = Instantiate(player2_defaultCardLineUp[2].PlayerPrefab);
            spawnedPlayer.transform.SetParent(player2_spawnPoint8.transform);
            spawnedPlayer.transform.position = player2_spawnPoint8.transform.position;
            spawnedPlayer.transform.rotation = Quaternion.Euler(0, 90, 0);
        }

        // Spawn Pole 4
        if (player2_defaultCardLineUp[3] != null)
        {
            spawnedPlayer = Instantiate(player2_defaultCardLineUp[3].PlayerPrefab);
            spawnedPlayer.transform.SetParent(player2_spawnPoint9.transform);
            spawnedPlayer.transform.position = player2_spawnPoint9.transform.position;
            spawnedPlayer.transform.rotation = Quaternion.Euler(0, 90, 0);

            spawnedPlayer = Instantiate(player2_defaultCardLineUp[3].PlayerPrefab);
            spawnedPlayer.transform.SetParent(player2_spawnPoint10.transform);
            spawnedPlayer.transform.position = player2_spawnPoint10.transform.position;
            spawnedPlayer.transform.rotation = Quaternion.Euler(0, 90, 0);

            spawnedPlayer = Instantiate(player2_defaultCardLineUp[3].PlayerPrefab);
            spawnedPlayer.transform.SetParent(player2_spawnPoint11.transform);
            spawnedPlayer.transform.position = player2_spawnPoint11.transform.position;
            spawnedPlayer.transform.rotation = Quaternion.Euler(0, 90, 0);
        }
    }

    // Get static Line Up Arrays from the LineUpController script
    public void GetLineUps()
    {
        //player1_defaultCardLineUP = LineUpControllerLokalOneVsOne.Player1_DefaultCardLineUP;
        //player1_specialCardLineUP = LineUpControllerLokalOneVsOne.Player1_AbilityCardLineUP;
        //player2_defaultCardLineUp = LineUpControllerLokalOneVsOne.Player2_DefaultCardLineUP;
        //player2_specialCardLineUp = LineUpControllerLokalOneVsOne.Player2_AbilityCardLineUP;
    }
    #endregion
}
