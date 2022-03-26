using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SwitchMainMenuUI : MonoBehaviour
{
   
    [Header("UserInterfaces")]
    public GameObject mainBattlepassPanel;
    public GameObject mainInventoryPanel;
    public GameObject mainPlayPanel;
    public GameObject mainShopPanel;
    public GameObject mainGemsPanel;

    [Header("First Selected Buttons")]
    // Inventory UI
    public GameObject buttonOpenCharacters;
    // Play UI
    public GameObject singleplayerButton;
    // Shop UI
    public GameObject characterShopButton;
    // Gems UI
    public GameObject buy100GemsButton;

    public int currentSelectedUI = 3;

    private void Update()
    {
       UpdateCurrentUI();
       SwitchCurrentCanvas();
    }


    #region navigation Methods
    public void DeactivateAllUIs()
    {
        mainBattlepassPanel.SetActive(false);
        mainInventoryPanel.SetActive(false);
        mainPlayPanel.SetActive(false);
        mainShopPanel.SetActive(false);
        mainGemsPanel.SetActive(false);
    }

    public void ActivateBattlepassPanel()
    {
        DeactivateAllUIs();
        mainBattlepassPanel.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
    }
    public void ActivateInventoryPanel()
    {
        DeactivateAllUIs();
        mainInventoryPanel.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(buttonOpenCharacters);
    }
    public void ActivatePlayPanel()
    {
        DeactivateAllUIs();
        mainPlayPanel.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(singleplayerButton);
    }
    public void ActivateShopPanel()
    {
        DeactivateAllUIs();
        mainShopPanel.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(characterShopButton);
    }
    public void ActivateGemsPanel()
    {
        DeactivateAllUIs();
        mainGemsPanel.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(buy100GemsButton);
    }
    #endregion

    #region Gamepad switch system
    void SwitchCurrentCanvas()
    {
        var gamepad = Gamepad.current;

        if (gamepad.rightShoulder.wasPressedThisFrame)
        {
            if (currentSelectedUI < 5)
            {
                EventSystem.current.SetSelectedGameObject(null);
                currentSelectedUI += 1;

                switch(currentSelectedUI)
                {
                    case 1:
                        EventSystem.current.SetSelectedGameObject(null);
                        break;
                    case 2:
                        EventSystem.current.SetSelectedGameObject(buttonOpenCharacters);
                        break;
                    case 3:
                        EventSystem.current.SetSelectedGameObject(singleplayerButton);
                        break;
                    case 4:
                        EventSystem.current.SetSelectedGameObject(characterShopButton);
                        break;
                    case 5:
                        EventSystem.current.SetSelectedGameObject(buy100GemsButton);
                        break;

                }
            }
        }
        if (gamepad.leftShoulder.wasPressedThisFrame)
        {
            if (currentSelectedUI > 0)
            {
                EventSystem.current.SetSelectedGameObject(null);
                currentSelectedUI -= 1;

                switch (currentSelectedUI)
                {
                    case 1:
                        EventSystem.current.SetSelectedGameObject(null);
                        break;
                    case 2:
                        EventSystem.current.SetSelectedGameObject(buttonOpenCharacters);
                        break;
                    case 3:
                        EventSystem.current.SetSelectedGameObject(singleplayerButton);
                        break;
                    case 4:
                        EventSystem.current.SetSelectedGameObject(characterShopButton);
                        break;
                    case 5:
                        EventSystem.current.SetSelectedGameObject(buy100GemsButton);
                        break;

                }
            }
        }
    }

    void UpdateCurrentUI()
    {
        switch (currentSelectedUI)
        {
            case 1:
                //Battlepass
                mainBattlepassPanel.SetActive(true);
                mainInventoryPanel.SetActive(false);
                mainPlayPanel.SetActive(false);
                mainShopPanel.SetActive(false);
                mainGemsPanel.SetActive(false);

                break;
            case 2:
                //Inventory
                mainBattlepassPanel.SetActive(false);
                mainInventoryPanel.SetActive(true);
                mainPlayPanel.SetActive(false);
                mainShopPanel.SetActive(false);
                mainGemsPanel.SetActive(false);
                break;
            case 3:
                //Play
                mainBattlepassPanel.SetActive(false);
                mainInventoryPanel.SetActive(false);
                mainPlayPanel.SetActive(true);
                mainShopPanel.SetActive(false);
                mainGemsPanel.SetActive(false);
                break;
            case 4:
                //Shop
                mainBattlepassPanel.SetActive(false);
                mainInventoryPanel.SetActive(false);
                mainPlayPanel.SetActive(false);
                mainShopPanel.SetActive(true);
                mainGemsPanel.SetActive(false);
                break;
            case 5:
                //GemShop
                mainBattlepassPanel.SetActive(false);
                mainInventoryPanel.SetActive(false);
                mainPlayPanel.SetActive(false);
                mainShopPanel.SetActive(false);
                mainGemsPanel.SetActive(true);
                break;
        }
    }
    #endregion
}
