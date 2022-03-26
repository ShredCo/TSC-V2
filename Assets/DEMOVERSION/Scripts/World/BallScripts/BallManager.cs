using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class BallManager : MonoBehaviour
{
    public static BallManager Instance;
    public GameObject ball;

    public bool ballInGame = false;
    private Vector3 startPos;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        ballInGame = false;
        startPos = new Vector3(0f, 0.42f, -0.837f); // position of the GameObject the script is placed on
        print(startPos);
    }

    private void Update()
    {
        var gamepad = Gamepad.current;

        //Spawns a new Ball or Respawns
        if (gamepad.dpad.up.wasPressedThisFrame)
        {
            if (ballInGame == false)
            {
                SpawnSoccerBall();
                ballInGame = true;
            }
           
            // only for testing reason here. -> Can be deletet
            SpawnSoccerBall();
        }
    }

    public void SpawnSoccerBall()
    {
        ball.transform.position = startPos;
        ballInGame = true;
    }
}
