using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;
using UnityEngine.EventSystems;

[CreateAssetMenu(fileName = "new inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject, ISerializationCallbackReceiver
{
    [Header("Currency")]
    public int Money;

    [Header("Resources")] 
    public int Wood;

    [Header("References")]
    public string SavePath;
    
    ItemDatabaseObject database;
    
    #region Inventory -> Containers
    // creates a List with slots for the inventory
    // adds an item to it
    public List<ISlotItem> ItemContainer = new List<ISlotItem>();
    public List<ISlotDefaultCard> DefaultCardContainer = new List<ISlotDefaultCard>();
    public List<ISlotSpecialCard> AbilityCardContainer = new List<ISlotSpecialCard>();
    #endregion
    
    #region Line up
    // arrays to store the player line up
    public DefaultCardObject[] PlayerDefaultCardLineUp = new DefaultCardObject[4];
    public SpecialCardObject[] PlayerAbilityCardLineUp = new SpecialCardObject[4];

    // methods to add cards to line up
    public void AddCardtoLineUp()
    {
        LineUpController.ActiveCard = EventSystem.current.currentSelectedGameObject.GetComponent<CardSlotUI>(); // Get a reference to the selected Button (Card)
        if (LineUpController.CardType)
        {
            int i = 0;
            foreach (DefaultCardObject card in PlayerDefaultCardLineUp)
            {
                if (card == LineUpController.ActiveCard.DefaultCardSlot)
                {
                    PlayerDefaultCardLineUp[i] = null;
                }
                i++;
            }
            PlayerDefaultCardLineUp[LineUpController.ActivePole]=LineUpController.ActiveCard.DefaultCardSlot; // Save the selected Card to the local Line UpArray(to display in inv)
            InventoryUI.Instance.UpdateLineUpCards();
            UISoundeffects.Instance.CardSelectSound();
        }
        else
        {
            int j = 0;
            foreach (SpecialCardObject card in PlayerAbilityCardLineUp)
            {
                if (card == LineUpController.ActiveCard.SpecialCardSlot)
                {
                    PlayerAbilityCardLineUp[j] = null;
                }
                j++;
            }
            PlayerAbilityCardLineUp[LineUpController.ActivePole] = LineUpController.ActiveCard.SpecialCardSlot;
            InventoryUI.Instance.UpdateLineUpCards();
            UISoundeffects.Instance.CardSelectSound();
        }
    }  
    public void AddDefaultCardToLineUp(DefaultCardObject defaultCard)
    {
        PlayerDefaultCardLineUp[LineUpController.ActivePole] = defaultCard;
    }

    // save the line Ups to the static arrays from the LineUpController script
    public void SavePlayerLineUp()
    {
        LineUpController.PlayerDefaultCardLineUP = PlayerDefaultCardLineUp;
        LineUpController.PlayerAbilityCardLineUP = PlayerAbilityCardLineUp;
    }
    #endregion

    
    #region Methods -> Add items, cards and currency to inventory
    // Items
    public void AddItem(ItemObject item, int amount)
    {
        for (int i = 0; i < ItemContainer.Count; i++)
        {
            if (ItemContainer[i].Item == item)
            {
                ItemContainer[i].AddAmount(amount);
                return;
            }
        }
        ItemContainer.Add(new ISlotItem(database.GetItemID[item], item, amount));
    }
    // Default Cards
    public void AddDefaultCard(DefaultCardObject item, int amount)
    {
        for (int i = 0; i < DefaultCardContainer.Count; i++)
        {
            if (DefaultCardContainer[i].DefaultCard == item)
            {
                DefaultCardContainer[i].AddAmount(amount);
                return;
            }
        }
        DefaultCardContainer.Add(new ISlotDefaultCard(database.GetDefaultCardID[item], item, amount));
    }

    // Special Cards
    public void AddSpecialCard(SpecialCardObject item, int amount)
    {
        for (int i = 0; i < AbilityCardContainer.Count; i++)
        {
            if (AbilityCardContainer[i].SpecialCard == item)
            {
                AbilityCardContainer[i].AddAmount(amount);
                return;
            }
        }
        AbilityCardContainer.Add(new ISlotSpecialCard(database.GetSpecialCardID[item], item, amount));
    }

    public void AddResource(int woodValue)
    {
        Wood += woodValue;
    }
    public void AddMoney(int moneyValue)
    {
        Money += moneyValue;
    }
    #endregion
    
    #region Methods -> Save the inventory
    public void Save()
    {
        string saveData = JsonUtility.ToJson(this, true);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(string.Concat(Application.persistentDataPath, SavePath));
        bf.Serialize(file, saveData);
        file.Close();
    }
    public void Load()
    {
        if(File.Exists(String.Concat(Application.persistentDataPath, SavePath)))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(String.Concat(Application.persistentDataPath, SavePath), FileMode.Open);
            JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(), this);
            file.Close();
        }
    }
    #endregion
    
    public void OnBeforeSerialize()
    {
    }

    public void OnAfterDeserialize()
    {
        for (int i = 0; i < ItemContainer.Count; i++)
        {
            ItemContainer[i].Item = database.GetItem[ItemContainer[i].ID];
        }
    }
    // checks if unity editor is runned. 
    // when the project is built the "else" part will take over.
    private void OnEnable()
    {
#if UNITY_EDITOR
        database = (ItemDatabaseObject) AssetDatabase.LoadAssetAtPath("Assets/Resources/Database.asset", typeof(ItemDatabaseObject));
#else 
        database = Resources.Load<ItemDatabaseObject>("Database");
#endif
    }
}


#region Inventory Slots
    [System.Serializable]
    public class ISlotItem // Inventory slot for items
    {
        public int ID;
        public ItemObject Item;
        public int Amount;

        // defines a space for an object in the inventory
        public ISlotItem(int _id, ItemObject _item, int _amount)
        {
            ID = _id;
            Item = _item;
            Amount = _amount;
        }

        public void AddAmount(int value)
        {
            Amount += value;
        }
    }

    
    [System.Serializable]
    public class ISlotDefaultCard // Inventory slot for default cards
    {
        public int ID;
        public DefaultCardObject DefaultCard;
        public int Amount;
    
        // defines a space for an object in the inventory
        public ISlotDefaultCard(int _id, DefaultCardObject _item, int _amount)
        {
            ID = _id;
            DefaultCard = _item;
            Amount = _amount;
        }
    
        public void AddAmount(int value)
        {
            Amount += value;
        }
    }
    
    [System.Serializable]
    public class ISlotSpecialCard // Inventory slot for special cards
    {
        public int ID;
        public SpecialCardObject SpecialCard;
        public int Amount;
    
        // defines a space for an object in the inventory
        public ISlotSpecialCard(int _id, SpecialCardObject _item, int _amount)
        {
            ID = _id;
            SpecialCard = _item;
            Amount = _amount;
        }
    
        public void AddAmount(int value)
        {
            Amount += value;
        }
    }
#endregion
