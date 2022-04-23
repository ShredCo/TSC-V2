using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player2Goal : MonoBehaviour
{
    public AudioSource playSound1;
    public AudioSource playSound2;
    public AudioSource playSound3;
    public AudioSource playSound4;
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            if (GameManagerOneVsOne.Instance.ScorePlayer1 < 10)
            {
                GameManagerOneVsOne.Instance.ScorePlayer1 += 1;
                BallManager.Instance.ballInGame = false;

                // Plays goals cheering sounds
                playSound1.Play(4);
                playSound2.Play(1);
                playSound3.Play(2);
                playSound4.Play(1);

                StartCoroutine(SpawnNewBall());
            }
        }
    }

    IEnumerator SpawnNewBall()
    {
        yield return new WaitForSeconds(5f);
        if (BallManager.Instance.ballInGame == false)
        {
            BallManager.Instance.SpawnSoccerBall();
        }
    }
}
