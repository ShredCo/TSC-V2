using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New item Database", menuName = "Inventory System/Items/Database")]
public class ItemDatabaseObject : ScriptableObject, ISerializationCallbackReceiver
{
    // Item Database
    public ItemObject[] Items;
    public Dictionary<ItemObject, int> GetItemID = new Dictionary<ItemObject, int>();
    public Dictionary<int, ItemObject> GetItem  = new Dictionary<int, ItemObject>();

    // DefaultCard Database
    public CardObject[] DefaultCards;
    public Dictionary<CardObject, int> GetDefaultCardID = new Dictionary<CardObject, int>();
    public Dictionary<int, CardObject> GetDefaultCard = new Dictionary<int, CardObject>();

    // SpecialCard Database
    public CardObject[] SpecialCards;
    public Dictionary<CardObject, int> GetSpecialCardID = new Dictionary<CardObject, int>();
    public Dictionary<int, CardObject> GetSpecialCard = new Dictionary<int, CardObject>();

    public void OnAfterDeserialize()
    {
        // For Items
        GetItemID = new Dictionary<ItemObject, int>();
        GetDefaultCard = new Dictionary<int, CardObject>();
        for (int i = 0; i < Items.Length; i++)
        {
            GetItemID.Add(Items[i], i);
            GetItem.Add(i, Items[i]);
        }

        // For DefaultCards
        GetDefaultCardID = new Dictionary<CardObject, int>();
        GetDefaultCard = new Dictionary<int, CardObject>();
        for (int i = 0; i < DefaultCards.Length; i++)
        {
            GetDefaultCardID.Add(DefaultCards[i], i);
            GetDefaultCard.Add(i, DefaultCards[i]);
        }

        // For SpecialCards
        GetSpecialCardID = new Dictionary<CardObject, int>();
        GetSpecialCard = new Dictionary<int, CardObject>();
        for (int i = 0; i < SpecialCards.Length; i++)
        {
            GetSpecialCardID.Add(SpecialCards[i], i);
            GetSpecialCard.Add(i, SpecialCards[i]);
        }
    }

    public void OnBeforeSerialize()
    {
        
    }
}