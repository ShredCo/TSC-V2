using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class UserInterfaceOverworld : MonoBehaviour
{
    
    [Header("Script References")]
    public InventoryObject inventory;
    
    #region Inventory Canvas/Panels
    [Header("Canvases")] 
    public GameObject canvasPauseMenu;
    public GameObject canvasInventory;
    public GameObject canvasDialoge;
    public GameObject canvasSettings;

    [Header("Panels Inventory")] 
    public GameObject panelInventory;
    public GameObject panelBackpack;
    public GameObject panelLineUpTeam;
    public GameObject panelLineUpAbilitys;
    
    [Header("Panels equip cards")]
    public GameObject panelEquipPoleCards;
    public GameObject panelEquipAbilityCards;
    
    // Buttons
    [Header("Buttons Pausenmenu")]
    public GameObject firstButtonPauseMenu;
    public GameObject firstButtonInventory;
    public GameObject firstButtonSettings;
    
    [Header("Buttons Inventory")]
    public GameObject firstButtonBagpack;
    public GameObject firstButtonLineUpPoleCards;
    public GameObject firstButtonLineUpPoleAbilitys;
    #endregion
    
    #region Inventory Submenu Canvas/Panels/Buttons
    [Header("Panels LineUP Team")]
    public GameObject panelPoleCards1;
    public GameObject panelPoleCards2;
    public GameObject panelPoleCards3;
    
    [Header("Panels LineUP Team")]
    public GameObject panelAbilityCards1;
    public GameObject panelAbilityCards2;
    public GameObject panelAbilityCards3;
    
    // Buttons
    [Header("Buttons LineUps")]
    public GameObject firstButtonPoleCard;
    public GameObject firstButtonAbilityCard;
    #endregion
    
    [Header("Dialoge first selected buttons")]
    public GameObject firstSelectedButtonDialoge;
    
    public int currentPanel = 1;
    private bool gamePaused = false;
    private bool inventoryActive = false;

    [SerializeField] public Text textMoney;

    void Update()
    {
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
        
        textMoney.text = inventory.money.ToString();
        Debug.Log(inventory.money);

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
            EventSystem.current.SetSelectedGameObject(firstButtonPauseMenu);
        }
        #endregion
    }

    #region open/close Pausemenu
    void Pause()
    {
        canvasPauseMenu.SetActive(true);
        gamePaused = true;
        //Time.timeScale = 0f;
        EventSystem.current.SetSelectedGameObject(firstButtonPauseMenu);
    }

    public void Resume()
    {
        canvasPauseMenu.SetActive(false);
        canvasInventory.SetActive(false);
        canvasDialoge.SetActive(false);
        gamePaused = false;
        Time.timeScale = 1f;
        //EventSystem.current.SetSelectedGameObject(firstButtonPauseMenu);
    }
    #endregion

    #region openInventory

    public void openInventory()
    {
        canvasPauseMenu.SetActive(false);
        canvasInventory.SetActive(true);
        panelBackpack.SetActive(true);

        inventoryActive = true;
        EventSystem.current.SetSelectedGameObject(firstButtonInventory);
    }
    #endregion
    
    #region openDialogeCanvas

    public void openDialogeCanvas()
    {
        canvasPauseMenu.SetActive(false);
        canvasDialoge.SetActive(true);
        
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstSelectedButtonDialoge);
    }
    #endregion
    
   

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
   

    #region L1/R1 Navigation System 

    // TODO: Animate the buttons when switching
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
                panelBackpack.SetActive(true);
                panelLineUpTeam.SetActive(false);
                panelLineUpAbilitys.SetActive(false);
                EventSystem.current.SetSelectedGameObject(firstButtonBagpack);
                break;
            case 2:
                panelBackpack.SetActive(false);
                panelLineUpTeam.SetActive(true);
                panelLineUpAbilitys.SetActive(false);
                EventSystem.current.SetSelectedGameObject(firstButtonLineUpPoleCards);
                break;
            case 3:
                panelBackpack.SetActive(false);
                panelLineUpTeam.SetActive(false);
                panelLineUpAbilitys.SetActive(true);
                EventSystem.current.SetSelectedGameObject(firstButtonLineUpPoleAbilitys);
                break;

        }

    }
    #endregion

    #region Navigation Card Pages
    public void EnableFirstPage()
    {
        panelPoleCards1.SetActive(true);
        panelPoleCards2.SetActive(false);
        panelPoleCards3.SetActive(false);
    }

    public void EnableSecondPage()
    {
        panelPoleCards1.SetActive(false);
        panelPoleCards2.SetActive(true);
        panelPoleCards3.SetActive(false);
    }

    public void EnableThirdPage()
    {
        panelPoleCards1.SetActive(false);
        panelPoleCards2.SetActive(false);
        panelPoleCards3.SetActive(true);
    }

    #endregion

    #region PoleCard Button methods
    // When a button for a pole is selected, the current pole to equip the cards on is selected.
    public void SetActivePoleMain()
    {
        LineUpController.ActivePole = 0;
        
        panelInventory.SetActive(false);
        panelEquipPoleCards.SetActive(true);
        EnableFirstPage();
        
        EventSystem.current.SetSelectedGameObject(firstButtonPoleCard);
        Debug.Log(LineUpController.ActivePole);
    }
    public void SetActivePoleFirst()
    {
        LineUpController.ActivePole = 1;
        
        panelInventory.SetActive(false);
        panelEquipPoleCards.SetActive(true);
        EnableFirstPage();
        
        EventSystem.current.SetSelectedGameObject(firstButtonPoleCard);
        Debug.Log(LineUpController.ActivePole);
    }
    public void SetActivePoleSecond()
    {
        LineUpController.ActivePole = 2;
        
        panelInventory.SetActive(false);
        panelEquipPoleCards.SetActive(true);
        EnableFirstPage();

        EventSystem.current.SetSelectedGameObject(firstButtonPoleCard);
        Debug.Log(LineUpController.ActivePole);
    }
    public void SetActivePoleThird()
    {
        LineUpController.ActivePole = 3;
        
        panelInventory.SetActive(false);
        panelEquipPoleCards.SetActive(true);
        EnableFirstPage();
        
        EventSystem.current.SetSelectedGameObject(firstButtonPoleCard);
        Debug.Log(LineUpController.ActivePole);
    }

    #endregion
}



