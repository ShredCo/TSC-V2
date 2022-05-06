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
    int currentPanel = 2;
    
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
    [SerializeField] GameObject canvasPauseMenu;
    [SerializeField] GameObject canvasInventory;
    [SerializeField] GameObject canvasSettings;
    [SerializeField] GameObject canvasHelpMenu;
    public GameObject CanvasDialoge;
    
    // Buttons
    [SerializeField] GameObject buttonResume;
    [SerializeField] GameObject buttonInventory;
    [SerializeField] GameObject buttonSettings;
    
    // confirm windows
    #region subRegion | Confirm Windows
    [Header("Confirm Windows")]
    // Confirm Menu/Quit windows
    [SerializeField] GameObject ImageConfirmMenu;
    [SerializeField] GameObject ImageConfirmQuit;
    // Confirm Menu/Quit buttons
    [SerializeField] GameObject buttonOpenMenuNo;
    [SerializeField] GameObject buttonOpenQuitNo;
    #endregion
    #endregion
    
    #region Inventory
    [Header("Inventory")]
    // Panels
    [SerializeField] GameObject panelInventory;
    [SerializeField] GameObject panelBackpack;
    [SerializeField] GameObject panelLineUpPoles;
    [SerializeField] GameObject panelLineUpAbilitys;
    
    private bool inventoryActive = false;
    
    // Panels Equip
    [SerializeField] GameObject panelPoleCollection;
    [SerializeField] GameObject panelAbilityCollection;
    
    // Buttons
    [SerializeField] GameObject firstButtonBagpack;
    [SerializeField] GameObject firstButtonPoleLineup;
    [SerializeField] GameObject firstButtonAbilityLineUp;
    
    // Texts equip on pole (1,2,3,4)
    [SerializeField] Text equipPoleText;
    [SerializeField] Text equipAbilityText;
    
    #region subRegion | Inventory LineUp's
    [Header("Inventory LineUP's")]
    
    // Panels Pole-Cards
    [SerializeField] GameObject panelPoleCollection_Page1;
    [SerializeField] GameObject panelPoleCollection_Page2;
    [SerializeField] GameObject panelPoleCollection_Page3;
    // Panels Ability-Cards
    [SerializeField] GameObject panelAbilityCollection_Page1;
    [SerializeField] GameObject panelAbilityCollection_Page2;
    [SerializeField] GameObject panelAbilityCollection_Page3;
    
    // Buttons
    [SerializeField] GameObject firstButtonPoleCollection_Page1;
    [SerializeField] GameObject firstButtonPoleCollection_Page2;
    [SerializeField] GameObject firstButtonPoleCollection_Page3;

    [SerializeField] GameObject firstButtonAbilityCollection_Page1;
    [SerializeField] GameObject firstButtonAbilityCollection_Page2;
    [SerializeField] GameObject firstButtonAbilityCollection_Page3;

    [Header("Buttons switching LineUp Panels")]
    [SerializeField] GameObject previousButtonPoleCollection;
    [SerializeField] GameObject nextButtonPoleCollection;

    [SerializeField] GameObject previousButtonAbilityCollection;
    [SerializeField] GameObject nextButtonAbilityCollection;
    #endregion
    #region subRegion | Inventory L1/R1 Navigation System

    [SerializeField] Button switchButtonBackpack;
    [SerializeField] Button switchButtonPoleCards;
    [SerializeField] Button switchButtonAbilityCards;

    void SwitchInventoryPanels()
    {
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
                switchButtonBackpack.image.color = new Color(0.6705f, 0.3176f, 0.3176f);
                switchButtonPoleCards.image.color = Color.white;
                switchButtonAbilityCards.image.color = Color.white;
                panelBackpack.SetActive(true);
                panelLineUpPoles.SetActive(false);
                panelLineUpAbilitys.SetActive(false);
                EventSystem.current.SetSelectedGameObject(firstButtonBagpack);
                break;
            case 2:
                switchButtonBackpack.image.color = Color.white;
                switchButtonPoleCards.image.color = new Color(0.6705f, 0.3176f, 0.3176f);
                switchButtonAbilityCards.image.color = Color.white;
                panelBackpack.SetActive(false);
                panelLineUpPoles.SetActive(true);
                panelLineUpAbilitys.SetActive(false);
                EventSystem.current.SetSelectedGameObject(firstButtonPoleLineup);
                break;
            case 3:
                switchButtonBackpack.image.color = Color.white;
                switchButtonPoleCards.image.color = Color.white;
                switchButtonAbilityCards.image.color = new Color(0.6705f, 0.3176f, 0.3176f);
                panelBackpack.SetActive(false);
                panelLineUpPoles.SetActive(false);
                panelLineUpAbilitys.SetActive(true);
                EventSystem.current.SetSelectedGameObject(firstButtonAbilityLineUp);
                break;
        }
    }
    #endregion
    #endregion
    
    #region Settings
    [Header("Settings")]
    // Buttons
    [SerializeField] GameObject closeButtonSettings;
    
    // Audio
    [SerializeField] AudioMixer musicMixer;
    [SerializeField] AudioMixer ballMixer;
    #endregion
    
    #region Dialogue
    [Header("Dialogue")]
    // Buttons
    [SerializeField] GameObject nextButtonDialoge;
    #endregion
    
    #region Help
    [Header("Help")]
    //Panels
    [SerializeField] GameObject panelHelpMenu;
    [SerializeField] GameObject panelControlls;
    [SerializeField] GameObject panelTipps;
    
    // Buttons
    [SerializeField] GameObject buttonControlls;
    [SerializeField] GameObject buttonTipps;
    [SerializeField] GameObject closeButtonControlls;
    [SerializeField] GameObject closeButtonHelpMenu;
    [SerializeField] GameObject closeButtonTipps;
    #endregion
    
    void Update()
    {
        // Resource texts
        TextMoney.text = Inventory.Money.ToString();
        TextWood.text = Inventory.Wood.ToString();
        
        // Get first selected buttons for pole and ability card equipping
        firstButtonPoleCollection_Page1 = FirstButtonCardSelection.FirstButtonLineUpPoleCardPage1;
        firstButtonAbilityCollection_Page1 = FirstButtonCardSelection.FirstButtonLineUpAbilityCardPage1;

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
            canvasPauseMenu.SetActive(true);
            canvasInventory.SetActive(false);
            inventoryActive = false;

            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(buttonResume);
        }
        #endregion
        
        #region close LineUp selection with east button
        if (panelPoleCollection.activeInHierarchy && gamepad.buttonEast.wasPressedThisFrame)
        {
            inventoryActive = true;
            panelInventory.SetActive(true);
            panelPoleCollection.SetActive(false);
            EnableFirstPoleCardPage();

            EventSystem.current.SetSelectedGameObject(firstButtonPoleLineup);
        }
        if (panelAbilityCollection.activeInHierarchy && gamepad.buttonEast.wasPressedThisFrame)
        {
            inventoryActive = true;
            panelInventory.SetActive(true);
            panelAbilityCollection.SetActive(false);
            EnableFirstAbilityCardPage();

            EventSystem.current.SetSelectedGameObject(firstButtonAbilityLineUp);
        }
        #endregion
    }

    // Methods 
    #region PauseMenu -> Methods
        
        // open/close
        #region subRegion | open/close Pausemenu
        void Pause()
        {
            canvasPauseMenu.SetActive(true);
            gamePaused = true;
            //Time.timeScale = 0f;
            EventSystem.current.SetSelectedGameObject(buttonResume);
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
            canvasPauseMenu.SetActive(false);
            canvasInventory.SetActive(false);
            CanvasDialoge.SetActive(false);
            gamePaused = false;
            Time.timeScale = 1f;
        }
        #endregion
        #region subRegion | open/close Inventory
        public void OpenInventory()
        {
            panelBackpack.SetActive(false);
            panelLineUpPoles.SetActive(true);
            panelLineUpAbilitys.SetActive(false);
            canvasPauseMenu.SetActive(false);
            canvasInventory.SetActive(true);
            switchButtonBackpack.image.color = Color.white;
            switchButtonPoleCards.image.color = new Color(0.6705f, 0.3176f, 0.3176f);
            switchButtonAbilityCards.image.color = Color.white;

            inventoryActive = true;
            EventSystem.current.SetSelectedGameObject(firstButtonPoleLineup);
        }
    
        // Close Inventory Method is in Update
        #endregion
        #region subRegion | open/close Setings
        public void OpenSettingsCanvas()
        {
            canvasPauseMenu.SetActive(false);
            canvasSettings.SetActive(true);
        
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(closeButtonSettings);
        }
        public void CloseSettingsCanvas()
        {
            canvasPauseMenu.SetActive(true);
            canvasSettings.SetActive(false);
        
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(buttonResume);
        }
        #endregion
        #region subRegion | open/close Dialogue
        public void OpenDialogueCanvas()
        {
            canvasPauseMenu.SetActive(false);
            CanvasDialoge.SetActive(true);
            
            EventSystem.current.SetSelectedGameObject(nextButtonDialoge);
        
            // Close Dialogue Canvas is in dialogue manager script
        }
        #endregion 
        #region subRegion | open/close Help
        public void OpenHelpCanvas()
        {
            canvasPauseMenu.SetActive(false);
            canvasHelpMenu.SetActive(true);
            
            EventSystem.current.SetSelectedGameObject(closeButtonHelpMenu);
        }
        
        public void CloseHelpCanvas()
        {
            canvasPauseMenu.SetActive(true);
            canvasHelpMenu.SetActive(false);

            EventSystem.current.SetSelectedGameObject(buttonResume);
        }
        #endregion
        
        // change scenes or quit
        #region subRegion | load MainMenu
        // Confirm Menu/Quit Methods
        public void ConfirmMenuNo()
        {
            ImageConfirmMenu.SetActive(false);
            EventSystem.current.SetSelectedGameObject(buttonResume);
        }
        public void ConfirmMenuYes()
        {
            SceneLoading.Instance.nextScene = NextScene.MainMenu;
            SceneManager.LoadScene(3);
        }
        public void Menu()
        {
            ImageConfirmMenu.SetActive(true);
            EventSystem.current.SetSelectedGameObject(buttonOpenMenuNo);
        }
        #endregion
        #region subRegion | Quit
        public void ConfirmQuitNo()
        {
            ImageConfirmQuit.SetActive(false);
            EventSystem.current.SetSelectedGameObject(buttonResume);
        }
        public void ConfirmQuitYes()
        {
            Debug.Log("Application Quit");
            Application.Quit();
        }
        public void Quit()
        {
            ImageConfirmQuit.SetActive(true);
            EventSystem.current.SetSelectedGameObject(buttonOpenQuitNo);
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
                    EventSystem.current.SetSelectedGameObject(nextButtonPoleCollection);
                    EnableSecondPoleCardPage();
                    break;
                case ActivePage.Page2:
                    EventSystem.current.SetSelectedGameObject(nextButtonPoleCollection);
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
                    EventSystem.current.SetSelectedGameObject(previousButtonPoleCollection);
                    EnableFirstPoleCardPage();
                    break;
                case ActivePage.Page3:
                    EventSystem.current.SetSelectedGameObject(previousButtonPoleCollection);
                    EnableSecondPoleCardPage();
                    break;
            }
        }

        public void EnableFirstPoleCardPage()
        {
            EventSystem.current.SetSelectedGameObject(firstButtonPoleCollection_Page1);
            activePolePage = ActivePage.Page1;
            panelPoleCollection_Page1.SetActive(true);
            panelPoleCollection_Page2.SetActive(false);
            panelPoleCollection_Page3.SetActive(false);
        }

        public void EnableSecondPoleCardPage()
        {
            activePolePage = ActivePage.Page2;
            panelPoleCollection_Page1.SetActive(false);
            panelPoleCollection_Page2.SetActive(true);
            panelPoleCollection_Page3.SetActive(false);
        }

        public void EnableThirdPoleCardPage()
        {
            activePolePage = ActivePage.Page3;
            panelPoleCollection_Page1.SetActive(false);
            panelPoleCollection_Page2.SetActive(false);
            panelPoleCollection_Page3.SetActive(true);
        }

        #endregion
        #region subRegion | Navigation Ability Card Pages

        ActivePage activeAbilityPage = ActivePage.Page1;

        public void EnableNextAbilityPage()
        {
            switch (activeAbilityPage)
            {
                case ActivePage.Page1:
                    EventSystem.current.SetSelectedGameObject(nextButtonAbilityCollection);
                    EnableSecondAbilityCardPage();
                    break;
                case ActivePage.Page2:
                    EventSystem.current.SetSelectedGameObject(nextButtonAbilityCollection);
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
                    EventSystem.current.SetSelectedGameObject(previousButtonAbilityCollection);
                    EnableFirstAbilityCardPage();
                    break;
                case ActivePage.Page3:
                    EventSystem.current.SetSelectedGameObject(previousButtonAbilityCollection);
                    EnableSecondAbilityCardPage();
                    break;
                default:
                    break;
            }
        }

        public void EnableFirstAbilityCardPage()
        {
            EventSystem.current.SetSelectedGameObject(firstButtonAbilityCollection_Page1);
            activeAbilityPage = ActivePage.Page1;
            panelAbilityCollection_Page1.SetActive(true);
            panelAbilityCollection_Page2.SetActive(false);
            panelAbilityCollection_Page3.SetActive(false);
        }

        public void EnableSecondAbilityCardPage()
        {
            activeAbilityPage = ActivePage.Page2;
            panelAbilityCollection_Page1.SetActive(false);
            panelAbilityCollection_Page2.SetActive(true);
            panelAbilityCollection_Page3.SetActive(false);
        }

        public void EnableThirdAbilityCardPage()
        {
            activeAbilityPage = ActivePage.Page3;
            panelAbilityCollection_Page1.SetActive(false);
            panelAbilityCollection_Page2.SetActive(false);
            panelAbilityCollection_Page3.SetActive(true);
        }
        #endregion
        
        // Equip Cards
        #region subRegion | PoleCard Button methods
        // When a button for a pole is selected, the current pole to equip the cards on is selected.
        public void SetActivePoleMain()
        {
            LineUpController.CardType = true;
            equipPoleText.text = "Equip Main Pole\nCards";
            inventoryActive = false;
            LineUpController.ActivePole = 0;
            
            panelInventory.SetActive(false);
            panelPoleCollection.SetActive(true);
            EnableFirstPoleCardPage();
            
            EventSystem.current.SetSelectedGameObject(FirstButtonCardSelection.FirstButtonLineUpPoleCardPage1);
        }
        public void SetActivePoleFirst()
        {
            LineUpController.CardType = true;
            equipPoleText.text = "Equip Crew1 Pole\nCards";
            inventoryActive = false;
            LineUpController.ActivePole = 1;
            
            panelInventory.SetActive(false);
            panelPoleCollection.SetActive(true);
            EnableFirstPoleCardPage();
            
            EventSystem.current.SetSelectedGameObject(FirstButtonCardSelection.FirstButtonLineUpPoleCardPage1);
        }
        public void SetActivePoleSecond()
        {
            LineUpController.CardType = true;
            equipPoleText.text = "Equip Crew2 Pole\nCards";
            inventoryActive = false;
            LineUpController.ActivePole = 2;
            
            panelInventory.SetActive(false);
            panelPoleCollection.SetActive(true);
            EnableFirstPoleCardPage();
    
            EventSystem.current.SetSelectedGameObject(FirstButtonCardSelection.FirstButtonLineUpPoleCardPage1);
        }
        public void SetActivePoleThird()
        {
            LineUpController.CardType = true;
            equipPoleText.text = "Equip Crew3 Pole\nCards";
            inventoryActive = false;
            LineUpController.ActivePole = 3;
            
            panelInventory.SetActive(false);
            panelPoleCollection.SetActive(true);
            EnableFirstPoleCardPage();
            
            EventSystem.current.SetSelectedGameObject(FirstButtonCardSelection.FirstButtonLineUpPoleCardPage1);
        }
    
        #endregion
        #region subRegion | AbilityCard Button methods
        // When a button for a pole is selected, the current pole to equip the cards on is selected.
        public void SetActiveAbilityMain()
        {
            LineUpController.CardType = false;
            equipAbilityText.text = "Equip Main Ability\nCards";
            inventoryActive = false;
            LineUpController.ActivePole = 0;
    
            panelInventory.SetActive(false);
            panelAbilityCollection.SetActive(true);
            EnableFirstAbilityCardPage();
    
            EventSystem.current.SetSelectedGameObject(firstButtonAbilityCollection_Page1);
        }
        public void SetActiveAbilityFirst()
        {
            LineUpController.CardType = false;
            equipAbilityText.text = "Equip Crew Pole 1\nCards";
            inventoryActive = false;
            LineUpController.ActivePole = 1;
    
            panelInventory.SetActive(false);
            panelAbilityCollection.SetActive(true);
            EnableFirstAbilityCardPage();
    
            EventSystem.current.SetSelectedGameObject(firstButtonAbilityCollection_Page1);
        }
        public void SetActiveAbilitySecond()
        {
            LineUpController.CardType = false;
            equipAbilityText.text = "Equip Crew Pole 2\nCards";
            inventoryActive = false;
            LineUpController.ActivePole = 2;
    
            panelInventory.SetActive(false);
            panelAbilityCollection.SetActive(true);
            EnableFirstAbilityCardPage();
    
            EventSystem.current.SetSelectedGameObject(firstButtonAbilityCollection_Page1);
        }
        public void SetActiveAbilityThird()
        {
            LineUpController.CardType = false;
            equipAbilityText.text = "Equip Crew Pole 3\nCards";
            inventoryActive = false;
            LineUpController.ActivePole = 3;
    
            panelInventory.SetActive(false);
            panelAbilityCollection.SetActive(true);
            EnableFirstAbilityCardPage();
    
            EventSystem.current.SetSelectedGameObject(firstButtonAbilityCollection_Page1);
        }
        #endregion
        
    #endregion
    
    #region HelpMenu -> Methods
    public void OpenControlls()
    {
        panelHelpMenu.SetActive(false);
        panelControlls.SetActive(true);
        EventSystem.current.SetSelectedGameObject(closeButtonControlls);
    }
    public void OpenTipps()
    {
        panelHelpMenu.SetActive(false);
        panelTipps.SetActive(true);
        EventSystem.current.SetSelectedGameObject(closeButtonTipps);
    }
    public void CloseControlls()
    {
        panelHelpMenu.SetActive(true);
        panelControlls.SetActive(false);
        EventSystem.current.SetSelectedGameObject(buttonControlls);
    }
    public void CloseTipps()
    {
        panelHelpMenu.SetActive(true);
        panelTipps.SetActive(false);
        EventSystem.current.SetSelectedGameObject(buttonTipps);
    }
    #endregion
}



