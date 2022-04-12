using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PolesAI : MonoBehaviour
{
    public CrewPole1AI MainPoleAI;
    public CrewPole1AI CrewPole1AI;
    public CrewPole1AI CrewPole2AI;
    public CrewPole1AI CrewPole3AI;

   //public GameObject TriggerboxMain;
   //public GameObject Triggerbox1;
   //public GameObject Triggerbox2;
   //public GameObject Triggerbox3;
    
    // Gives the value how much we want it to rotate
    private Quaternion loadingAngle = Quaternion.Euler(0f, 0f, -45f);
    private Quaternion shotAngle = Quaternion.Euler(0f, 0f, 45f);
    public Quaternion currentAngle;

    // Difficulty
    public float LoadingSpeed = 0.5f;
    public float ShotSpeed = 0.3f;
    
    
}
