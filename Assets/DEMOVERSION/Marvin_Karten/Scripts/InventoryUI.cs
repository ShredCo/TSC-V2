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
    int maxCardsOnPage = 4;
    cardPage activePage;
    enum cardPage
    {
        Page1,
        Page2,
        Page3
    }

    public InventoryObject inventory;

    private void Start()
    {
        activePage = cardPage.Page1;
        UpdateCardList1();
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

        foreach (var cardSlot in inventory.DefaultCardContainer)
        {
            // if the max amount of cards is spawned on one page, switch enum "activePage" to next page.
            index++;
            if (index <= maxCardsOnPage)
            {
                activePage = cardPage.Page1;
            }
            else if (index > maxCardsOnPage && index <= (2 * maxCardsOnPage))
            {
                activePage = cardPage.Page2;
            }
            else
            {
                activePage = cardPage.Page3;
            }

            // Spawn cards in inventory pages depending on enum "activePage"
            CardSlotUI slotUIobj;
            switch (activePage)
            {
                case cardPage.Page1:
                    slotUIobj = Instantiate(cardSlotUIPrefab, cardPage1.transform);
                    slotUIobj.SetData(cardSlot);
                    slotUIobj.transform.localScale = new Vector3(0.6f, 0.6f, 1);
                    break;
                case cardPage.Page2:
                    slotUIobj = Instantiate(cardSlotUIPrefab, cardPage2.transform);
                    slotUIobj.SetData(cardSlot);
                    slotUIobj.transform.localScale = new Vector3(0.6f, 0.6f, 1);
                    break;
                case cardPage.Page3:
                    slotUIobj = Instantiate(cardSlotUIPrefab, cardPage3.transform);
                    slotUIobj.SetData(cardSlot);
                    slotUIobj.transform.localScale = new Vector3(0.6f, 0.6f, 1);
                    break;
                default:
                    break;
            }
        }

    }
}
