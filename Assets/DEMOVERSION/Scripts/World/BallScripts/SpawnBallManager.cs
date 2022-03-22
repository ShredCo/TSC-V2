using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnBallManager : MonoBehaviour
{
    public static SpawnBallManager Instance;

    public GameObject ballObject;
    public bool ballInGame = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        var gamepad = Gamepad.current;

        //Spawns a new Ball or Respawns
        if (gamepad.dpad.up.wasPressedThisFrame)
        {
            
                if (ballInGame == true)
                {
                    Destroy(GameObject.FindGameObjectWithTag("Ball"));
                }
                SpawnBall();
                ballInGame = true;
            
        }
    }

    public void SpawnPrefab(GameObject prefab)
    {
        Instantiate(ballObject, transform.position, transform.rotation);
        ballInGame = true;
    }

    public void SpawnBall()
    {
        if (ballInGame == true)
        {
            Destroy(GameObject.FindGameObjectWithTag("Ball"));
        }
        SpawnPrefab(ballObject);
    }
}
