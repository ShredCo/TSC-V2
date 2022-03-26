using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] GameObject cardList;
    [SerializeField] CardSlotUI cardSlotUI;

    InventoryTest inventory;
    private void Awake()
    {
        inventory = InventoryTest.GetInventory();
    }

    private void Start()
    {
        UpdateCardList();
    }

    void UpdateCardList()
    {
        //Clear all existing items
        foreach (Transform child in cardList.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (var cardSlot in inventory.Slots)
        {
            var slotUIobj = Instantiate(cardSlotUI, cardList.transform);
            slotUIobj.SetData(cardSlot);
        }
    }

}
