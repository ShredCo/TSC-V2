using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSlotUI : MonoBehaviour
{
    [SerializeField] Text nameText;
    [SerializeField] Text countText;

    public void SetData(CardSlot cardSlot)
    {
        nameText.text = cardSlot.Card.name;
        countText.text = $"x{cardSlot.Count}";
    }
}
