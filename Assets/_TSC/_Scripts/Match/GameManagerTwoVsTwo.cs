using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManagerTwoVsTwo : MonoBehaviour
{
    // Singleton
    public static GameManagerTwoVsTwo Instance;

    // Poles Team 1
    [SerializeField] private PolesPlayer[] polesPlayerOne = new PolesPlayer[2];
    [SerializeField] private PolesPlayer[] polesPlayerTwo = new PolesPlayer[2];
    [SerializeField] private GameObject arrowOne;
    [SerializeField] private GameObject arrowTwo;

    // Poles Team 2
    [SerializeField] private PolesPlayer[] polesPlayerThree = new PolesPlayer[2];
    [SerializeField] private PolesPlayer[] polesPlayerFour = new PolesPlayer[2];
    [SerializeField] private GameObject arrowThree;
    [SerializeField] private GameObject arrowFour;


    // all players in a dictionary, player input as key, value is the id, can be simplified with only a list or array
    public Dictionary<PlayerInput, int> players = new Dictionary<PlayerInput, int>();

    public int ScoreTeam1;
    public int ScoreTeam2;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        Cursor.visible = false;
        ScoreTeam1 = 0;
        ScoreTeam2 = 0;
    }

    // Event for Player Input Manager 
    public void OnPlayerJoin(PlayerInput player)
    {
        if (!players.TryGetValue(player, out int value)) // if player doesn't exist
        {
            
            if (players.Count < 4) // if limit isnt reached
            {
                int id = players.Count + 1;
                players.Add(player, id);
                PlayerController playerController = player.GetComponent<PlayerController>();

                // TODO: if statement daraus machen
                // playerController.ReceivePoles(id == 1 ? polesPlayerOne : polesPlayerTwo);
                //playerController.ReceiveArrow(id == 1 ? arrowOne : arrowTwo);

                // Gives the players their poles and arrows
                switch(id)
                {
                    case 1:
                        playerController.ReceivePolesPlayer(polesPlayerOne);
                        playerController.ReceiveArrow(arrowOne);
                 
                        break;
                    case 2:
                        playerController.ReceivePolesPlayer(polesPlayerTwo);
                        playerController.ReceiveArrow(arrowTwo);
                        break;
                    case 3:
                        playerController.ReceivePolesPlayer(polesPlayerThree);
                        playerController.ReceiveArrow(arrowThree);
                        break;
                    case 4:
                        playerController.ReceivePolesPlayer(polesPlayerFour);
                        playerController.ReceiveArrow(arrowFour);
                        break;
                }

                player.gameObject.name = "Player_" + id;
                Debug.Log(player.name);
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
