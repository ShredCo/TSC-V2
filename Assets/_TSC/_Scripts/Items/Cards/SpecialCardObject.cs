using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New special card object", menuName = "Inventory System/Cards/SpecialCard")]
public class SpecialCardObject : CardObject
{
    private void Awake()
    {
        Type = CardType.DefaultCard;
    }
}