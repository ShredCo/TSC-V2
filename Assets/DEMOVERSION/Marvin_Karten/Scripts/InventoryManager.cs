using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : ScriptableObject
{
    public List<Cards> cards = new List<Cards>();

    public void Add(Cards card)
    {
        cards.Add(card);
    }

    public void Remove(Cards card)
    {
        cards.Remove(card);
    }
}
