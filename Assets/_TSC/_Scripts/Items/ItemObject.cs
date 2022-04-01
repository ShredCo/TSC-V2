using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public enum ItemType
{
    Money,
    DefaultCard,
    SpecialCard,
    Resource,
    Default
}

public enum ItemValue
{
    Low,
    Medium,
    High,
}

public abstract class ItemObject : ScriptableObject
{
    // reference for the UI
    public GameObject ImagePrefab;

    private int lowValue;
    // enums
    public ItemType type;
    public ItemValue value;
    
    public int moneyValue;
    
    [TextArea(15,20)]
    public string description;
}

