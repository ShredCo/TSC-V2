using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UICanvasManager : MonoBehaviour
{
    // Singleton
    public static UICanvasManager Instance;

    [Header("UI Menus List")]
    public GameObject ingameUI;
    public GameObject pauseMenuUI;
    public GameObject controllsMenuUI;
    public GameObject settingsMenuUI;
    public GameObject finishMenuUI;
    

    [Header("Ingame UI")]
    public GameObject spawnBallInfo;

    [Header("PauseMenu Buttons")]
    public Button resumeButton;
    public Button menuButton;
    public Button quitButton;
    public Button controllsButton;
    public Button changeMusicButton;
    public Button settingsButton;

    [Header("SettingsMenu Buttons")]
    public GameObject goBackToMainMenu;

    public bool gameIsPaused = false;
    public bool controllMenuIsOpen = false;

    

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        // Places the spawn ball text
        if (SpawnBallManager.Instance.ballInGame == false)
        {
            spawnBallInfo.SetActive(true);
        }
        else
        {
            spawnBallInfo.SetActive(false);
        }

            // Pause the Game
            var gamepad = Gamepad.current;
            if (gamepad.startButton.wasPressedThisFrame)
            {
                if (gameIsPaused)
                {
                    ResumeGame();
                }
                else
                {
                    Pause();
                }
            }

            // go back to pauseMenu
            if (controllMenuIsOpen == true && gamepad.bButton.wasPressedThisFrame)
            {
                pauseMenuUI.SetActive(true);
                controllsMenuUI.SetActive(false);
                controllMenuIsOpen = false;
            }
    }


    // Button Methods
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        ingameUI.SetActive(false);
        gameIsPaused = true;
        // Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        ingameUI.SetActive(true);
        gameIsPaused = false;
        // Time.timeScale = 1f;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Debug.Log("runs Quit Game Method");
        Application.Quit();
    }

    public void ControllsMenu()
    {
        pauseMenuUI.SetActive(false);
        controllsMenuUI.SetActive(true);
        controllMenuIsOpen = true;
    }

    public void ChangeMusic()
    {
        AudioManager.Instance.nextTrack();
    }

    

    public void SettingsMenu()
    {
        pauseMenuUI.SetActive(false);
        settingsMenuUI.SetActive(true);

        // clear selected button
        EventSystem.current.SetSelectedGameObject(null);
        // set a new selected object
        EventSystem.current.SetSelectedGameObject(goBackToMainMenu);
    }
}

