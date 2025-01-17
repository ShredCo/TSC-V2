using UnityEngine;

[CreateAssetMenu(fileName = "New default object", menuName = "Inventory System/Items/Default")]
public class DefaultObject : ItemObject
{
    private void Awake()
    {
        Type = ItemType.Default;
    }
}