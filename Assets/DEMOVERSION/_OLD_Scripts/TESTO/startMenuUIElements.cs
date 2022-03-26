using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class startMenuUIElements : MonoBehaviour
{
    public static startMenuUIElements instance;

    [Header("Scripts")]
    public SwitchMainMenuUI switchMainMenuUI;

    [Header("Inventory Panels")]
    public GameObject panelInventory;
    public GameObject panelLineup;

    [Header("Inventory Panels")]
    public GameObject buttonOpenLineup;
    public GameObject gobackFromLineup;


    // Start is called before the first frame update
    void Start()
    {
        if( instance == null)
        {
            instance = this;
        }

        InventoryUIManager.instance.UpdateLineUpTexts();
    }
    public void OpenLineUpPanel()
    {
        panelInventory.SetActive(false);
        panelLineup.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(gobackFromLineup);
        switchMainMenuUI.GetComponent<SwitchMainMenuUI>().enabled = false;
    }

    public void CloseLineUpPanel()
    {
        panelLineup.SetActive(false);
        panelInventory.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(buttonOpenLineup);
        switchMainMenuUI.GetComponent<SwitchMainMenuUI>().enabled = true;
    }
}
