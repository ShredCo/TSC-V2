using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class WorkshopUI : MonoBehaviour
{
    [Header("Canvas")]
    public GameObject Canvas_WorkshopUI;

    [Header("Buttons")] 
    public GameObject firstSelected_MainPole;


    public void OpenWorkshopUI()
    {
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
}
