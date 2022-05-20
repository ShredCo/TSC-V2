using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineUpControllerLokalOneVsOne : MonoBehaviour
{
    #region Players Line UP
    // Player 1
    public static CardObject[] Player1_DefaultCardLineUP = new CardObject[4];
    public static CardObject[] Player1_AbilityCardLineUP = new CardObject[4];
    public static ISlotDefaultCard Player1_PoleSlotCard1;
    public static ISlotDefaultCard Player1_PoleSlotCard2;
    public static ISlotDefaultCard Player1_PoleSlotCard3;
    public static ISlotDefaultCard Player1_PoleSlotCard4;
 
    // Player 2
    public static CardObject[] Player2_DefaultCardLineUP = new CardObject[4];
    public static CardObject[] Player2_AbilityCardLineUP = new CardObject[4];
    public static ISlotDefaultCard Player2_PoleSlotCard1;
    public static ISlotDefaultCard Player2_PoleSlotCard2;
    public static ISlotDefaultCard Player2_PoleSlotCard3;
    public static ISlotDefaultCard Player2_PoleSlotCard4;
    #endregion

    #region Inventory / Line Up Card Management
    public static int ActivePole;
    public static bool CardType = true;
    
    public static CardSlotUI ActiveCard;
    public static bool CantEquip = false;
    #endregion

    #region Map
    public static MapType MapType;
    #endregion
}
