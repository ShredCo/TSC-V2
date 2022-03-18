using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryTest : MonoBehaviour
{
    [SerializeField] List<CardSlot> slots;

    public List<CardSlot> Slots => slots;

    public static InventoryTest GetInventory()
    {
        return FindObjectOfType<TestingPlayer>().GetComponent<InventoryTest>();
    }
}
[Serializable]
public class CardSlot
{
    [SerializeField] Cards card;
    [SerializeField] int count;

    public Cards Card => card;
    public int Count => count;
}