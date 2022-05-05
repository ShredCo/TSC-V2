using System.Collections;
using UnityEngine;

public class Player1Goal : MonoBehaviour
{
    // Cheering sounds
    [SerializeField] AudioSource playSound1;
    [SerializeField] AudioSource playSound2;
    [SerializeField] AudioSource playSound3;
    [SerializeField] AudioSource playSound4;

    // VFX
    [SerializeField] GameObject explosionGoal1;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            if (GameManagerSoccermatch.Instance.ScorePlayer2 < 5)
            {
                StartCoroutine(SpawnNewBall());
            }
        }           
    }
    
    IEnumerator SpawnNewBall()
    {
        // Give the opponent a point
        GameManagerSoccermatch.Instance.ScorePlayer2 += 1;
        BallManager.Instance.BallInGame = false;

        // Plays goals cheering sounds
        playSound1.Play(4);
        playSound2.Play(1);
        playSound3.Play(2);
        playSound4.Play(1);
        
        // Plays the goal VFX
        explosionGoal1.SetActive(true);
        yield return new WaitForSeconds(2f);
        explosionGoal1.SetActive(false);
        
        // Spawns a new ball
        yield return new WaitForSeconds(1f);
        if (BallManager.Instance.BallInGame == false)
        {
            BallManager.Instance.SpawnSoccerBall();
        }
    }
}
