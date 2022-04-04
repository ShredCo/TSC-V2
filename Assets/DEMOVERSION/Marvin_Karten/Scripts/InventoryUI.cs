using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI Instance;

    [SerializeField] GameObject cardPage1;
    [SerializeField] GameObject cardPage2;
    [SerializeField] GameObject cardPage3;
    [SerializeField] CardSlotUI cardSlotUIPrefab;

    [SerializeField] GameObject buttonMainPole;
    [SerializeField] GameObject buttonCrewPole1;
    [SerializeField] GameObject buttonCrewPole2;
    [SerializeField] GameObject buttonCrewPole3;
    [SerializeField] CardSlotUI poleSelectedCardPrefab;

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
        Instance = this;
        activePage = cardPage.Page1;
        UpdateCardList1();
        UpdateSelectedPoleCards();
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
                    if (index == 1)
                    {
                        FirstButtonCardSelection.FirstButtonLineUpCardPage1 = slotUIobj.gameObject;
                    }
                    break;
                case cardPage.Page2:
                    slotUIobj = Instantiate(cardSlotUIPrefab, cardPage2.transform);
                    slotUIobj.SetData(cardSlot);
                    if (index == 5)
                    {
                        FirstButtonCardSelection.FirstButtonLineUpCardPage2 = slotUIobj.gameObject;
                    }
                    break;
                case cardPage.Page3:
                    slotUIobj = Instantiate(cardSlotUIPrefab, cardPage3.transform);
                    slotUIobj.SetData(cardSlot);
                    if (index == 9)
                    {
                        FirstButtonCardSelection.FirstButtonLineUpCardPage3 = slotUIobj.gameObject;
                    }
                    break;
                default:
                    break;
            }
            
        }

    }

    public void UpdateSelectedPoleCards()
    {
        foreach (Transform child in buttonMainPole.transform)
        {
            if (child.CompareTag("SelectedPoleCard"))
            {
                Destroy(child.gameObject);
            }
        }
        foreach (Transform child in buttonCrewPole1.transform)
        {
            if (child.CompareTag("SelectedPoleCard"))
            {
                Destroy(child.gameObject);
            }
        }
        foreach (Transform child in buttonCrewPole2.transform)
        {
            if (child.CompareTag("SelectedPoleCard"))
            {
                Destroy(child.gameObject);
            }
        }
        foreach (Transform child in buttonCrewPole3.transform)
        {
            if (child.CompareTag("SelectedPoleCard"))
            {
                Destroy(child.gameObject);
            }
        }

        CardSlotUI slotUIobj;

        slotUIobj = Instantiate(poleSelectedCardPrefab, buttonMainPole.transform);
        slotUIobj.SetData(LineUpController.PoleSlotCardMain);

        slotUIobj = Instantiate(poleSelectedCardPrefab, buttonCrewPole1.transform);
        if (LineUpController.PoleSlotCardCrew1 != null)
        {
            slotUIobj.SetData(LineUpController.PoleSlotCardCrew1);
        }

        slotUIobj = Instantiate(poleSelectedCardPrefab, buttonCrewPole2.transform);
        if (LineUpController.PoleSlotCardCrew2 != null)
        {
            slotUIobj.SetData(LineUpController.PoleSlotCardCrew2);
        }

        slotUIobj = Instantiate(poleSelectedCardPrefab, buttonCrewPole3.transform);
        if (LineUpController.PoleSlotCardCrew3 != null)
        {
            slotUIobj.SetData(LineUpController.PoleSlotCardCrew3);
        }
    }
}
