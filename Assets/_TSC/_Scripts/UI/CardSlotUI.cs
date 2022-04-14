using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSlotUI : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] public CardObject CardSlot;

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
        CardSlot = cardSlot.DefaultCard;
    }
    public void SetData(ISlotSpecialCard cardSlot)
    {
        nameText.text = cardSlot.SpecialCard.Name;
        countText.text = "x " + cardSlot.Amount;
        levelText.text = "Lv. " + cardSlot.SpecialCard.Level.ToString();
        attackText.text = cardSlot.SpecialCard.Attack.ToString();
        healthText.text = cardSlot.SpecialCard.Health.ToString();
        cardArtwork.sprite = cardSlot.SpecialCard.CardArtwork;
        CardSlot = cardSlot.SpecialCard;
    }

    public void SetData(CardObject cardSlot)
    {
        nameText.text = cardSlot.Name;
        levelText.text = "Lv. " + cardSlot.Level.ToString();
        attackText.text = cardSlot.Attack.ToString();
        healthText.text = cardSlot.Health.ToString();
        cardArtwork.sprite = cardSlot.CardArtwork;
    }
}
