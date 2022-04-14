using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player2ScoreScript : MonoBehaviour
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
        text.text = "2. Player: " + GameManagerOneVsOne.Instance.ScorePlayer2.ToString();
    }
}
