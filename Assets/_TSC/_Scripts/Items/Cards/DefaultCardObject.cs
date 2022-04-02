using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New default card object", menuName = "Inventory System/Cards/DefaultCard")]
public class DefaultCardObject : CardObject
{
    private void Awake()
    {
        Type = CardType.DefaultCard;
    }
}