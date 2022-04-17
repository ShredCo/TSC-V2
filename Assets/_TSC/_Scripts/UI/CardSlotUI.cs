using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSlotUI : MonoBehaviour
{
    [Header("Variables")]
    //[SerializeField] public CardObject CardSlot;
    [SerializeField] public DefaultCardObject DefaultCardSlot;
    [SerializeField] public SpecialCardObject SpecialCardSlot;

    [SerializeField] Text countText;

    [SerializeField] Text nameText;
    [SerializeField] Text levelText;

    [SerializeField] Text attackText;
    [SerializeField] Text healthText;

    [SerializeField] Image cardArtwork; 

    public void SetData(DefaultCardObject cardSlot)
    {
        DefaultCardSlot = cardSlot;
        nameText.text = cardSlot.Name;
        levelText.text = "Lv. " + cardSlot.Level.ToString();
        attackText.text = cardSlot.Attack.ToString();
        healthText.text = cardSlot.Health.ToString();
        cardArtwork.sprite = cardSlot.CardArtwork;
    }
    public void SetData(SpecialCardObject cardSlot)
    {
        SpecialCardSlot = cardSlot;
        nameText.text = cardSlot.Name;
        levelText.text = "Lv. " + cardSlot.Level.ToString();
        attackText.text = cardSlot.Attack.ToString();
        healthText.text = cardSlot.Health.ToString();
        cardArtwork.sprite = cardSlot.CardArtwork;
    }

    //public void SetData(CardObject cardSlot)
    //{
    //    CardSlot = cardSlot;
    //    nameText.text = cardSlot.Name;
    //    levelText.text = "Lv. " + cardSlot.Level.ToString();
    //    attackText.text = cardSlot.Attack.ToString();
    //    healthText.text = cardSlot.Health.ToString();
    //    cardArtwork.sprite = cardSlot.CardArtwork;
    //}
}
