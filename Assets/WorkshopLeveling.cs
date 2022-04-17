using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkshopLeveling : MonoBehaviour
{
    public InventoryObject inventory;

    public GameObject MainPoleCardObject;
    public ISlotDefaultCard SelectedCard;

    public void LevelMainCard()
    {
        LineUpController.ActivePole = 0;
        SelectedCard.DefaultCard = MainPoleCardObject.GetComponentInChildren<CardSlotUI>().DefaultCardSlot;
        foreach (ISlotDefaultCard card in inventory.DefaultCardContainer)
        {
            if (SelectedCard.DefaultCard == card.DefaultCard)
            {
                card.DefaultCard = card.DefaultCard.NextLevelCard;
                inventory.AddDefaultCardtoLineUp(card.DefaultCard);
                InventoryUI.Instance.UpdateLineUpCards();
            }
        }
    }
}
