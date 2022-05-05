using UnityEngine;
using TMPro;

public class Player1ScoreScript : MonoBehaviour
{
    [SerializeField] TextMeshPro text;
    
    void Start()
    {
        text = GetComponent<TextMeshPro>();
    }
    void Update()
    {
        text.text = "1. Player: " + GameManagerSoccermatch.Instance.ScorePlayer1.ToString();
    }
}
