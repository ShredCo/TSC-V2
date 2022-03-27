using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UserInterfaceOverworld : MonoBehaviour
{
    [Header("DialogeSystem Panels")] 
    public GameObject canvasPauseMenu;
    public GameObject canvasInventory;
    public GameObject canvasDialoge;
    
    [Header("Inventory Panels")]
    public GameObject panelBackpack;
    public GameObject panelCards;
    public GameObject panelPoles;

    [Header("Pausemenu first selected buttons")]
    public GameObject firstButtonPauseMenu;
    public GameObject firstButtonInventory;
    public GameObject firstButtonSettings;
    
    [Header("Inventory first selected buttons")]
    public GameObject firstButtonBagpack;
    public GameObject firstButtonCards;
    public GameObject firstButtonPoles;

    [Header("Dialoge first selected buttons")]
    public GameObject firstSelectedButtonDialoge;
    
    public int currentPanel = 1;
    private bool gamePaused = false;
    private bool inventoryActive = false;
    
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

    void CloseWholeUI()
    {
        canvasPauseMenu.SetActive(false);
        canvasInventory.SetActive(false);
        canvasDialoge.SetActive(false);
        panelBackpack.SetActive(false);
        panelCards.SetActive(false);
        panelPoles.SetActive(false);

        gamePaused = false;
        inventoryActive = false;
        EventSystem.current.SetSelectedGameObject(firstButtonPauseMenu);
    }
    
    #region open/close Pausemenu
    void Pause()
    {
        canvasPauseMenu.SetActive(true);
        gamePaused = true;
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        
        canvasPauseMenu.SetActive(false);
        canvasInventory.SetActive(false);
        canvasDialoge.SetActive(false);
        gamePaused = false;
        Time.timeScale = 1f;
        EventSystem.current.SetSelectedGameObject(firstButtonPauseMenu);
    }
    #endregion

    #region openInventory

    public void openInventory()
    {
        canvasPauseMenu.SetActive(false);
        canvasInventory.SetActive(true);
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

    #region L1/R1 Navigation System 

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
                panelCards.SetActive(false);
                panelPoles.SetActive(false);
                EventSystem.current.SetSelectedGameObject(firstButtonBagpack);
                break;
            case 2:
                panelBackpack.SetActive(false);
                panelCards.SetActive(true);
                panelPoles.SetActive(false);
                EventSystem.current.SetSelectedGameObject(firstButtonCards);
                break;
            case 3:
                panelBackpack.SetActive(false);
                panelCards.SetActive(false);
                panelPoles.SetActive(true);
                EventSystem.current.SetSelectedGameObject(firstButtonPoles);
                break;

        }

    }
    #endregion
}
    


