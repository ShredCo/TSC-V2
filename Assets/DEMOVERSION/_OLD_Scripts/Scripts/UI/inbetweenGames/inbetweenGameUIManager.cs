using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Audio;

public class inbetweenGameUIManager : MonoBehaviour
{
    [Header("UI Menus List")]
    public GameObject ingameUI;
    public GameObject pauseMenuUI;
    public GameObject controllsMenuUI;
    public GameObject settingsMenuUI;

    [Header("PauseMenu Buttons")]
    public GameObject resumeButton;
    public Button menuButton;
    public Button quitButton;
    public Button controllsButton;
    public Button changeMusicButton;
    public Button settingsButton;
    public GameObject goBackToPauseMenuButton;

    public static bool gameIsPaused = false;
    public static bool controllMenuIsOpen = false;

    // Audio
    public AudioMixer mixer;

    // Update is called once per frame
    void Update()
    {
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


    // Button methods
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        ingameUI.SetActive(false);
        gameIsPaused = true;
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        ingameUI.SetActive(true);
        gameIsPaused = false;
        Time.timeScale = 1f;
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
        EventSystem.current.SetSelectedGameObject(goBackToPauseMenuButton);
    }
    public void goBackToPauseMenu()
    {
        pauseMenuUI.SetActive(true);
        settingsMenuUI.SetActive(false);

        // clear selected button
        EventSystem.current.SetSelectedGameObject(null);
        // set a new selected object
        EventSystem.current.SetSelectedGameObject(resumeButton);
    }

    // changes the volume of the music
    public void SetLevel(float sliderValue)
    {
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
    }
}
