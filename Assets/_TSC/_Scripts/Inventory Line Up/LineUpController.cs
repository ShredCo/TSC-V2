using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineUpController : MonoBehaviour
{
    // Arrays to save Player Line Up
    public static CardObject[] PlayerDefaultCardLineUP = new CardObject[4];
    public static CardObject[] PlayerSpecialCardLineUP = new CardObject[4];

    public static ISlotDefaultCard PoleSlotCardMain;
    public static ISlotDefaultCard PoleSlotCardCrew1;
    public static ISlotDefaultCard PoleSlotCardCrew2;
    public static ISlotDefaultCard PoleSlotCardCrew3;

    // Arrays to save AI Line Up
    public static CardObject[] AIDefaultCardLineUP = new CardObject[4];
    public static CardObject[] AISpecialCardLineUP = new CardObject[4];

    public static int ActivePole;

    public static CardSlotUI ActiveCard;

    private void Update()
    {
        PoleSlotCardMain.DefaultCard = PlayerDefaultCardLineUP[0];
        PoleSlotCardCrew1.DefaultCard = PlayerDefaultCardLineUP[1];
        PoleSlotCardCrew2.DefaultCard = PlayerDefaultCardLineUP[2];
        PoleSlotCardCrew3.DefaultCard = PlayerDefaultCardLineUP[3];
    }
}
