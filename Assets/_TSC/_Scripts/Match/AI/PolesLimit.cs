using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolesLimit : MonoBehaviour
{
    // Enemy Poles
    //public Rigidbody rbAIMainPole;
    //public Rigidbody rbAICrewPole1;
    public GameObject AICrewPole2;
    public Rigidbody rbAICrewPole2;
    //public Rigidbody rbAICrewPole3;

    // Player Poles
    //public Rigidbody rbPlayerMainPole;
    //public Rigidbody rbPlayerCrewPole1;
    //public Rigidbody rbPlayerCrewPole2;
    //public Rigidbody rbPlayerCrewPole3;

    private void Start()
    {
        // Get Enemy Poles Rigidbody
        //rbAIMainPole = rbAIMainPole.GetComponent<Rigidbody>();
        //rbAICrewPole1 = rbAICrewPole1.GetComponent<Rigidbody>();
        rbAICrewPole2 = AICrewPole2.GetComponent<Rigidbody>();
        //rbAICrewPole3 = rbAICrewPole3.GetComponent<Rigidbody>();

        //// Get Player Poles Rigidbody
        //rbPlayerMainPole = rbPlayerMainPole.GetComponent<Rigidbody>();
        //rbPlayerCrewPole1 = rbPlayerCrewPole1.GetComponent<Rigidbody>();
        //rbPlayerCrewPole2 = rbPlayerCrewPole2.GetComponent<Rigidbody>();
        //rbPlayerCrewPole3 = rbPlayerCrewPole3.GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Sets the default position and z - limit - range for the poles

        //// Main Pole
        //rbAIMainPole.transform.position = new Vector3(Mathf.Clamp(rbAIMainPole.transform.position.x, -0.7f, -0.7f), Mathf.Clamp(rbAIMainPole.transform.position.y, 0.1116f, 0.1116f), Mathf.Clamp(rbAIMainPole.transform.position.z, -0.25f, 0.25f));
        //// Crew Pole 1
        //rbAICrewPole1.transform.position = new Vector3(Mathf.Clamp(rbAICrewPole1.transform.position.x, -0.5f, -0.5f), Mathf.Clamp(rbAICrewPole1.transform.position.y, 0.1116f, 0.1116f), Mathf.Clamp(rbAICrewPole1.transform.position.z, -0.25f, 0.25f));
        // Crew Pole 2
        rbAICrewPole2.transform.position = new Vector3(Mathf.Clamp(transform.position.x, -0.1f, -0.1f), Mathf.Clamp(transform.position.y, 0.1116f, 0.1116f), Mathf.Clamp(transform.position.z, -0.1f, 0.1f));
        //// Crew Pole 3
        //rbAICrewPole3.transform.position = new Vector3(Mathf.Clamp(rbAICrewPole3.transform.position.x, 0.3f, 0.3f), Mathf.Clamp(rbAICrewPole3.transform.position.y, 0.1116f, 0.1116f), Mathf.Clamp(rbAICrewPole3.transform.position.z, -0.15f, 0.15f));


        //// Main Pole
        //rbPlayerMainPole.transform.position = new Vector3(Mathf.Clamp(rbPlayerMainPole.transform.position.x, 0.7f, 0.7f), Mathf.Clamp(rbPlayerMainPole.transform.position.y, 0.1116f, 0.1116f), Mathf.Clamp(rbPlayerMainPole.transform.position.z, -0.25f, 0.25f));
        //// Crew Pole 1
        //rbPlayerCrewPole1.transform.position = new Vector3(Mathf.Clamp(rbPlayerCrewPole1.transform.position.x, 0.5f, 0.5f), Mathf.Clamp(rbPlayerCrewPole1.transform.position.y, 0.1116f, 0.1116f), Mathf.Clamp(rbPlayerCrewPole1.transform.position.z, -0.25f, 0.25f));
        //// Crew Pole 2
        //rbPlayerCrewPole2.transform.position = new Vector3(Mathf.Clamp(rbPlayerCrewPole2.transform.position.x, 0.1f, 0.1f), Mathf.Clamp(rbPlayerCrewPole2.transform.position.y, 0.1116f, 0.1116f), Mathf.Clamp(rbPlayerCrewPole2.transform.position.z, -0.1f, 0.1f));
        //// Crew Pole 3
        //rbPlayerCrewPole3.transform.position = new Vector3(Mathf.Clamp(rbPlayerCrewPole3.transform.position.x, -0.3f, -0.3f), Mathf.Clamp(rbPlayerCrewPole3.transform.position.y, 0.1116f, 0.1116f), Mathf.Clamp(rbPlayerCrewPole3.transform.position.z, -0.15f, 0.15f));
    }
}

