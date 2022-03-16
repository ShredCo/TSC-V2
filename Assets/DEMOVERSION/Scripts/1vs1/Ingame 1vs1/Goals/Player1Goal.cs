using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player1Goal : MonoBehaviour
{
    [Header("Pirates")]
    public GameObject pirateCaptain;
    public GameObject pirateOldMan1;
    public GameObject pirateOldMan2;
    public GameObject pirateOldMan3;
    public GameObject pirateCrewSeaman1;
    public GameObject pirateCrewSeaman2;
    public GameObject pirateDeckhand1;
    public GameObject pirateDeckhand2;

    [Header("EnglishGuys")]
    public GameObject englishCaptain;
    public GameObject englishSoldier;
    public GameObject englishGentleman1;
    public GameObject englishGentleman2;
    public GameObject englishGovernor;
    public GameObject englishGovernorsDaughter;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            if (GameManagerOneVsOne.Instance.ScorePlayer2 < 10)
            {
                GameManagerOneVsOne.Instance.ScorePlayer2 += 1;
                Destroy(GameObject.FindGameObjectWithTag("Ball"), 1);
                SpawnBallManager.Instance.ballInGame = false;
            }

            // Pirate guys cheering animations when a goal happens
            pirateCaptain.GetComponent<Animator>().Play("cheering");
            pirateOldMan1.GetComponent<Animator>().Play("cheering");
            pirateOldMan2.GetComponent<Animator>().Play("cheering");
            pirateOldMan3.GetComponent<Animator>().Play("cheering");
            pirateCrewSeaman1.GetComponent<Animator>().Play("sittingCheering");
            pirateCrewSeaman2.GetComponent<Animator>().Play("cheering");
            pirateDeckhand1.GetComponent<Animator>().Play("cheering");
            pirateDeckhand2.GetComponent<Animator>().Play("cheering");


            // English guys complaining animations when a goal happens
            englishCaptain.GetComponent<Animator>().Play("shakingHeadNoNo");
            englishSoldier.GetComponent<Animator>().Play("shakingHeadNoNo");
            englishGentleman1.GetComponent<Animator>().Play("shakingHeadNoNo");
            englishGentleman2.GetComponent<Animator>().Play("sittingDisbelief");
            englishGovernor.GetComponent<Animator>().Play("shakingHeadNoNo");
            englishGovernorsDaughter.GetComponent<Animator>().Play("shakingHeadNoNo");
        }           
    }
}
