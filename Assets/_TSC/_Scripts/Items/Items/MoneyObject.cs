using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;


[CreateAssetMenu(fileName = "New money object", menuName = "Inventory System/Items/Money")]
public class MoneyObject : ItemObject
{
    private void Awake()
    {
        Type = ItemType.Money;
    }
    
    // Todo: set a random range between 1/10 & 10/100 & 100/300 ôr something. Depends on how big the moneyItem is.
}