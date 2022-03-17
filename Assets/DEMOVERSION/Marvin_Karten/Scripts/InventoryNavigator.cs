using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class InventoryNavigator : MonoBehaviour
{
    public GameObject buttonSelection;
    public GameObject cardCollection;
    public GameObject roster;

    void Update()
    {
        if (Gamepad.all[0].circleButton.isPressed && !buttonSelection && !cardCollection && !roster)
        {
            Continue();
        }
        else if (Gamepad.all[0].circleButton.isPressed && cardCollection)
        {
            CloseCardCollection();
        }
        else if (Gamepad.all[0].circleButton.isPressed && roster)
        {
            CloseRoster();
        }
    }

    public void Continue()
    {
        buttonSelection.SetActive(false);
        cardCollection.SetActive(false);
        roster.SetActive(false);
    }

    public void OpenCardCollection()
    {
        cardCollection.SetActive(true);
    }
    public void CloseCardCollection()
    {
        cardCollection.SetActive(false);
    }

    public void OpenRoster()
    {
        cardCollection.SetActive(true);
    }
    public void CloseRoster()
    {
        cardCollection.SetActive(false);
    }
}
