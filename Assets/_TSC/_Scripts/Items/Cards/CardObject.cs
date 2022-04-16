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
    public GameObject PlayerPrefab;

    public CardType Type;

    public Ability Ability;

    [Header("Default Card")]
    public string Name;
    public int Level = 1;

    public int Health;
    public int Attack;

    public Sprite CardArtwork;
}
