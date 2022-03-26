using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Team1ScoreScript : MonoBehaviour
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
        text.text = "Team 1: " + GameManagerTwoVsTwo.Instance.ScoreTeam1.ToString();
    }
}
