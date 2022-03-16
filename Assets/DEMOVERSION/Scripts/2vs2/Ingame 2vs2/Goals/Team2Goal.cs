using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team2Goal : MonoBehaviour
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
            if (GameManagerTwoVsTwo.Instance.ScoreTeam1 < 10)
            {
                GameManagerTwoVsTwo.Instance.ScoreTeam1 += 1;
                Destroy(GameObject.FindGameObjectWithTag("Ball"), 1);
                SpawnBallManager.Instance.ballInGame = false;
            }

            // Pirate guys complaining animations when a goal happens
            pirateCaptain.GetComponent<Animator>().Play("shakingHeadNoNo");
            pirateOldMan1.GetComponent<Animator>().Play("shakingHeadNoNo");
            pirateOldMan2.GetComponent<Animator>().Play("shakingHeadNoNo");
            pirateOldMan3.GetComponent<Animator>().Play("shakingHeadNoNo");
            pirateCrewSeaman1.GetComponent<Animator>().Play("sittingDisbelief");
            pirateCrewSeaman2.GetComponent<Animator>().Play("shakingHeadNoNo");
            pirateDeckhand1.GetComponent<Animator>().Play("shakingHeadNoNo");
            pirateDeckhand2.GetComponent<Animator>().Play("shakingHeadNoNo");

            // English guys cheering animations when a goal happens
            englishCaptain.GetComponent<Animator>().Play("cheering");
            englishSoldier.GetComponent<Animator>().Play("cheering");
            englishGentleman1.GetComponent<Animator>().Play("cheering");
            englishGentleman2.GetComponent<Animator>().Play("sittingCheering");
            englishGovernor.GetComponent<Animator>().Play("cheering");
            englishGovernorsDaughter.GetComponent<Animator>().Play("cheering");
        }
    }
}
