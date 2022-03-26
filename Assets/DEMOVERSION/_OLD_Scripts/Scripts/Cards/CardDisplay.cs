using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public Cards card;

    public Text nameText;
    public Text levelText;
    public Text desctiptionText;
    public Text powerPointsText;
    public Text attackText;

    public Image artworkImage;
    public Image elementImage;

    void Start()
    {
        nameText.text = card.name;
        levelText.text = card.level.ToString();
        desctiptionText.text = card.description;
        powerPointsText.text = card.powerPoints.ToString();
        attackText.text = card.attack.ToString();

        artworkImage.sprite = card.artwork;
        elementImage.sprite = card.element;
    }
}
