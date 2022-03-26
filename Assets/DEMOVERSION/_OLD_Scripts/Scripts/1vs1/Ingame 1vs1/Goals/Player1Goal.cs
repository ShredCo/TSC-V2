using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player1Goal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            if (GameManagerOneVsOne.Instance.ScorePlayer2 < 10)
            {
                GameManagerOneVsOne.Instance.ScorePlayer2 += 1;
                BallManager.Instance.ballInGame = false;
                print("ball in game:");
            }
        }           
    }
}
