using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player1Goal : MonoBehaviour
{
    public AudioSource PlaySound1;
    public AudioSource PlaySound2;
    public AudioSource PlaySound3;
    public AudioSource PlaySound4;

    public GameObject ExplosionGoal1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            if (GameManagerOneVsOne.Instance.ScorePlayer2 < 10)
            {
                GameManagerOneVsOne.Instance.ScorePlayer2 += 1;
                BallManager.Instance.ballInGame = false;

                // Plays goals cheering sounds
                PlaySound1.Play(4);
                PlaySound2.Play(1);
                PlaySound3.Play(2);
                PlaySound4.Play(1);

                StartCoroutine(SpawnNewBall());
            }
        }           
    }
    
    IEnumerator SpawnNewBall()
    {
        ExplosionGoal1.SetActive(true);
        yield return new WaitForSeconds(2f);
        ExplosionGoal1.SetActive(false);
        yield return new WaitForSeconds(5f);
        if (BallManager.Instance.ballInGame == false)
        {
            BallManager.Instance.SpawnSoccerBall();
        }
    }
}
