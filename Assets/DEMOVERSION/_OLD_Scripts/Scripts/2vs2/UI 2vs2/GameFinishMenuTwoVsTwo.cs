using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameFinishMenuTwoVsTwo : MonoBehaviour
{
    // Singleton
    public static GameFinishMenuTwoVsTwo Instance;

    // GameObjects
    public GameObject finishMenuUI;
    public GameObject pauseMenuUI;
    public GameObject ingameUI;
    public GameObject Team1Winner;
    public GameObject Team2Winner;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Update()
    {
        CheckWinner();
    }

    public void CheckWinner()
    {
        // check for winner
        if (GameManagerTwoVsTwo.Instance.ScoreTeam1 == 10 || GameManagerTwoVsTwo.Instance.ScoreTeam2 == 10)
        {
            finishMenuUI.SetActive(true);
            pauseMenuUI.SetActive(false);
            ingameUI.SetActive(false);

            // case red wins
            if (GameManagerTwoVsTwo.Instance.ScoreTeam1 == 10)
            {
                Team1Winner.SetActive(true);
                print("Player1 is the winner of this game");
                var gamepad = Gamepad.current;
                if (gamepad.startButton.wasPressedThisFrame)
                {
                    SceneManager.LoadScene(0);
                }
            }

            // case blue wins
            if (GameManagerOneVsOne.Instance.ScorePlayer2 == 10)
            {
                Team2Winner.SetActive(true);
                print("Player2 is the winner of this game");
                var gamepad = Gamepad.current;
                if (gamepad.startButton.wasPressedThisFrame)
                {
                    SceneManager.LoadScene(0);
                }
            }
        }

    }
}
