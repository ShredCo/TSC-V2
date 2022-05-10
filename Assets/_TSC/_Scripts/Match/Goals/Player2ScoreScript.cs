using UnityEngine;
using TMPro;

public class Player2ScoreScript : MonoBehaviour
{
    [SerializeField] private TextMeshPro text;
    
    void Start()
    {
        text = GetComponent<TextMeshPro>();   
    }
    void Update()
    {
        text.text = "2. Player: " + GameManagerSoccermatch.Instance.ScorePlayer2.ToString();
    }
}
