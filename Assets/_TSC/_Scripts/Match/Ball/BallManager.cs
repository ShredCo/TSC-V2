using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using TMPro;

public enum LastPlayerHit { Default, Player, AI }
public class BallManager : MonoBehaviour
{
    #region Singleton
    public static BallManager Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        startPos = new Vector3(0f, 0.42f, -0.837f); // position of the GameObject the script is placed on
        StartCoroutine(SpawnFirstBall());
    }
    #endregion
    
    // References
    [SerializeField] private GameObject ball;
    [SerializeField] private TextMeshProUGUI countdownText;
    [SerializeField] private GameObject countdownPanel;
    
    // Audio
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip countdown;
    [SerializeField] private AudioSource audioSourceCheering1;
    [SerializeField] private AudioSource audioSourceCheering2;
    [SerializeField] private AudioSource audioSourceCheering3;
    [SerializeField] private AudioSource audioSourceCheering4;

    // HUD
    [SerializeField] private GameObject spawnBallIcon;
    
    public bool BallInGame = false;
    private Vector3 startPos;

    private void Update()
    {
        if (BallInGame == false)
        {
            spawnBallIcon.SetActive(true);
        }
        else
        {
            spawnBallIcon.SetActive(false);
        }
    }

    #region Methods -> Spawn Ball
    public void SpawnBallInput(InputAction.CallbackContext context)
    {
        // Ball is only respawnable when a goal happened or he stands almost still, when stuck or something like that.
        if (BallInGame == false || GetComponent<Rigidbody>().velocity.magnitude <= 0.045f)
        {
            SpawnSoccerBall();
            BallInGame = true;
                
        }

        // TODO: Can be commented out when publishing the game (but needed for easier development).
        //SpawnSoccerBall();
    }
    public void SpawnSoccerBall()
    {
        ball.transform.position = startPos;
        BallInGame = true;
    }
    public IEnumerator SpawnFirstBall()
    {
        BallInGame = true;
        ball.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        countdownPanel.SetActive(true);
        audioSource.clip = countdown;
        audioSource.Play();
        countdownText.text = "3";
        yield return new WaitForSeconds(1f);
        countdownText.text = "2";
        yield return new WaitForSeconds(1f);
        countdownText.text = "1";
        yield return new WaitForSeconds(1f);
        countdownPanel.SetActive(false);
        audioSourceCheering1.Play();
        audioSourceCheering2.Play();
        audioSourceCheering3.Play();
        audioSourceCheering4.Play();
        ball.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        
    }
    #endregion
    
    #region Damage to poles
    [SerializeField] PoleCondition poleHealth;
    [SerializeField] LastPlayerHit lastPlayerHit;

    void DealDamage(GameObject other)
    {
        switch (lastPlayerHit)
        {
            case LastPlayerHit.Default:
                break;
            case LastPlayerHit.Player:
                if (other.CompareTag("AIMain"))
                {
                    poleHealth.ConditionAIPole1 -= GetComponent<Rigidbody>().velocity.magnitude;
                }
                else if (other.CompareTag("AICrew1"))
                {
                    poleHealth.ConditionAIPole2 -= GetComponent<Rigidbody>().velocity.magnitude;
                }
                else if (other.CompareTag("AICrew2"))
                {
                    poleHealth.ConditionAIPole3 -= GetComponent<Rigidbody>().velocity.magnitude;
                }
                else if (other.CompareTag("AICrew3"))
                {
                    poleHealth.ConditionAIPole4 -= GetComponent<Rigidbody>().velocity.magnitude;
                }
                break;
            case LastPlayerHit.AI:
                if (other.CompareTag("PlayerMain"))
                {
                    poleHealth.ConditionPole1 -= GetComponent<Rigidbody>().velocity.magnitude;
                }
                else if (other.CompareTag("PlayerCrew1"))
                {
                    poleHealth.ConditionPole2 -= GetComponent<Rigidbody>().velocity.magnitude;
                }
                else if (other.CompareTag("PlayerCrew2"))
                {
                    poleHealth.ConditionPole3 -= GetComponent<Rigidbody>().velocity.magnitude;
                }
                else if (other.CompareTag("PlayerCrew3"))
                {
                    poleHealth.ConditionPole4 -= GetComponent<Rigidbody>().velocity.magnitude;
                }
                break;
            default:
                break;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        DealDamage(collision.gameObject);
        if (collision.gameObject.CompareTag("PlayerMain") || collision.gameObject.CompareTag("PlayerCrew1") || collision.gameObject.CompareTag("PlayerCrew2") || collision.gameObject.CompareTag("PlayerCrew3"))
            lastPlayerHit = LastPlayerHit.Player;
        else if (collision.gameObject.CompareTag("AIMain") || collision.gameObject.CompareTag("AICrew1") || collision.gameObject.CompareTag("AICrew2") || collision.gameObject.CompareTag("AICrew3"))
            lastPlayerHit = LastPlayerHit.AI;
    }
    #endregion
}
