using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Player2Goal : MonoBehaviour
{
    public AudioSource PlaySound1;
    public AudioSource PlaySound2;
    public AudioSource PlaySound3;
    public AudioSource PlaySound4;

    public GameObject ExplosionGoal2;
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            if (GameManagerOneVsOne.Instance.ScorePlayer1 < 5)
            {
                GameManagerOneVsOne.Instance.ScorePlayer1 += 1;
                BallManager.Instance.BallInGame = false;

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
        ExplosionGoal2.SetActive(true);
        yield return new WaitForSeconds(2f);
        ExplosionGoal2.SetActive(false);
        yield return new WaitForSeconds(3f);
        if (BallManager.Instance.BallInGame == false)
        {
            BallManager.Instance.SpawnSoccerBall();
        }
    }
}
