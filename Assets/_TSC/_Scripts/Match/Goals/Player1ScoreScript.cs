using UnityEngine;
using TMPro;

public class Player1ScoreScript : MonoBehaviour
{
    [SerializeField] private TextMeshPro text;
    
    void Start()
    {
        text = GetComponent<TextMeshPro>();
    }
    void Update()
    {
        text.text = "1. Player: " + GameManagerClash.Instance.ScorePlayer1.ToString();
    }
}
