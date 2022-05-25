using System;
using System.Collections;
using UnityEngine;

public class Player1Goal : MonoBehaviour
{
    // Cheering sounds
    [SerializeField] private AudioSource playSound1;
    [SerializeField] private AudioSource playSound2;
    [SerializeField] private AudioSource playSound3;
    [SerializeField] private AudioSource playSound4;

    // VFX
    [SerializeField] private GameObject explosionGoal1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            // changes the camera
            CinemachineSwitcher.Instance.SwitchCameraGoal1();
            
            // checks win condition and respawns new ball
            if (GameManagerClash.Instance.ScorePlayer2 < 5)
            {
                StartCoroutine(SpawnNewBall());
            }
        }           
    }
    
    IEnumerator SpawnNewBall()
    {
        // Give the opponent a point
        GameManagerClash.Instance.ScorePlayer2 += 1;
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
