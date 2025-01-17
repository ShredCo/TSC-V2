using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MapType 
{ 
    Route1_1,
    Route1_2,
    OkinaShores_Default,
    OkinaShores_Arena,
    YapaYapa, 
    MoanaReef
}

public class LineUpController : MonoBehaviour
{
    #region Player Line UP
    public static CardObject[] PlayerDefaultCardLineUP = new CardObject[4];
    public static CardObject[] PlayerAbilityCardLineUP = new CardObject[4];

    public static ISlotDefaultCard PoleSlotCardMain;
    public static ISlotDefaultCard PoleSlotCardCrew1;
    public static ISlotDefaultCard PoleSlotCardCrew2;
    public static ISlotDefaultCard PoleSlotCardCrew3;
    #endregion

    #region AI Line UP
    public static CardObject[] AIDefaultCardLineUP = new CardObject[4];
    public static CardObject[] AIAbilityCardLineUP = new CardObject[4];
    #endregion

    #region AI Difficulty
    public static float SmoothSpeed;
    public static float RotationInputValue;
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

    #region Rewards / NPC states
    public static bool DidWin;

    public static int MoneyReward;
    public static DefaultCardObject DefaultCardReward;

    public static Dialogue AfterMatchDialogue;
    public static Vector3 NPCPosition;
    public static string NPCName;
    #endregion

    public static Vector3 PlayerPosition;
}
