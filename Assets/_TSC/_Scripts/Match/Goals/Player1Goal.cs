using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player1Goal : MonoBehaviour
{
    public AudioSource playSound1;
    public AudioSource playSound2;
    public AudioSource playSound3;
    public AudioSource playSound4;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            if (GameManagerOneVsOne.Instance.ScorePlayer2 < 10)
            {
                GameManagerOneVsOne.Instance.ScorePlayer2 += 1;
                BallManager.Instance.ballInGame = false;
                print("ball in game:");
                
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
        SpawnBallManager.Instance.SpawnBall();
    }
}
