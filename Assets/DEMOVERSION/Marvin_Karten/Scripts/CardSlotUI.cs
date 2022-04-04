using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSlotUI : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] ISlotDefaultCard defaultCardSlot;

    [SerializeField] Text countText;

    [SerializeField] Text nameText;
    [SerializeField] Text levelText;

    [SerializeField] Text attackText;
    [SerializeField] Text healthText;

    [SerializeField] Image cardArtwork; 

    public void SetData(ISlotDefaultCard cardSlot)
    {
        nameText.text = cardSlot.DefaultCard.Name;
        countText.text = "x " + cardSlot.Amount;
        levelText.text = "Lv. " + cardSlot.DefaultCard.Level.ToString();
        attackText.text = cardSlot.DefaultCard.Attack.ToString();
        healthText.text = cardSlot.DefaultCard.Health.ToString();
        cardArtwork.sprite = cardSlot.DefaultCard.CardArtwork;
    }
}
