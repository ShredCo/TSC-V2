using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public enum ItemType
{
    Money,
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
    public ItemType Type;
    public ItemValue Value;
    
    public int MoneyValue;
    
    [TextArea(15,20)]
    public string Description;
}

