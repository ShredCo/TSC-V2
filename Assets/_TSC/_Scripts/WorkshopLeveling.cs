using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkshopLeveling : MonoBehaviour
{
    public int UpgradeWoodCost = 15;
    public int UpgradeMoneyCost = 200;

    public int RepairWoodCost = 5;

    public GameObject TextNotEnoughMoney;
    public GameObject TextNotEnoughWood;

    public InventoryObject inventory;

    [Header("Spawnpoints")]
    public GameObject MainPoleCardObject;
    public GameObject Crew1PoleCardObject;
    public GameObject Crew2PoleCardObject;
    public GameObject Crew3PoleCardObject;

    public ISlotDefaultCard SelectedCard;
    #region Upgrade functions
    public void UpgradeMainCard()
    {
        if (inventory.PlayerDefaultCardLineUp[0].IsUpgradable) // check if the card can be upgraded
        {
            if (inventory.Wood >= UpgradeWoodCost && inventory.Money >= UpgradeMoneyCost) // check if player has enough recources
            {
                LineUpController.ActivePole = 0; // set the active pole, so that the line up knows where to put the upgraded card
                foreach (ISlotDefaultCard card in inventory.DefaultCardContainer) // loop through the inventory to replace the card with the upgraded card
                {
                    if (inventory.PlayerDefaultCardLineUp[0] == card.DefaultCard)
                    {
                        card.DefaultCard = card.DefaultCard.NextLevelCard;
                        inventory.AddDefaultCardToLineUp(card.DefaultCard);
                        InventoryUI.Instance.UpdateLineUpCards();
                        break;
                    }
                }
                inventory.Wood -= UpgradeWoodCost;
                inventory.Money -= UpgradeMoneyCost;
            }
            else
            {
                if (inventory.Wood < UpgradeWoodCost)
                {
                    Debug.Log("No enough wood, stranger");
                    StartCoroutine(NotEnoughWood());
                }
                if (inventory.Money < UpgradeMoneyCost)
                {
                    Debug.Log("No enough cash, stranger");
                    StartCoroutine(NotEnoughMoney());
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
        if (inventory.PlayerDefaultCardLineUp[1].IsUpgradable)
        {
            if (inventory.Wood >= UpgradeWoodCost && inventory.Money >= UpgradeMoneyCost)
            {
                LineUpController.ActivePole = 1;
                foreach (ISlotDefaultCard card in inventory.DefaultCardContainer)
                {
                    if (inventory.PlayerDefaultCardLineUp[1] == card.DefaultCard)
                    {
                        card.DefaultCard = card.DefaultCard.NextLevelCard;
                        inventory.AddDefaultCardToLineUp(card.DefaultCard);
                        InventoryUI.Instance.UpdateLineUpCards();
                        break;
                    }
                }
                inventory.Wood -= UpgradeWoodCost;
                inventory.Money -= UpgradeMoneyCost;
            }
            else
            {
                if (inventory.Wood < UpgradeWoodCost)
                {
                    Debug.Log("No enough wood, stranger");
                    StartCoroutine(NotEnoughWood());
                }
                if (inventory.Money < UpgradeMoneyCost)
                {
                    Debug.Log("No enough cash, stranger");
                    StartCoroutine(NotEnoughMoney());
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
        if (inventory.PlayerDefaultCardLineUp[2].IsUpgradable)
        {
            if (inventory.Wood >= UpgradeWoodCost && inventory.Money >= UpgradeMoneyCost)
            {
                LineUpController.ActivePole = 2;
                foreach (ISlotDefaultCard card in inventory.DefaultCardContainer)
                {
                    if (inventory.PlayerDefaultCardLineUp[2] == card.DefaultCard)
                    {
                        card.DefaultCard = card.DefaultCard.NextLevelCard;
                        inventory.AddDefaultCardToLineUp(card.DefaultCard);
                        InventoryUI.Instance.UpdateLineUpCards();
                        break;
                    }
                }
                inventory.Wood -= UpgradeWoodCost;
                inventory.Money -= UpgradeMoneyCost;
            }
            else
            {
                if (inventory.Wood < UpgradeWoodCost)
                {
                    Debug.Log("No enough wood, stranger");
                    StartCoroutine(NotEnoughWood());
                }
                if (inventory.Money < UpgradeMoneyCost)
                {
                    Debug.Log("No enough cash, stranger");
                    StartCoroutine(NotEnoughMoney());
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
        if (inventory.PlayerDefaultCardLineUp[3].IsUpgradable)
        {
            if (inventory.Wood >= UpgradeWoodCost && inventory.Money >= UpgradeMoneyCost)
            {
                LineUpController.ActivePole = 3;
                foreach (ISlotDefaultCard card in inventory.DefaultCardContainer)
                {
                    if (inventory.PlayerDefaultCardLineUp[3] == card.DefaultCard)
                    {
                        card.DefaultCard = card.DefaultCard.NextLevelCard;
                        inventory.AddDefaultCardToLineUp(card.DefaultCard);
                        InventoryUI.Instance.UpdateLineUpCards();
                        break;
                    }
                }
                inventory.Wood -= UpgradeWoodCost;
                inventory.Money -= UpgradeMoneyCost;
            }
            else
            {
                if (inventory.Wood < UpgradeWoodCost)
                {
                    Debug.Log("No enough wood, stranger");
                    StartCoroutine(NotEnoughWood());
                }
                if (inventory.Money < UpgradeMoneyCost)
                {
                    Debug.Log("No enough cash, stranger");
                    StartCoroutine(NotEnoughMoney());
                }
            }
        }
        else
        {
            Debug.Log("Card not upgradable");
        }
    }
    #endregion

    #region Repair functions
    public void RepairMainCard()
    {
        if (inventory.PlayerDefaultCardLineUp[0].Condition < inventory.PlayerDefaultCardLineUp[0].MaxCondition)
        {
            if (inventory.Wood >= RepairWoodCost)
            {
                inventory.PlayerDefaultCardLineUp[0].Condition = inventory.PlayerDefaultCardLineUp[0].MaxCondition;
                inventory.Wood -= RepairWoodCost;
                Debug.Log("Card repaired");
            }
            else
            {
                Debug.Log("No enough wood, stranger");
                StartCoroutine(NotEnoughWood());
            }
        }
        else
        {
            Debug.Log("Card is full HP, stranger");
        }
    }

    public void RepairCrew1Card()
    {
        if (inventory.PlayerDefaultCardLineUp[1].Condition < inventory.PlayerDefaultCardLineUp[1].MaxCondition)
        {
            if (inventory.Wood >= RepairWoodCost)
            {
                inventory.PlayerDefaultCardLineUp[1].Condition = inventory.PlayerDefaultCardLineUp[1].MaxCondition;
                inventory.Wood -= RepairWoodCost;
                Debug.Log("Card repaired");
            }
            else
            {
                Debug.Log("No enough wood, stranger");
                StartCoroutine(NotEnoughWood());
            }
        }
        else
        {
            Debug.Log("Card is full HP, stranger");
        }
    }

    public void RepairCrew2Card()
    {
        if (inventory.PlayerDefaultCardLineUp[2].Condition < inventory.PlayerDefaultCardLineUp[2].MaxCondition)
        {
            if (inventory.Wood >= RepairWoodCost)
            {
                inventory.PlayerDefaultCardLineUp[2].Condition = inventory.PlayerDefaultCardLineUp[2].MaxCondition;
                inventory.Wood -= RepairWoodCost;
                Debug.Log("Card repaired");
            }
            else
            {
                Debug.Log("No enough wood, stranger");
                StartCoroutine(NotEnoughWood());
            }
        }
        else
        {
            Debug.Log("Card is full HP, stranger");
        }
    }

    public void RepairCrew3Card()
    {
        if (inventory.PlayerDefaultCardLineUp[3].Condition < inventory.PlayerDefaultCardLineUp[3].MaxCondition)
        {
            if (inventory.Wood >= RepairWoodCost)
            {
                inventory.PlayerDefaultCardLineUp[3].Condition = inventory.PlayerDefaultCardLineUp[3].MaxCondition;
                inventory.Wood -= RepairWoodCost;
                Debug.Log("Card repaired");
            }
            else
            {
                Debug.Log("No enough wood, stranger");
                StartCoroutine(NotEnoughWood());
            }
        }
        else
        {
            Debug.Log("Card is full HP, stranger");
        }
    }
    #endregion

    #region Text when player doesnt have enough wood/money
    IEnumerator NotEnoughMoney()
    {
        if (!TextNotEnoughMoney.activeSelf)
        {
            TextNotEnoughMoney.SetActive(true);
            yield return new WaitForSeconds(1.5f);
            TextNotEnoughMoney.SetActive(false);
        }
    }
    IEnumerator NotEnoughWood()
    {
        if (!TextNotEnoughWood.activeSelf)
        {
            TextNotEnoughWood.SetActive(true);
            yield return new WaitForSeconds(1.5f);
            TextNotEnoughWood.SetActive(false);
        }
    }
    #endregion
}
