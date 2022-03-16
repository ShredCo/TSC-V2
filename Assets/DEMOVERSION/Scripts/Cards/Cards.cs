using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Cards : ScriptableObject
{
    public new string name;
    public int level = 1;
    public int health;
    public int powerPoints;
    public int attack;
    public string description;

    public Sprite artwork;

    public Sprite element;
}
