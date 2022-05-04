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
    
    // Card Stats
    public string Name;
    public int Level = 1;
    public float MaxCondition;
    public float Condition;
    public float Attack;

    // References
    public GameObject PlayerPrefab;
    public Sprite CardArtwork;
    public Ability Ability;
    public DefaultCardObject NextLevelCard;
    public bool IsUpgradable;
}
