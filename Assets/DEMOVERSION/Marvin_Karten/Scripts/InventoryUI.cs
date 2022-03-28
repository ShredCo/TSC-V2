using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] GameObject cardListContent;
    [SerializeField] CardSlotUI cardSlotUIPrefab;

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
        foreach (Transform child in cardListContent.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (var cardSlot in inventory.Slots)
        {
            var slotUIobj = Instantiate(cardSlotUIPrefab, cardListContent.transform);
            slotUIobj.SetData(cardSlot);
        }
    }

}
