using UnityEngine;

public enum ItemType
{
    Money,
    Resource,
    Default
}

public abstract class ItemObject : ScriptableObject
{
    // reference for the UI
    public GameObject ImagePrefab;
    
    // enums
    public ItemType Type;

    // values
    public int MoneyValue;
    public int ResourceValue;
    
    [TextArea(15,20)]
    public string Description;
}

