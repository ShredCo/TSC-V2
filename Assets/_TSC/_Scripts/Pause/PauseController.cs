using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PauseController : MonoBehaviour
{
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    GameState currentGameState = GameStateManager.Instance.CurrentGameState;

    private void Update()
    {
        var gamepad = Gamepad.current;
        if (gamepad.startButton.wasPressedThisFrame && currentGameState == GameState.Gameplay)
        {
            GameState newGameState = currentGameState == GameState.Gameplay
                ? GameState.Paused
                : GameState.Gameplay;
            
            GameStateManager.Instance.SetState(newGameState);
        }
    }
}
