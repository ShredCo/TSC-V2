using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSlotUI : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] public DefaultCardObject DefaultCardSlot;
    [SerializeField] public SpecialCardObject SpecialCardSlot;
    
    [SerializeField] private Text nameText;
    [SerializeField] private Text levelText;

    [SerializeField] private Text maxConditionText;
    [SerializeField] private Text conditionText;

    [SerializeField] private Image cardArtwork; 

    private Animator animator;

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
        maxConditionText.text = Mathf.Round(cardSlot.MaxCondition).ToString();
        conditionText.text = Mathf.Round(cardSlot.Condition).ToString();
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
