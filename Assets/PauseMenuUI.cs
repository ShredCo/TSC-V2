using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PauseMenuUI : MonoBehaviour
{
    [Header("Canvas")]
    public GameObject Canvas_PauseMenu;

    [Header("Panels")]
    public GameObject Panel_PauseMenu;
    public GameObject Panel_HelpMenu;
    public GameObject Panel_SettingsMenu;
    // Confirm Images
    public GameObject Image_ConfirmMenu;
    public GameObject Image_ConfirmQuit;
    
    [Header("Buttons/Panel Pause")]
    public GameObject ButtonResume;
    // Confirm Images button
    public GameObject Button_Menu_No;
    public GameObject Button_Quit_No;
    
    [Header("Buttons/Panel Help")]
    public GameObject ButtonCloseHelp;

    [Header("Buttons/Panel Settings")]
    public GameObject ButtonCloseSettings;
    
    #region Input System -> Pause Game
    public void Pause(InputAction.CallbackContext context)
    {
        //Time.timeScale = 0;
        Canvas_PauseMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(ButtonResume);
    }
    #endregion
    
    #region PauseMenu -> Button Methods
    public void Resume()
    {
        Time.timeScale = 1;
        Canvas_PauseMenu.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void Help()
    {
        Panel_HelpMenu.SetActive(true);
        Panel_PauseMenu.SetActive(false);
        EventSystem.current.SetSelectedGameObject(ButtonCloseHelp);
    }

    public void Settings()
    {
        Panel_SettingsMenu.SetActive(true);
        Panel_PauseMenu.SetActive(false);
        EventSystem.current.SetSelectedGameObject(ButtonCloseSettings);
    }

    public void Menu()
    {
        Image_ConfirmMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(Button_Menu_No);
    }

    public void Quit()
    {
        Image_ConfirmQuit.SetActive(true);
        EventSystem.current.SetSelectedGameObject(Button_Quit_No);
    }
    
    // Confirm Menu/Quit Methods
    public void ConfirmMenuNo()
    {
        Image_ConfirmMenu.SetActive(false);
        EventSystem.current.SetSelectedGameObject(ButtonResume);
    }
    public void ConfirmMenuYes()
    {
        SceneManager.LoadScene(0);
    }
    
    public void ConfirmQuitNo()
    {
        Image_ConfirmQuit.SetActive(false);
        EventSystem.current.SetSelectedGameObject(ButtonResume);
    }
    public void ConfirmQuitYes()
    {
        Debug.Log("Application Quit");
        Application.Quit();
    }
    #endregion
    
    #region HelpMenu -> Button Methods
    public void CloseHelpMenu()
    {
        Panel_PauseMenu.SetActive(true);
        Panel_HelpMenu.SetActive(false);
        EventSystem.current.SetSelectedGameObject(ButtonResume);
    }
    #endregion
    
    #region SettingsMenu -> Button Methods
    public void CloseSettingsMenu()
    {
        Panel_PauseMenu.SetActive(true);
        Panel_SettingsMenu.SetActive(false);
        EventSystem.current.SetSelectedGameObject(ButtonResume);
    }
    
    public void SetMusicAudioLevel(float sliderValue)
    {
        PolesPlayer.Instance.moveSpeed = sliderValue;
    }
    #endregion
}
