using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardType
{
    DefaultCard,
    SpecialCard
}

public class CardObject : ScriptableObject
{
    public CardType Type;

    [Header("Default Card")]
    public string Name;
    public int Level = 1;

    public int PowerPoints;

    public int Health;
    public int Attack;

    public Sprite CardArtwork;
}
