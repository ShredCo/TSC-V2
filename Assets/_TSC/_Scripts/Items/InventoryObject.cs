using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;

[CreateAssetMenu(fileName = "new inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject, ISerializationCallbackReceiver
{

    [Header("Currency")]
    public int money;

    [Header("References")]
    public string savePath;
    private ItemDatabaseObject database;
    
    
    // creates a List with slots for the inventory
    // adds an item to it
    public List<ISlotItem> ItemContainer = new List<ISlotItem>();

    public List<ISlotDefaultCard> DefaultCardContainer = new List<ISlotDefaultCard>();

    public List<ISlotSpecialCard> SpecialCardContainer = new List<ISlotSpecialCard>();


    // arrays to store the Player Line Up
    public DefaultCardObject[] PlayerDefaultCardLineUp = new DefaultCardObject[4];

    public SpecialCardObject[] PlayerSpecialCardLineUp = new SpecialCardObject[4];

    // arrays to store the AI Line Up
    public DefaultCardObject[] AIDefaultCardLineUp = new DefaultCardObject[4]; //may not be needed

    public SpecialCardObject[] AISpecialCardLineUp = new SpecialCardObject[4]; //may not be needed

    // methods to add cards to Line Up
    public void AddDefaultCardtoLineUp(DefaultCardObject Card, int ID)
    {
        PlayerDefaultCardLineUp[ID] = Card;
    }    
    public void AddSpecialCardtoLineUp(SpecialCardObject Card, int ID)
    {
        PlayerSpecialCardLineUp[ID] = Card;
    }

    // methods to save Line Up for match
    public void SavePlayerLineUp()
    {
        LineUpController.PlayerDefaultCardLineUP = PlayerDefaultCardLineUp;
        LineUpController.PlayerSpecialCardLineUP = PlayerSpecialCardLineUp;
    }

    // will be called from NPC, that has its own Line Up
    public void SaveAILineUp(DefaultCardObject[] defaultCardObjects, SpecialCardObject[] specialCardObjects)
    {
        LineUpController.PlayerDefaultCardLineUP = defaultCardObjects;
        LineUpController.PlayerSpecialCardLineUP = specialCardObjects;
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


    #region Methods -> Add items, cards and currency to inventory
    // Items
    public void AddItem(ItemObject _item, int _amount)
    {
        for (int i = 0; i < ItemContainer.Count; i++)
        {
            if (ItemContainer[i].Item == _item)
            {
                ItemContainer[i].AddAmount(_amount);
                return;
            }
        }
        ItemContainer.Add(new ISlotItem(database.GetItemID[_item], _item, _amount));
    }
    // Default Cards
    public void AddDefaultCard(CardObject _item, int _amount)
    {
        for (int i = 0; i < DefaultCardContainer.Count; i++)
        {
            if (DefaultCardContainer[i].DefaultCard == _item)
            {
                DefaultCardContainer[i].AddAmount(_amount);
                return;
            }
        }
        DefaultCardContainer.Add(new ISlotDefaultCard(database.GetDefaultCardID[_item], _item, _amount));
    }

    // Special Cards
    public void AddSpecialCard(CardObject _item, int _amount)
    {
        for (int i = 0; i < SpecialCardContainer.Count; i++)
        {
            if (SpecialCardContainer[i].SpecialCard == _item)
            {
                SpecialCardContainer[i].AddAmount(_amount);
                return;
            }
        }
        SpecialCardContainer.Add(new ISlotSpecialCard(database.GetSpecialCardID[_item], _item, _amount));
    }

    public void AddMoney(int _moneyValue)
    {
        money += _moneyValue;
    }
    #endregion


    // Methods to save the inventory
    public void Save()
    {
        string saveData = JsonUtility.ToJson(this, true);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(string.Concat(Application.persistentDataPath, savePath));
        bf.Serialize(file, saveData);
        file.Close();
    }
    public void Load()
    {
        if(File.Exists(String.Concat(Application.persistentDataPath, savePath)))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(String.Concat(Application.persistentDataPath, savePath), FileMode.Open);
            JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(), this);
            file.Close();
        }
    }
    
    
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
}

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
    public CardObject DefaultCard;
    public int Amount;

    // defines a space for an object in the inventory
    public ISlotDefaultCard(int _id, CardObject _item, int _amount)
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
public class ISlotSpecialCard // Inventory slot for default cards
{
    public int ID;
    public CardObject SpecialCard;
    public int Amount;

    // defines a space for an object in the inventory
    public ISlotSpecialCard(int _id, CardObject _item, int _amount)
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
