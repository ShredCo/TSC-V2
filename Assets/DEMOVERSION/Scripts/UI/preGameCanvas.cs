using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class preGameCanvas : MonoBehaviour
{
    [Header("Canvas")]
    public GameObject preCanvas;
    public GameObject mainCanvas;

    [Header("Buttons")]
    public GameObject startButton;
    public GameObject singleplayerButton;

    public void goToMainCanvas()
    {
        preCanvas.SetActive(false);
        mainCanvas.SetActive(true);

        // clear selected button
        EventSystem.current.SetSelectedGameObject(null);
        // set a new selected object
        EventSystem.current.SetSelectedGameObject(singleplayerButton);
    }

}
