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
    [SerializeField] GameObject ball;
    //[SerializeField] AIController aiController;
    [SerializeField] TextMeshProUGUI countdownText;
    [SerializeField] GameObject countdownPanel;
    
    // Audio
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip countdown;
    [SerializeField] AudioSource audioSourceCheering1;
    [SerializeField] AudioSource audioSourceCheering2;
    [SerializeField] AudioSource audioSourceCheering3;
    [SerializeField] AudioSource audioSourceCheering4;

    public bool BallInGame = false;
    private Vector3 startPos;

    private void Update()
    {
        var gamepad = Gamepad.current;

        //Spawns a new ball or Respawns
        if (gamepad.dpad.up.wasPressedThisFrame)
        {
            if (BallInGame == false)
            {
                SpawnSoccerBall();
                BallInGame = true;
            }

            // TODO: Can be deleted when publishing the game.
            SpawnSoccerBall();
        }
    }

    #region Methods -> Spawn Ball
    public void SpawnSoccerBall()
    {
        ball.transform.position = startPos;
        BallInGame = true;
    }
    public IEnumerator SpawnFirstBall()
    {
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
    [SerializeField] PoleHealth poleHealth;
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
                    poleHealth.AIHealthMain -= GetComponent<Rigidbody>().velocity.magnitude;
                }
                else if (other.CompareTag("AICrew1"))
                {
                    poleHealth.AIHealthCrew1 -= GetComponent<Rigidbody>().velocity.magnitude;
                }
                else if (other.CompareTag("AICrew2"))
                {
                    poleHealth.AIHealthCrew2 -= GetComponent<Rigidbody>().velocity.magnitude;
                }
                else if (other.CompareTag("AICrew3"))
                {
                    poleHealth.AIHealthCrew3 -= GetComponent<Rigidbody>().velocity.magnitude;
                }
                break;
            case LastPlayerHit.AI:
                if (other.CompareTag("PlayerMain"))
                {
                    poleHealth.PlayerHealthMain -= GetComponent<Rigidbody>().velocity.magnitude;
                }
                else if (other.CompareTag("PlayerCrew1"))
                {
                    poleHealth.PlayerHealthCrew1 -= GetComponent<Rigidbody>().velocity.magnitude;
                }
                else if (other.CompareTag("PlayerCrew2"))
                {
                    poleHealth.PlayerHealthCrew2 -= GetComponent<Rigidbody>().velocity.magnitude;
                }
                else if (other.CompareTag("PlayerCrew3"))
                {
                    poleHealth.PlayerHealthCrew3 -= GetComponent<Rigidbody>().velocity.magnitude;
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
