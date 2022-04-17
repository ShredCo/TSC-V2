using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkshopLeveling : MonoBehaviour
{
    public int UpgradeWoodCost = 5;
    public int UpgradeMoneyCost = 1000;

    public InventoryObject inventory;

    [Header("Spawnpoints")]
    public GameObject MainPoleCardObject;
    public GameObject Crew1PoleCardObject;
    public GameObject Crew2PoleCardObject;
    public GameObject Crew3PoleCardObject;

    public ISlotDefaultCard SelectedCard;

    public void UpgradeMainCard()
    {
        // Get the card you want to upgrade with GetComponentInChildren
        SelectedCard.DefaultCard = MainPoleCardObject.GetComponentInChildren<CardSlotUI>().DefaultCardSlot;
        if (SelectedCard.DefaultCard.IsUpgradable) // check if the card can be upgraded
        {
            if (inventory.wood >= UpgradeWoodCost && inventory.money >= UpgradeMoneyCost) // check if player has enough recources
            {
                LineUpController.ActivePole = 0; // set the active pole, so that the line up knows where to put the upgraded card
                foreach (ISlotDefaultCard card in inventory.DefaultCardContainer) // loop through the inventory to replace the card with the upgraded card
                {
                    if (SelectedCard.DefaultCard == card.DefaultCard)
                    {
                        card.DefaultCard = card.DefaultCard.NextLevelCard;
                        inventory.AddDefaultCardtoLineUp(card.DefaultCard);
                        InventoryUI.Instance.UpdateLineUpCards();
                    }
                }
                inventory.wood -= UpgradeWoodCost;
                inventory.money -= UpgradeMoneyCost;
            }
            else
            {
                if (inventory.wood < UpgradeWoodCost)
                {
                    Debug.Log("No enough wood, stranger");
                }
                if (inventory.money < UpgradeMoneyCost)
                {
                    Debug.Log("No enough cash, stranger");
                }
            }
        }
        else
        {
            Debug.Log("Card not upgradable");
        }
    }

    public void UpgradeCrew1Card()
    {
        SelectedCard.DefaultCard = Crew1PoleCardObject.GetComponentInChildren<CardSlotUI>().DefaultCardSlot;
        if (SelectedCard.DefaultCard.IsUpgradable)
        {
            if (inventory.wood >= UpgradeWoodCost && inventory.money >= UpgradeMoneyCost)
            {
                LineUpController.ActivePole = 1;
                foreach (ISlotDefaultCard card in inventory.DefaultCardContainer)
                {
                    if (SelectedCard.DefaultCard == card.DefaultCard)
                    {
                        card.DefaultCard = card.DefaultCard.NextLevelCard;
                        inventory.AddDefaultCardtoLineUp(card.DefaultCard);
                        InventoryUI.Instance.UpdateLineUpCards();
                    }
                }
                inventory.wood -= UpgradeWoodCost;
                inventory.money -= UpgradeMoneyCost;
            }
            else
            {
                if (inventory.wood < UpgradeWoodCost)
                {
                    Debug.Log("No enough wood, stranger");
                }
                if (inventory.money < UpgradeMoneyCost)
                {
                    Debug.Log("No enough cash, stranger");
                }
            }
        }
        else
        {
            Debug.Log("Card not upgradable");
        }
    }

    public void UpgradeCrew2Card()
    {
        SelectedCard.DefaultCard = Crew2PoleCardObject.GetComponentInChildren<CardSlotUI>().DefaultCardSlot;
        if (SelectedCard.DefaultCard.IsUpgradable)
        {
            if (inventory.wood >= UpgradeWoodCost && inventory.money >= UpgradeMoneyCost)
            {
                LineUpController.ActivePole = 2;
                foreach (ISlotDefaultCard card in inventory.DefaultCardContainer)
                {
                    if (SelectedCard.DefaultCard == card.DefaultCard)
                    {
                        card.DefaultCard = card.DefaultCard.NextLevelCard;
                        inventory.AddDefaultCardtoLineUp(card.DefaultCard);
                        InventoryUI.Instance.UpdateLineUpCards();
                    }
                }
                inventory.wood -= UpgradeWoodCost;
                inventory.money -= UpgradeMoneyCost;
            }
            else
            {
                if (inventory.wood < UpgradeWoodCost)
                {
                    Debug.Log("No enough wood, stranger");
                }
                if (inventory.money < UpgradeMoneyCost)
                {
                    Debug.Log("No enough cash, stranger");
                }
            }
        }
        else
        {
            Debug.Log("Card not upgradable");
        }
    }

    public void UpgradeCrew3Card()
    {
        SelectedCard.DefaultCard = Crew3PoleCardObject.GetComponentInChildren<CardSlotUI>().DefaultCardSlot;
        if (SelectedCard.DefaultCard.IsUpgradable)
        {
            if (inventory.wood >= UpgradeWoodCost && inventory.money >= UpgradeMoneyCost)
            {
                LineUpController.ActivePole = 3;
                foreach (ISlotDefaultCard card in inventory.DefaultCardContainer)
                {
                    if (SelectedCard.DefaultCard == card.DefaultCard)
                    {
                        card.DefaultCard = card.DefaultCard.NextLevelCard;
                        inventory.AddDefaultCardtoLineUp(card.DefaultCard);
                        InventoryUI.Instance.UpdateLineUpCards();
                    }
                }
                inventory.wood -= UpgradeWoodCost;
                inventory.money -= UpgradeMoneyCost;
            }
            else
            {
                if (inventory.wood < UpgradeWoodCost)
                {
                    Debug.Log("No enough wood, stranger");
                }
                if (inventory.money < UpgradeMoneyCost)
                {
                    Debug.Log("No enough cash, stranger");
                }
            }
        }
        else
        {
            Debug.Log("Card not upgradable");
        }
    }
}
