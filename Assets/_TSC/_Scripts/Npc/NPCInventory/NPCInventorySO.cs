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
    [Range(0.1f, 1f)]
    public float MovementInputValue;
    [Range(0.1f, 1f)]
    public float RotationInputValue;

    public void SetNPCLineUp()
    {
        LineUpController.AIDefaultCardLineUP = AIDefaultCardLineUP;
        LineUpController.AIAbilityCardLineUP = AIAbilityCardLineUP;

        LineUpController.RotationInputValue = RotationInputValue;
        LineUpController.MovementInputValue = MovementInputValue;
    }
}
