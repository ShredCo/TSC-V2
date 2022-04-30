using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class WorkshopUI : MonoBehaviour
{
    [Header("Canvas")]
    public GameObject Canvas_WorkshopUI;

    [Header("Buttons")] 
    public GameObject firstSelected_MainPole;

    public Slider SliderPoleHealthMain;
    public Slider SliderPoleHealthCrew1;
    public Slider SliderPoleHealthCrew2;
    public Slider SliderPoleHealthCrew3;

    public InventoryObject Inventory;

    public void OpenWorkshopUI()
    {
        // pause the game
        GameState currentGameState = GameStateManager.Instance.CurrentGameState;
        GameState newGameState = currentGameState == GameState.Gameplay
            ? GameState.Paused
            : GameState.Gameplay;
            
        GameStateManager.Instance.SetState(newGameState);
        
        Canvas_WorkshopUI.SetActive(true);
        EventSystem.current.SetSelectedGameObject(firstSelected_MainPole);
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
        Canvas_WorkshopUI.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
    }

    private void Update()
    {
        SliderPoleHealthMain.value = Inventory.PlayerDefaultCardLineUp[0].Health / Inventory.PlayerDefaultCardLineUp[0].MaxHealth;
        SliderPoleHealthCrew1.value = Inventory.PlayerDefaultCardLineUp[1].Health / Inventory.PlayerDefaultCardLineUp[1].MaxHealth;
        SliderPoleHealthCrew2.value = Inventory.PlayerDefaultCardLineUp[2].Health / Inventory.PlayerDefaultCardLineUp[2].MaxHealth;
        SliderPoleHealthCrew3.value = Inventory.PlayerDefaultCardLineUp[3].Health / Inventory.PlayerDefaultCardLineUp[3].MaxHealth;
    }
}
