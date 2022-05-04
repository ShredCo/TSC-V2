using UnityEngine;

[CreateAssetMenu(fileName = "New money object", menuName = "Inventory System/Items/Money")]
public class MoneyObject : ItemObject
{
    private void Awake()
    {
        Type = ItemType.Money;
    }
}