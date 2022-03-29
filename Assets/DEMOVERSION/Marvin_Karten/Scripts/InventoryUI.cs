using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] GameObject cardPage1;
    [SerializeField] GameObject cardPage2;
    [SerializeField] GameObject cardPage3;
    [SerializeField] CardSlotUI cardSlotUIPrefab;

    int index = 0;
    int maxCardsOnPage = 12;
    cardPage activePage;
    enum cardPage
    {
        Page1,
        Page2,
        Page3
    }

    InventoryTest inventory;
    private void Awake()
    {
        inventory = InventoryTest.GetInventory();
    }

    private void Start()
    {
        activePage = cardPage.Page1;
        UpdateCardList1();
        //UpdateCardList2();
    }

    void UpdateCardList1()
    {
        
        //Clear all existing items
        foreach (Transform child in cardPage1.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in cardPage2.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in cardPage3.transform)
        {
            Destroy(child.gameObject);
        }

        //foreach (var cardSlot in inventory.Slots)
        //{

        //    if (activePage == cardPage.Page1)
        //    {
        //        var slotUIobj = Instantiate(cardSlotUIPrefab, cardPage1.transform);
        //        print("Spawned " + (index - 1) + " on " + activePage);
        //        slotUIobj.SetData(cardSlot);
        //        if (index < (maxCardsOnPage + 1))
        //        {
        //            index++;
        //            print(activePage + " set index to: " + index);
        //        }
        //        if(index > maxCardsOnPage)
        //        {
        //            activePage = cardPage.Page2;
        //            print("Set 2" + activePage);
        //        }
        //    }

        //    if (activePage == cardPage.Page2)
        //    {
        //        var slotUIobj = Instantiate(cardSlotUIPrefab, cardPage2.transform);
        //        print("Spawned " + (index - 1) + " on " + activePage);
        //        slotUIobj.SetData(cardSlot);
        //        if (index <+ 2 * (maxCardsOnPage + 1))
        //        {
        //            index++;
        //            print(activePage + " set index to: " + index);
        //        }
        //        if (index > 2 * maxCardsOnPage)
        //        {
        //            activePage = cardPage.Page3;
        //            print("Set 3" + activePage);
        //        }
        //    }
        //}

        foreach (var cardSlot in inventory.Slots)
        {
            index++;
            if (index <= maxCardsOnPage)
            {
                activePage = cardPage.Page1;
            }
            else if (index > maxCardsOnPage && index <= (2*maxCardsOnPage))
            {
                activePage = cardPage.Page2;
            }
            else
            {
                activePage = cardPage.Page3;
            }
            CardSlotUI slotUIobj;
            if (activePage == cardPage.Page1)
            {
                slotUIobj = Instantiate(cardSlotUIPrefab, cardPage1.transform);
                slotUIobj.SetData(cardSlot);
            }
            else if (activePage == cardPage.Page2)
            {
                slotUIobj = Instantiate(cardSlotUIPrefab, cardPage2.transform);
                slotUIobj.SetData(cardSlot);
            }
            else if (activePage == cardPage.Page3)
            {
                slotUIobj = Instantiate(cardSlotUIPrefab, cardPage3.transform);
                slotUIobj.SetData(cardSlot);
            }
            
        }

    }
}
