using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player1ScoreScript : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "1. Player: " + GameManagerOneVsOne.Instance.ScorePlayer1.ToString();
    }
}
