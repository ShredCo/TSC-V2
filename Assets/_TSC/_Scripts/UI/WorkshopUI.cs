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
        if(Inventory.PlayerDefaultCardLineUp[0] != null)
            SliderPoleHealthMain.value = Inventory.PlayerDefaultCardLineUp[0].Condition / Inventory.PlayerDefaultCardLineUp[0].MaxCondition;
        if (Inventory.PlayerDefaultCardLineUp[1] != null)
            SliderPoleHealthCrew1.value = Inventory.PlayerDefaultCardLineUp[1].Condition / Inventory.PlayerDefaultCardLineUp[1].MaxCondition;
        if (Inventory.PlayerDefaultCardLineUp[2] != null)
            SliderPoleHealthCrew2.value = Inventory.PlayerDefaultCardLineUp[2].Condition / Inventory.PlayerDefaultCardLineUp[2].MaxCondition;
        if (Inventory.PlayerDefaultCardLineUp[3] != null)
            SliderPoleHealthCrew3.value = Inventory.PlayerDefaultCardLineUp[3].Condition / Inventory.PlayerDefaultCardLineUp[3].MaxCondition;
    }
}
