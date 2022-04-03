using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineUpController : MonoBehaviour
{
    // Arrays to save Player Line Up
    public static DefaultCardObject[] PlayerDefaultCardLineUP = new DefaultCardObject[4];
    public static SpecialCardObject[] PlayerSpecialCardLineUP = new SpecialCardObject[4];

    // Arrays to save AI Line Up
    public static DefaultCardObject[] AIDefaultCardLineUP = new DefaultCardObject[4];
    public static SpecialCardObject[] AISpecialCardLineUP = new SpecialCardObject[4];

    public static int ActivePole;
}
