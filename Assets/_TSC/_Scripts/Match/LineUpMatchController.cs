using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineUpMatchController : MonoBehaviour
{
    // Arrays to store the Line Ups
    [SerializeField] public CardObject[] PlayerDefaultCardLineUP = new CardObject[4];
    [SerializeField] public CardObject[] PlayerSpecialCardLineUP = new CardObject[4];
    [SerializeField] public CardObject[] AIDefaultCardLineUP = new CardObject[4];
    [SerializeField] public CardObject[] AISpecialCardLineUP = new CardObject[4];

    void Start()
    {
        // Get static Line Up Arrays from the LineUpController script
        PlayerDefaultCardLineUP = LineUpController.PlayerDefaultCardLineUP;
        PlayerSpecialCardLineUP = LineUpController.PlayerAbilityCardLineUP;        
        AIDefaultCardLineUP = LineUpController.AIDefaultCardLineUP;
        AISpecialCardLineUP = LineUpController.AIAbilityCardLineUP;
    }

}
