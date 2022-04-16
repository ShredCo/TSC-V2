using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineUpController : MonoBehaviour
{
    // Arrays to save Player Line Up
    public static CardObject[] PlayerDefaultCardLineUP = new CardObject[4];
    public static CardObject[] PlayerAbilityCardLineUP = new CardObject[4];

    public static ISlotDefaultCard PoleSlotCardMain;
    public static ISlotDefaultCard PoleSlotCardCrew1;
    public static ISlotDefaultCard PoleSlotCardCrew2;
    public static ISlotDefaultCard PoleSlotCardCrew3;

    // Arrays to save AI Line Up
    public static CardObject[] AIDefaultCardLineUP = new CardObject[4];
    public static CardObject[] AIAbilityCardLineUP = new CardObject[4];

    public static int MainPoleDifficulty;
    public static int Crew1PoleDifficulty;
    public static int Crew2PoleDifficulty;
    public static int Crew3PoleDifficulty;

    public static int ActivePole;

    public static bool CardType = true;

    public static CardSlotUI ActiveCard;
}
