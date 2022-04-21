using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Audio;

public enum ActivePage
{
    Page1,
    Page2,
    Page3
}

public class UserInterfaceOverworld : MonoBehaviour
{
    private bool gamePaused = false;
    
    [Header("Script References")]
    public InventoryObject Inventory;
    
    // All references
    #region HUD
    [Header("HUD Resources")]
    public Text TextMoney;
    public Text TextWood;
    #endregion
    
    #region PauseMenu
    [Header("Pause Menu")] 
    // Canvases
    public GameObject CanvasPauseMenu;
    public GameObject CanvasInventory;
    public GameObject CanvasDialoge;
    public GameObject CanvasSettings;
    
    // Buttons
    public GameObject ButtonResume;
    public GameObject ButtonInventory;
    public GameObject ButtonSettings;
    
    // confirm windows
    #region subRegion | Confirm Windows
    [Header("Confirm Windows")]
    // Confirm Menu/Quit windows
    public GameObject Image_ConfirmMenu;
    public GameObject Image_ConfirmQuit;
    // Confirm Menu/Quit buttons
    public GameObject Button_Menu_No;
    public GameObject Button_Quit_No;
    #endregion
    #endregion
    
    #region Inventory
    [Header("Inventory")]
    // Panels
    public GameObject PanelInventory;
    public GameObject PanelBackpack;
    public GameObject PanelLineUpPoles;
    public GameObject PanelLineUpAbilitys;
    
    private bool inventoryActive = false;
    
    // Panels Equip
    public GameObject PanelEquipLineUpPoles;
    public GameObject PanelEquipLineUpAbilitys;
    
    // Buttons
    public GameObject FirstButtonBagpack;
    public GameObject FirstButtonDefaultCards;
    public GameObject FirstButtonAbilityCards;
    
    // Texts equip on pole (1,2,3,4)
    public Text EquipPoleText;
    public Text EquipAbilityText;
    
    #region subRegion | Inventory LineUp's
    [Header("Inventory LineUP's")]
    
    // Panels Pole-Cards
    public GameObject PanelPoleCards1;
    public GameObject PanelPoleCards2;
    public GameObject PanelPoleCards3;
    // Panels Ability-Cards
    public GameObject PanelAbilityCards1;
    public GameObject PanelAbilityCards2;
    public GameObject PanelAbilityCards3;
    
    // Buttons
    public GameObject FirstButtonPoleCardPage1;
    public GameObject FirstButtonPoleCardPage2;
    public GameObject FirstButtonPoleCardPage3;

    public GameObject FirstButtonAbilityCardPage1;
    public GameObject FirstButtonAbilityCardPage2;
    public GameObject FirstButtonAbilityCardPage3;

    [Header("Buttons switching LineUp Panels")]
    public GameObject FirstButtonLeftArrowPoles;
    public GameObject FirstButtonRightArrowPoles;

    public GameObject FirstButtonLeftArrowAbilitys;
    public GameObject FirstButtonRightArrowAbilitys;
    #endregion
    #region subRegion | Inventory L1/R1 Navigation System
    void SwitchInventoryPanels()
    {
        int currentPanel = 1;
    
        var gamepad = Gamepad.current;
        if (gamepad.rightShoulder.wasPressedThisFrame)
        {
            if (currentPanel < 3)
            {
                currentPanel += 1;
            }
        }
        if (gamepad.leftShoulder.wasPressedThisFrame)
        {
            if (currentPanel > 1)
            {
                currentPanel -= 1;
            }
        }

        switch (currentPanel)
        {
            case 1:
                PanelBackpack.SetActive(true);
                PanelLineUpPoles.SetActive(false);
                PanelLineUpAbilitys.SetActive(false);
                EventSystem.current.SetSelectedGameObject(FirstButtonBagpack);
                break;
            case 2:
                PanelBackpack.SetActive(false);
                PanelLineUpPoles.SetActive(true);
                PanelLineUpAbilitys.SetActive(false);
                EventSystem.current.SetSelectedGameObject(FirstButtonDefaultCards);
                break;
            case 3:
                PanelBackpack.SetActive(false);
                PanelLineUpPoles.SetActive(false);
                PanelLineUpAbilitys.SetActive(true);
                EventSystem.current.SetSelectedGameObject(FirstButtonAbilityCards);
                break;

        }

    }
    #endregion
    #endregion
    
    #region Settings
    [Header("Settings")]
    // Buttons
    public GameObject FirstSelectedButtonSettings;
    
    // Audio
    public AudioMixer musicMixer;
    public AudioMixer ballMixer;
    #endregion
    
    #region Dialogue
    [Header("Dialogue")]
    // Buttons
    public GameObject FirstSelectedButtonDialoge;
    #endregion
    
    void Update()
    {
        // Resource texts
        TextMoney.text = Inventory.money.ToString();
        TextWood.text = Inventory.wood.ToString();
        
        // Get first selected buttons for pole and ability card equipping
        FirstButtonPoleCardPage1 = FirstButtonCardSelection.FirstButtonLineUpPoleCardPage1;
        FirstButtonAbilityCardPage1 = FirstButtonCardSelection.FirstButtonLineUpAbilityCardPage1;

        var gamepad = Gamepad.current;
        if (gamepad.startButton.wasPressedThisFrame)
        {
            if (gamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        
        #region Inventory switching input
        if (inventoryActive == true)
        {
            if(gamepad.rightShoulder.wasPressedThisFrame || gamepad.leftShoulder.wasPressedThisFrame)
            {
                SwitchInventoryPanels();
            }
        }
        #endregion
        
        #region close Inventory with east button
        if (inventoryActive == true && gamepad.buttonEast.wasPressedThisFrame)
        {
            CanvasPauseMenu.SetActive(true);
            CanvasInventory.SetActive(false);
            inventoryActive = false;

            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(ButtonResume);
        }
        #endregion
        
        #region close LineUp selection with east button
        if (PanelEquipLineUpPoles.activeInHierarchy && gamepad.buttonEast.wasPressedThisFrame)
        {
            inventoryActive = true;
            PanelInventory.SetActive(true);
            PanelEquipLineUpPoles.SetActive(false);
            EnableFirstPoleCardPage();

            EventSystem.current.SetSelectedGameObject(FirstButtonDefaultCards);
        }
        if (PanelEquipLineUpAbilitys.activeInHierarchy && gamepad.buttonEast.wasPressedThisFrame)
        {
            inventoryActive = true;
            PanelInventory.SetActive(true);
            PanelEquipLineUpAbilitys.SetActive(false);
            EnableFirstAbilityCardPage();

            EventSystem.current.SetSelectedGameObject(FirstButtonAbilityCards);
        }
        #endregion
    }

    // Methods 
    #region PauseMenu -> Methods
        
        // open/close
        #region subRegion | open/close Pausemenu
        void Pause()
        {
            CanvasPauseMenu.SetActive(true);
            gamePaused = true;
            //Time.timeScale = 0f;
            EventSystem.current.SetSelectedGameObject(ButtonResume);
        }

        public void Resume()
        {
            // unpause the game
            GameState currentGameState = GameStateManager.Instance.CurrentGameState;
            GameState newGameState = currentGameState == GameState.Gameplay
                ? GameState.Paused
                : GameState.Gameplay;
                
            GameStateManager.Instance.SetState(newGameState);
            
            // close UI
            CanvasPauseMenu.SetActive(false);
            CanvasInventory.SetActive(false);
            CanvasDialoge.SetActive(false);
            gamePaused = false;
            Time.timeScale = 1f;
        }
        #endregion
        #region subRegion | open/close Inventory
        public void OpenInventory()
        {
            CanvasPauseMenu.SetActive(false);
            CanvasInventory.SetActive(true);
            PanelBackpack.SetActive(true);

            inventoryActive = true;
            EventSystem.current.SetSelectedGameObject(ButtonInventory);
        }
    
        // Close Inventory Method is in Update
        #endregion
        #region subRegion | open/close SetingsCanvas
        public void OpenSettingsCanvas()
        {
            CanvasPauseMenu.SetActive(false);
            CanvasSettings.SetActive(true);
        
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(FirstSelectedButtonSettings);
        }
        public void CloseSettingsCanvas()
        {
            CanvasPauseMenu.SetActive(true);
            CanvasSettings.SetActive(false);
        
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(ButtonResume);
        }
        #endregion
        #region subRegion | open/close DialogueCanvas
        public void OpenDialogueCanvas()
        {
            CanvasPauseMenu.SetActive(false);
            CanvasDialoge.SetActive(true);
        
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(FirstSelectedButtonDialoge);
        
            // Close Dialogue Canvas is in dialogue manager script
        }
        #endregion
        
        // change scenes or quit
        #region subRegion | load MainMenu
        public void LoadMainMenu()
        {
            SceneManager.LoadScene(0);
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
        public void Menu()
        {
            Image_ConfirmMenu.SetActive(true);
            EventSystem.current.SetSelectedGameObject(Button_Menu_No);
        }
        #endregion
        #region subRegion | Quit
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
        public void Quit()
        {
            Image_ConfirmQuit.SetActive(true);
            EventSystem.current.SetSelectedGameObject(Button_Quit_No);
        }
        #endregion

        #endregion
        
    #region SettingsMenu -> Methods
    // changes the volume of the music
    public void SetMusicAudioLevel(float sliderValue)
    {
        musicMixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 50);
    }

    // changes the volume of the music
    public void SetBallAudioLevel(float sliderValue)
    {
        ballMixer.SetFloat("BallVolume", Mathf.Log10(sliderValue) * 50);
    }
       
    #endregion
    
    #region Inventory -> Methods
   
        // Navigation methods
        #region subRegion | Navigation Pole Card Pages

        ActivePage activePolePage = ActivePage.Page1;

        public void EnableNextPage()
        {
            switch (activePolePage)
            {
                case ActivePage.Page1:
                    EventSystem.current.SetSelectedGameObject(FirstButtonRightArrowPoles);
                    EnableSecondPoleCardPage();
                    break;
                case ActivePage.Page2:
                    EventSystem.current.SetSelectedGameObject(FirstButtonRightArrowPoles);
                    EnableThirdPoleCardPage();
                    break;
                case ActivePage.Page3:
                    break;
            }
        }

        public void EnablePreviousPage()
        {
            switch (activePolePage)
            {
                case ActivePage.Page1:
                    break;
                case ActivePage.Page2:
                    EventSystem.current.SetSelectedGameObject(FirstButtonLeftArrowPoles);
                    EnableFirstPoleCardPage();
                    break;
                case ActivePage.Page3:
                    EventSystem.current.SetSelectedGameObject(FirstButtonLeftArrowPoles);
                    EnableSecondPoleCardPage();
                    break;
            }
        }

        public void EnableFirstPoleCardPage()
        {
            EventSystem.current.SetSelectedGameObject(FirstButtonPoleCardPage1);
            activePolePage = ActivePage.Page1;
            PanelPoleCards1.SetActive(true);
            PanelPoleCards2.SetActive(false);
            PanelPoleCards3.SetActive(false);
        }

        public void EnableSecondPoleCardPage()
        {
            activePolePage = ActivePage.Page2;
            PanelPoleCards1.SetActive(false);
            PanelPoleCards2.SetActive(true);
            PanelPoleCards3.SetActive(false);
        }

        public void EnableThirdPoleCardPage()
        {
            activePolePage = ActivePage.Page3;
            PanelPoleCards1.SetActive(false);
            PanelPoleCards2.SetActive(false);
            PanelPoleCards3.SetActive(true);
        }

        #endregion
        #region subRegion | Navigation Ability Card Pages

        ActivePage activeAbilityPage = ActivePage.Page1;

        public void EnableNextAbilityPage()
        {
            switch (activeAbilityPage)
            {
                case ActivePage.Page1:
                    EventSystem.current.SetSelectedGameObject(FirstButtonRightArrowAbilitys);
                    EnableSecondAbilityCardPage();
                    break;
                case ActivePage.Page2:
                    EventSystem.current.SetSelectedGameObject(FirstButtonRightArrowAbilitys);
                    EnableThirdAbilityCardPage();
                    break;
                case ActivePage.Page3:
                    break;
                default:
                    break;
            }
        }

        public void EnablePreviousAbilityPage()
        {
            switch (activeAbilityPage)
            {
                case ActivePage.Page1:
                    break;
                case ActivePage.Page2:
                    EventSystem.current.SetSelectedGameObject(FirstButtonLeftArrowAbilitys);
                    EnableFirstAbilityCardPage();
                    break;
                case ActivePage.Page3:
                    EventSystem.current.SetSelectedGameObject(FirstButtonLeftArrowAbilitys);
                    EnableSecondAbilityCardPage();
                    break;
                default:
                    break;
            }
        }

        public void EnableFirstAbilityCardPage()
        {
            EventSystem.current.SetSelectedGameObject(FirstButtonAbilityCardPage1);
            activeAbilityPage = ActivePage.Page1;
            PanelAbilityCards1.SetActive(true);
            PanelAbilityCards2.SetActive(false);
            PanelAbilityCards3.SetActive(false);
        }

        public void EnableSecondAbilityCardPage()
        {
            activeAbilityPage = ActivePage.Page2;
            PanelAbilityCards1.SetActive(false);
            PanelAbilityCards2.SetActive(true);
            PanelAbilityCards3.SetActive(false);
        }

        public void EnableThirdAbilityCardPage()
        {
            activeAbilityPage = ActivePage.Page3;
            PanelAbilityCards1.SetActive(false);
            PanelAbilityCards2.SetActive(false);
            PanelAbilityCards3.SetActive(true);
        }
        #endregion
        
        // Equip Cards
        #region subRegion | PoleCard Button methods
        // When a button for a pole is selected, the current pole to equip the cards on is selected.
        public void SetActivePoleMain()
        {
            LineUpController.CardType = true;
            EquipPoleText.text = "Equip Main Pole\nCards";
            inventoryActive = false;
            LineUpController.ActivePole = 0;
            
            PanelInventory.SetActive(false);
            PanelEquipLineUpPoles.SetActive(true);
            EnableFirstPoleCardPage();
            
            EventSystem.current.SetSelectedGameObject(FirstButtonPoleCardPage1);
        }
        public void SetActivePoleFirst()
        {
            LineUpController.CardType = true;
            EquipPoleText.text = "Equip Crew Pole 1\nCards";
            inventoryActive = false;
            LineUpController.ActivePole = 1;
            
            PanelInventory.SetActive(false);
            PanelEquipLineUpPoles.SetActive(true);
            EnableFirstPoleCardPage();
            
            EventSystem.current.SetSelectedGameObject(FirstButtonPoleCardPage1);
        }
        public void SetActivePoleSecond()
        {
            LineUpController.CardType = true;
            EquipPoleText.text = "Equip Crew Pole 2\nCards";
            inventoryActive = false;
            LineUpController.ActivePole = 2;
            
            PanelInventory.SetActive(false);
            PanelEquipLineUpPoles.SetActive(true);
            EnableFirstPoleCardPage();
    
            EventSystem.current.SetSelectedGameObject(FirstButtonPoleCardPage1);
        }
        public void SetActivePoleThird()
        {
            LineUpController.CardType = true;
            EquipPoleText.text = "Equip Crew Pole 3\nCards";
            inventoryActive = false;
            LineUpController.ActivePole = 3;
            
            PanelInventory.SetActive(false);
            PanelEquipLineUpPoles.SetActive(true);
            EnableFirstPoleCardPage();
            
            EventSystem.current.SetSelectedGameObject(FirstButtonPoleCardPage1);
        }
    
        #endregion
        #region subRegion | AbilityCard Button methods
        // When a button for a pole is selected, the current pole to equip the cards on is selected.
        public void SetActiveAbilityMain()
        {
            LineUpController.CardType = false;
            EquipAbilityText.text = "Equip Main Ability\nCards";
            inventoryActive = false;
            LineUpController.ActivePole = 0;
    
            PanelInventory.SetActive(false);
            PanelEquipLineUpAbilitys.SetActive(true);
            EnableFirstAbilityCardPage();
    
            EventSystem.current.SetSelectedGameObject(FirstButtonAbilityCardPage1);
        }
        public void SetActiveAbilityFirst()
        {
            LineUpController.CardType = false;
            EquipAbilityText.text = "Equip Crew Pole 1\nCards";
            inventoryActive = false;
            LineUpController.ActivePole = 1;
    
            PanelInventory.SetActive(false);
            PanelEquipLineUpAbilitys.SetActive(true);
            EnableFirstAbilityCardPage();
    
            EventSystem.current.SetSelectedGameObject(FirstButtonAbilityCardPage1);
        }
        public void SetActiveAbilitySecond()
        {
            LineUpController.CardType = false;
            EquipAbilityText.text = "Equip Crew Pole 2\nCards";
            inventoryActive = false;
            LineUpController.ActivePole = 2;
    
            PanelInventory.SetActive(false);
            PanelEquipLineUpAbilitys.SetActive(true);
            EnableFirstAbilityCardPage();
    
            EventSystem.current.SetSelectedGameObject(FirstButtonAbilityCardPage1);
        }
        public void SetActiveAbilityThird()
        {
            LineUpController.CardType = false;
            EquipAbilityText.text = "Equip Crew Pole 3\nCards";
            inventoryActive = false;
            LineUpController.ActivePole = 3;
    
            PanelInventory.SetActive(false);
            PanelEquipLineUpAbilitys.SetActive(true);
            EnableFirstAbilityCardPage();
    
            EventSystem.current.SetSelectedGameObject(FirstButtonAbilityCardPage1);
        }
        #endregion
        
    #endregion
    
}



