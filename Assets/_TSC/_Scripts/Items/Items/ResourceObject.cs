using UnityEngine;

[CreateAssetMenu(fileName = "New resource object", menuName = "Inventory System/Items/Resource")]
public class ResourceObject : ItemObject
{
    private void Awake()
    {
        Type = ItemType.Resource;
    }
}