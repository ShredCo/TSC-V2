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
    public static Player Instance;
    
    // gives the player an inventory
    public InventoryObject Inventory;
    
    public DialogueState DialogueState;
    [SerializeField] public GameObject pickedUpMoneyTextGameObject;
    [SerializeField] public GameObject pickedUpWoodTextGameObject;
    [SerializeField] public Text textPickedUpMoney;
    [SerializeField] public Text textPickedUpWood;
    
    private Rigidbody rb;
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    
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
                        textPickedUpMoney.text = "+ " + item.item.MoneyValue.ToString();
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
                            textPickedUpWood.text = "+ " + item.item.ResourceValue.ToString();
                            StartCoroutine(PickUpWood());
                            
                            // Sets the wood object inactive for a certain time
                            StartCoroutine(HarvestWood(other.gameObject));
                            PickUpSoundeffects.Instance.WoodSound();
                        }
                        break;
                }
            }
        
            if (item.defaultCard)
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

    private void Update()
    {
        // TODO: Only for testing purposes
        var gamepad = Gamepad.current;
        if (gamepad.dpad.up.wasPressedThisFrame)
        {
            Inventory.Save();
        }
        if (gamepad.dpad.down.wasPressedThisFrame)
        {
            Inventory.Load();
        }
    }
   
    // Clears the inventory 
    private void OnApplicationQuit()
    {
        Inventory.ItemContainer.Clear();
    }
    
    IEnumerator PickUpMoney()
    {
        pickedUpMoneyTextGameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        pickedUpMoneyTextGameObject.SetActive(false);
    }
    
    IEnumerator PickUpWood()
    {
        pickedUpWoodTextGameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        pickedUpWoodTextGameObject.SetActive(false);
    }
    
    IEnumerator HarvestWood(GameObject wood)
        {
            wood.SetActive(false);
            yield return new WaitForSeconds(1500f);
            wood.SetActive(true);
        }
}