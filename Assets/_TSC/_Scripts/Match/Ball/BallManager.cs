using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using TMPro;

public class BallManager : MonoBehaviour
{
    public static BallManager Instance;
    public GameObject ball;
    public AIController aiController;
    
    public bool ballInGame = false;
    private Vector3 startPos;

    public TextMeshProUGUI CountdownText;
    public GameObject CountdownPanel;

    public AudioSource audioSource;
    public AudioClip Countdown;
    public AudioSource AudioSourceCheering1;
    public AudioSource AudioSourceCheering2;
    public AudioSource AudioSourceCheering3;
    public AudioSource AudioSourceCheering4;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        startPos = new Vector3(0f, 0.42f, -0.837f); // position of the GameObject the script is placed on
        StartCoroutine(SpawnFirstBall());
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

    public IEnumerator SpawnFirstBall()
    {
        ball.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        CountdownPanel.SetActive(true);
        audioSource.clip = Countdown;
        audioSource.Play();
        CountdownText.text = "3";
        yield return new WaitForSeconds(1f);
        CountdownText.text = "2";
        yield return new WaitForSeconds(1f);
        CountdownText.text = "1";
        yield return new WaitForSeconds(1f);
        CountdownPanel.SetActive(false);
        AudioSourceCheering1.Play();
        AudioSourceCheering2.Play();
        AudioSourceCheering3.Play();
        AudioSourceCheering4.Play();
        ball.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
    }
}
