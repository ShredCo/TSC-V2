using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UserInterfaceOverworld : MonoBehaviour
{
    public GameObject canvasPauseMenu;
    public GameObject canvasInventory;

    private bool gamePaused = false;
    private bool inventoryActive = false;
    
    [Header("Pausemenu first selected buttons")]
    public GameObject firstButtonPauseMenu;
    public GameObject firstButtonInventory;
    public GameObject firstButtonSettings;



    [Header("Inventory Panels")]
    public GameObject panelBackpack;
    public GameObject panelCards;
    public GameObject panelPoles;

    public int currentPanel = 1;

    [Header("Inventory first selected buttons")]
    public GameObject firstButtonBagpack;
    public GameObject firstButtonCards;
    public GameObject firstButtonPoles;

    [Header("DialogeSystem")] 
    public GameObject canvasDialoge;

    public GameObject firstSelectedButtonDialoge;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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

        #region Inventory

        if (inventoryActive == true)
        {
            if(gamepad.rightShoulder.wasPressedThisFrame || gamepad.leftShoulder.wasPressedThisFrame)
            {

            SwitchInventoryPanels();
            }
        }

        #region closeInventory
        if (inventoryActive == true && gamepad.buttonEast.wasPressedThisFrame)
        {
            canvasPauseMenu.SetActive(true);
            canvasInventory.SetActive(false);
            inventoryActive = false;

            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(firstButtonPauseMenu);
        }
        #endregion

        #endregion
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
        gamePaused = false;
        Time.timeScale = 1f;
    }
    #endregion

    #region openInventory

    public void openInventory()
    {
        canvasPauseMenu.SetActive(false);
        canvasInventory.SetActive(true);
        inventoryActive = true;

        EventSystem.current.SetSelectedGameObject(null);
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
    


