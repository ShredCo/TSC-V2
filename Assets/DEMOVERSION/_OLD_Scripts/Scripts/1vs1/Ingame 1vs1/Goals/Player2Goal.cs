using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Goal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            if (GameManagerOneVsOne.Instance.ScorePlayer1 < 10)
            {
                GameManagerOneVsOne.Instance.ScorePlayer1 += 1;
                BallManager.Instance.ballInGame = false; 
            }
        }
    }

}
