using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Audio;

public class ClashPauseUI : MonoBehaviour
{
    #region Variables / References
    [Header("Canvas")]
    public GameObject Canvas_PauseMenu;

    [Header("Panels")]
    public GameObject Panel_PauseMenu;
    public GameObject Panel_HelpMenu;
    public GameObject Panel_SettingsMenu;
    public GameObject Panel_Controlls;
    public GameObject Panel_Tipps;
    
    [Header("Images")]
    public GameObject Image_ConfirmMenu;
    public GameObject Image_ConfirmQuit;

    [Header("Buttons/Panel Pause")]
    public GameObject ButtonResume;
    // Confirm Images button
    public GameObject Button_Menu_No;
    public GameObject Button_Quit_No;
    
    [Header("Buttons/Panel Help")]
    public GameObject ButtonOpenControlls;
    public GameObject ButtonOpenTipps;
    public GameObject ButtonCloseControlls;
    public GameObject ButtonCloseTipps;
    public GameObject ButtonCloseHelp;
    
    [Header("Buttons/Panel Settings")]
    public GameObject ButtonCloseSettings;
    
    #endregion

    #region Input System -> Pause Game
    public void Pause(InputAction.CallbackContext context)
    {
        Time.timeScale = 0;
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
        SceneManager.LoadScene(1);
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
    public void ControllsPanel()
    {
        Panel_HelpMenu.SetActive(false);
        Panel_Controlls.SetActive(true); 
        EventSystem.current.SetSelectedGameObject(ButtonCloseControlls);
    }
    public void TippsPanel()
    {
        Panel_HelpMenu.SetActive(false);
        Panel_Tipps.SetActive(true); 
        EventSystem.current.SetSelectedGameObject(ButtonCloseTipps);
    }
    
    public void CloseControllsPanel()
    {
        Panel_HelpMenu.SetActive(true);
        Panel_Controlls.SetActive(false); 
        EventSystem.current.SetSelectedGameObject(ButtonCloseHelp);
    }
    public void CloseTippsPanel()
    {
        Panel_HelpMenu.SetActive(true);
        Panel_Tipps.SetActive(false); 
        EventSystem.current.SetSelectedGameObject(ButtonCloseHelp);
    }
    public void CloseHelpMenu()
    {
        Panel_PauseMenu.SetActive(true);
        Panel_HelpMenu.SetActive(false);
        EventSystem.current.SetSelectedGameObject(ButtonResume);
    }
    #endregion
    
    #region SettingsMenu -> Button Methods
    
    [Header("Lights")]
    public GameObject DayLight;
    public GameObject NightLight;
    
    public AudioMixer MusicMixer;
    public void CloseSettingsMenu()
    {
        Panel_PauseMenu.SetActive(true);
        Panel_SettingsMenu.SetActive(false);
        EventSystem.current.SetSelectedGameObject(ButtonResume);
    }
    
    // Pole control settings
    public void SetPoleSpeed(float sliderValue)
    {
        PolesPlayer.Instance.MoveSpeed = sliderValue;
    }
    public void SetRotationSpeed(float sliderValue)
    {
        PolesPlayer.Instance.RotationSpeed = sliderValue;
    }
    public void SetMusicAudioLevel(float sliderValue)
    {
        MusicMixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 50);
    }
    // Light settings
    public void SetDayLight()
    {
        DayLight.SetActive(true);
        NightLight.SetActive(false);
    }
    public void SetNightLight()
    {
        DayLight.SetActive(false);
        NightLight.SetActive(true);
    }
    #endregion
}
