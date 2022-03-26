using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class ControllerConnectingOneVsOneUI : MonoBehaviour
{
    public static ControllerConnectingOneVsOneUI Instance;

    [Header("UserInterfaces")]
    public GameObject canvasControllerConnecting;
    public GameObject canvasLineup;
    public GameObject canvasIngame;

    [Header("Images")]
    public GameObject controllerPlayer1;
    public GameObject controllerPlayer2;
    public GameObject pressOptionsText;

    [Header("Buttons")]
    public GameObject readyButton;
    public GameObject startGameButton;
    public GameObject resumeButton;

    public GameObject scriptholderPreGame;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManagerOneVsOne.Instance.players.Count < 1)
        {
            startGameButton.SetActive(false);
        }
        else
        {
            startGameButton.SetActive(true);
        }

        var gamepad = Gamepad.current;

        if (gamepad.buttonEast.wasPressedThisFrame)
        {
            SceneManager.LoadScene(0);
        }

        CheckConnectedControllers();
    }

    public void CheckConnectedControllers()
    {
        switch (GameManagerOneVsOne.Instance.players.Count)
        {
            case 1:
                controllerPlayer1.SetActive(true);
                break;
            case 2:
                controllerPlayer2.SetActive(true);
                pressOptionsText.SetActive(false);
                break;
        }
    }

    public void Ready()
    {
        if(GameManagerOneVsOne.Instance.players.Count > 1)
        {
            canvasControllerConnecting.SetActive(false);
            canvasLineup.SetActive(true);

            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(startGameButton);
        }
        
    }

    public void StartGame()
    {
        
        canvasLineup.SetActive(false);
        canvasIngame.SetActive(true);

        Time.timeScale = 1f;

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(resumeButton);
        scriptholderPreGame.SetActive(false);
    }
}
