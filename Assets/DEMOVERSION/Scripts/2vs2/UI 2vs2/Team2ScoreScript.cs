using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Team2ScoreScript : MonoBehaviour
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
        text.text = "Team 2: " + GameManagerTwoVsTwo.Instance.ScoreTeam2.ToString();
    }
}
