using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NPC_Inventory", menuName = "NPC Inventory")]
public class NPCInventorySO : ScriptableObject
{
    // Cards
    public CardObject[] AIDefaultCardLineUP = new CardObject[4];
    public CardObject[] AIAbilityCardLineUP = new CardObject[4];

    // Difficulty
    public int mainPoleDifficulty;
    public int crew1PoleDifficulty;
    public int crew2PoleDifficulty;
    public int crew3PoleDifficulty;

    // Price if Player wins
    public DefaultCardObject cardPrice;

    public MoneyObject moneyPrice;
    // or
    public int _moneyPrice;
}
