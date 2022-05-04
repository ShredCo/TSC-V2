using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public enum DialogueState
{
    Avaiable,
    NotAvaiable,
    Talking
}
public class Player : MonoBehaviour
{
    #region Singleton
    public static Player Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    #endregion
    
    // gives the player an inventory Scriptable Object
    public InventoryObject Inventory;
    
    public DialogueState DialogueState;
    
    // Player HUD
    public GameObject PickedUpMoneyTextGameObject;
    public GameObject PickedUpWoodTextGameObject;
    public Text TextPickedUpMoney;
    public Text TextPickedUpWood;
    
    private Rigidbody rb;

    
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Item>())
        {
            var item = other.GetComponent<Item>();

            if (item.item)
            {
                switch (item.item.Type)
                {
                    // Checks which type the new item is and adds it to its inventory
                    case ItemType.Money:
                        // Adds money to the inventory
                        Inventory.AddMoney(item.item.MoneyValue);
                    
                        // Displays the picked up amount in the UI
                        TextPickedUpMoney.text = "+ " + item.item.MoneyValue.ToString();
                        StartCoroutine(PickUpMoney());
                    
                        other.gameObject.SetActive(false);
                        PickUpSoundeffects.Instance.MoneySound();
                        break;
                    case ItemType.Resource:
                        var gamepad = Gamepad.current;
                        if (gamepad.buttonWest.wasPressedThisFrame)
                        {
                            // Adds the resource to the inventory
                            Inventory.AddResource(item.item.ResourceValue);
                            
                            // Displays the picked up amount in the UI
                            TextPickedUpWood.text = "+ " + item.item.ResourceValue.ToString();
                            StartCoroutine(PickUpWood());
                            
                            // Sets the wood object inactive for a certain time
                            StartCoroutine(HarvestWood(other.gameObject));
                            PickUpSoundeffects.Instance.WoodSound();
                        }
                        break;
                }
            }
            else if(item.defaultCard)
            {
                switch (item.defaultCard.Type)
                {
                    // Checks which type the new card is and adds it to its inventory
                    case CardType.DefaultCard:
                        Debug.Log("DefaultCard");
                        Inventory.AddDefaultCard(item.defaultCard, 1);
                        other.gameObject.SetActive(false);
                        break;
                    case CardType.SpecialCard:
                        Debug.Log("SpecialCard");
                        Inventory.AddSpecialCard(item.specialCard, 1);
                        other.gameObject.SetActive(false);
                        break;
                }
                PickUpSoundeffects.Instance.CardSound();
            }
        }
    }

    #region Item interaction -> Methods
    IEnumerator PickUpMoney()
    {
        PickedUpMoneyTextGameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        PickedUpMoneyTextGameObject.SetActive(false);
    }
    IEnumerator PickUpWood()
    {
        PickedUpWoodTextGameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        PickedUpWoodTextGameObject.SetActive(false);
    }
    IEnumerator HarvestWood(GameObject wood)
    {
        wood.SetActive(false);
        yield return new WaitForSeconds(1500f);
        wood.SetActive(true);
    }
    #endregion
}