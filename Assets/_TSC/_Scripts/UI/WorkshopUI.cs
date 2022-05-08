using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class WorkshopUI : MonoBehaviour
{
    [Header("Canvas")]
    [SerializeField] private GameObject canvasWorkshopUI;

    [Header("Buttons")] 
    [SerializeField] private GameObject firstButton;

    [SerializeField] private Slider sliderPoleHealthMain;
    [SerializeField] private Slider sliderPoleHealthCrew1;
    [SerializeField] private Slider sliderPoleHealthCrew2;
    [SerializeField] private Slider sliderPoleHealthCrew3;

    // Repair and Upgrade Costs
    [SerializeField] private Text upgradeText;
    [SerializeField] private Text repairText;

    [SerializeField] private InventoryObject inventoryObject;

    public void OpenWorkshopUI()
    {
        // pause the game
        GameState currentGameState = GameStateManager.Instance.CurrentGameState;
        GameState newGameState = currentGameState == GameState.Gameplay
            ? GameState.Paused
            : GameState.Gameplay;
            
        GameStateManager.Instance.SetState(newGameState);
        
        canvasWorkshopUI.SetActive(true);
        EventSystem.current.SetSelectedGameObject(firstButton);
    }
    public void CloseWorkshopUI()
    {
        // unpause the game
        GameState currentGameState = GameStateManager.Instance.CurrentGameState;
        GameState newGameState = currentGameState == GameState.Gameplay
            ? GameState.Paused
            : GameState.Gameplay;
            
        GameStateManager.Instance.SetState(newGameState);
        
        // close UI
        canvasWorkshopUI.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
    }

    private void Update()
    {
        if(inventoryObject.PlayerDefaultCardLineUp[0] != null)
            sliderPoleHealthMain.value = inventoryObject.PlayerDefaultCardLineUp[0].Condition / inventoryObject.PlayerDefaultCardLineUp[0].MaxCondition;
        if (inventoryObject.PlayerDefaultCardLineUp[1] != null)
            sliderPoleHealthCrew1.value = inventoryObject.PlayerDefaultCardLineUp[1].Condition / inventoryObject.PlayerDefaultCardLineUp[1].MaxCondition;
        if (inventoryObject.PlayerDefaultCardLineUp[2] != null)
            sliderPoleHealthCrew2.value = inventoryObject.PlayerDefaultCardLineUp[2].Condition / inventoryObject.PlayerDefaultCardLineUp[2].MaxCondition;
        if (inventoryObject.PlayerDefaultCardLineUp[3] != null)
            sliderPoleHealthCrew3.value = inventoryObject.PlayerDefaultCardLineUp[3].Condition / inventoryObject.PlayerDefaultCardLineUp[3].MaxCondition;

        upgradeText.text = "Upgrade Cost\nWood: " + GetComponent<WorkshopLeveling>().UpgradeWoodCost + "\nMoney: " + GetComponent<WorkshopLeveling>().UpgradeMoneyCost;
        repairText.text = "Repair Cost\nWood: " + GetComponent<WorkshopLeveling>().RepairWoodCost;
    }
}
