using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GoalPoles : MonoBehaviour
{
    [SerializeField] private List<AudioSource> missedGoalSounds = new List<AudioSource>();

    private int randomSound;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            randomSound = Random.Range(0, 2);
            if (other.gameObject.GetComponent<Rigidbody>().velocity.magnitude > 3)
            {
                missedGoalSounds[randomSound].Play();
            }
        } 
    }
}
