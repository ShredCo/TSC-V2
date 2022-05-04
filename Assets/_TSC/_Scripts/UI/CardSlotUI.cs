using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSlotUI : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] public DefaultCardObject DefaultCardSlot;
    [SerializeField] public SpecialCardObject SpecialCardSlot;
    
    [SerializeField] Text nameText;
    [SerializeField] Text levelText;

    [SerializeField] Text maxConditionText;
    [SerializeField] Text conditionText;

    [SerializeField] Image cardArtwork; 

    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Sets data to display values from Cards to UI
    public void SetData(DefaultCardObject cardSlot)
    {
        DefaultCardSlot = cardSlot;
        nameText.text = cardSlot.Name;
        levelText.text = "Lv. " + cardSlot.Level.ToString();
        maxConditionText.text = cardSlot.MaxCondition.ToString();
        conditionText.text = cardSlot.Condition.ToString();
        cardArtwork.sprite = cardSlot.CardArtwork;
    }
    public void SetData(SpecialCardObject cardSlot)
    {
        SpecialCardSlot = cardSlot;
        nameText.text = cardSlot.Name;
        levelText.text = "Lv. " + cardSlot.Level.ToString();
        cardArtwork.sprite = cardSlot.CardArtwork;
        
        maxConditionText.gameObject.SetActive(false);
        conditionText.gameObject.SetActive(false);
    }
    
    // Triggers an animation when card is not equippable
    public void CantEquipAnimation()
    {
        animator.SetTrigger("CantEquip");
    }
}
