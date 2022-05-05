using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PoleCondition : MonoBehaviour
{
    #region Health Variables
    // Player poles
    [Header("Player Pole Health")]
    public float PlayerConditionMain;
    private float playerMaxConditionMain;
    public Image ConditionBarPlayerMain;
    public TextMeshProUGUI TextCurrentConditionPlayerMain;
    public TextMeshProUGUI TextMaxConditionPlayerMain;

    public float PlayerConditionCrew1;
    private float playerMaxConditionCrew1;
    public Image ConditionBarPlayerCrew1;
    public TextMeshProUGUI TextCurrentConditionPlayerCrew1;
    public TextMeshProUGUI TextMaxConditionPlayerCrew1;

    public float PlayerConditionCrew2;
    private float playerMaxConditionCrew2;
    public Image ConditionBarPlayerCrew2;
    public TextMeshProUGUI TextCurrentConditionPlayerCrew2;
    public TextMeshProUGUI TextMaxConditionPlayerCrew2;

    public float PlayerConditionCrew3;
    private float playerMaxConditionCrew3;
    public Image ConditionBarPlayerCrew3;
    public TextMeshProUGUI TextCurrentConditionPlayerCrew3;
    public TextMeshProUGUI TextMaxConditionPlayerCrew3;

    // AI poles
    [Header("AI Pole Health")]
    public float AIConditionMain;
    private float AIMaxConditionMain;
    public Image ConditionBarAIMain;
    public TextMeshProUGUI TextCurrentConditionAIMain;
    public TextMeshProUGUI TextMaxConditionAIMain;

    public float AIConditionCrew1;
    private float AIMaxConditionCrew1;
    public Image ConditionBarAICrew1;
    public TextMeshProUGUI TextCurrentConditionAICrew1;
    public TextMeshProUGUI TextMaxConditionAICrew1;

    public float AIConditionCrew2;
    private float AIMaxConditionCrew2;
    public Image ConditionBarAICrew2;
    public TextMeshProUGUI TextCurrentConditionAICrew2;
    public TextMeshProUGUI TextMaxConditionAICrew2;

    public float AIConditionCrew3;
    private float AIMaxConditionCrew3;
    public Image ConditionBarAICrew3;
    public TextMeshProUGUI TextCurrentConditionAICrew3;
    public TextMeshProUGUI TextMaxConditionAICrew3;
    #endregion

    #region Pole GameObjects
    // Player
    public GameObject PlayerPoleMain;
    public GameObject PlayerPoleCrew1;
    public GameObject PlayerPoleCrew2;
    public GameObject PlayerPoleCrew3;

    // AI
    public GameObject AIPoleMain;
    public GameObject AIPoleCrew1;
    public GameObject AIPoleCrew2;
    public GameObject AIPoleCrew3;
    #endregion

    public TextMeshProUGUI TextPowerpointsPlayer;
    public TextMeshProUGUI TextPowerpointsEnemy;

    float lerpSpeed = 3f;

    void Start()
    {
        GetPoleCondition();
    }
    void Update()
    {
        UpdateConditionText();
        UpdateCondition();
        ChangeColor();
        PoleChangeColor();
        UpdatePowerpointText();
    }

    void GetPoleCondition()
    {
        // Player poles
        PlayerConditionMain = LineUpController.PlayerDefaultCardLineUP[0].Condition;
        playerMaxConditionMain = LineUpController.PlayerDefaultCardLineUP[0].MaxCondition;
        PlayerConditionCrew1 = LineUpController.PlayerDefaultCardLineUP[1].Condition;
        playerMaxConditionCrew1 = LineUpController.PlayerDefaultCardLineUP[1].MaxCondition;
        PlayerConditionCrew2 = LineUpController.PlayerDefaultCardLineUP[2].Condition;
        playerMaxConditionCrew2 = LineUpController.PlayerDefaultCardLineUP[2].MaxCondition;
        PlayerConditionCrew3 = LineUpController.PlayerDefaultCardLineUP[3].Condition;
        playerMaxConditionCrew3 = LineUpController.PlayerDefaultCardLineUP[3].MaxCondition;

        // AI poles
        AIConditionMain = LineUpController.AIDefaultCardLineUP[0].Condition;
        AIMaxConditionMain = LineUpController.AIDefaultCardLineUP[0].MaxCondition;
        AIConditionCrew1 = LineUpController.AIDefaultCardLineUP[1].Condition;
        AIMaxConditionCrew1 = LineUpController.AIDefaultCardLineUP[1].MaxCondition;
        AIConditionCrew2 = LineUpController.AIDefaultCardLineUP[2].Condition;
        AIMaxConditionCrew2 = LineUpController.AIDefaultCardLineUP[2].MaxCondition;
        AIConditionCrew3 = LineUpController.AIDefaultCardLineUP[3].Condition;
        AIMaxConditionCrew3 = LineUpController.AIDefaultCardLineUP[3].MaxCondition;
    }

    public void SavePoleHealth()
    {
        LineUpController.PlayerDefaultCardLineUP[0].Condition = PlayerConditionMain;
        LineUpController.PlayerDefaultCardLineUP[1].Condition = PlayerConditionCrew1;
        LineUpController.PlayerDefaultCardLineUP[2].Condition = PlayerConditionCrew2;
        LineUpController.PlayerDefaultCardLineUP[3].Condition = PlayerConditionCrew3;
    }

    #region Poles GameObjects

    void PoleChangeColor()
    {
        // Player
        PlayerPoleMain.GetComponent<Renderer>().material.color = Color.Lerp(Color.grey, Color.red, (PlayerConditionMain / playerMaxConditionMain));
        PlayerPoleCrew1.GetComponent<Renderer>().material.color = Color.Lerp(Color.grey, Color.red, (PlayerConditionCrew1 / playerMaxConditionCrew1));
        PlayerPoleCrew2.GetComponent<Renderer>().material.color = Color.Lerp(Color.grey, Color.red, (PlayerConditionCrew2 / playerMaxConditionCrew2));
        PlayerPoleCrew3.GetComponent<Renderer>().material.color = Color.Lerp(Color.grey, Color.red, (PlayerConditionCrew3 / playerMaxConditionCrew3));

        // AI
        AIPoleMain.GetComponent<Renderer>().material.color = Color.Lerp(Color.grey, Color.blue, (AIConditionMain / AIMaxConditionMain));
        AIPoleCrew1.GetComponent<Renderer>().material.color = Color.Lerp(Color.grey, Color.blue, (AIConditionCrew1 / AIMaxConditionCrew1));
        AIPoleCrew2.GetComponent<Renderer>().material.color = Color.Lerp(Color.grey, Color.blue, (AIConditionCrew2 / AIMaxConditionCrew2));
        AIPoleCrew3.GetComponent<Renderer>().material.color = Color.Lerp(Color.grey, Color.blue, (AIConditionCrew3 / AIMaxConditionCrew3));
    }

    #endregion

    #region UI
    void UpdatePowerpointText()
    {
        TextPowerpointsPlayer.text = GameManagerSoccermatch.Instance.powerpointsCountRed.ToString();
        TextPowerpointsEnemy.text = GameManagerSoccermatch.Instance.powerpointsCountBlue.ToString();
    }

    void UpdateConditionText()
    {
        // Player
        TextCurrentConditionPlayerMain.text = Mathf.Clamp(Mathf.Round(PlayerConditionMain), 0f, playerMaxConditionMain).ToString();
        TextCurrentConditionPlayerCrew1.text = Mathf.Clamp(Mathf.Round(PlayerConditionCrew1), 0f, playerMaxConditionCrew1).ToString();                                          
        TextCurrentConditionPlayerCrew2.text = Mathf.Clamp(Mathf.Round(PlayerConditionCrew2), 0f, playerMaxConditionCrew2).ToString();                                          
        TextCurrentConditionPlayerCrew3.text = Mathf.Clamp(Mathf.Round(PlayerConditionCrew3), 0f, playerMaxConditionCrew3).ToString();

        // AI
        TextCurrentConditionAIMain.text = Mathf.Clamp(Mathf.Round(AIConditionMain), 0f, AIMaxConditionMain).ToString();
        TextCurrentConditionAICrew1.text = Mathf.Clamp(Mathf.Round(AIConditionCrew1), 0f, AIMaxConditionCrew1).ToString();
        TextCurrentConditionAICrew2.text = Mathf.Clamp(Mathf.Round(AIConditionCrew2), 0f, AIMaxConditionCrew2).ToString();
        TextCurrentConditionAICrew3.text = Mathf.Clamp(Mathf.Round(AIConditionCrew3), 0f, AIMaxConditionCrew3).ToString();
    }

    void UpdateCondition()
    {
        // Player
        ConditionBarPlayerMain.fillAmount = Mathf.Lerp(ConditionBarPlayerMain.fillAmount, PlayerConditionMain / playerMaxConditionMain, lerpSpeed * Time.deltaTime);
        ConditionBarPlayerCrew1.fillAmount = Mathf.Lerp(ConditionBarPlayerCrew1.fillAmount, PlayerConditionCrew1 / playerMaxConditionCrew1, lerpSpeed * Time.deltaTime);
        ConditionBarPlayerCrew2.fillAmount = Mathf.Lerp(ConditionBarPlayerCrew2.fillAmount, PlayerConditionCrew2 / playerMaxConditionCrew2, lerpSpeed * Time.deltaTime);
        ConditionBarPlayerCrew3.fillAmount = Mathf.Lerp(ConditionBarPlayerCrew3.fillAmount, PlayerConditionCrew3 / playerMaxConditionCrew3, lerpSpeed * Time.deltaTime);

        // AI
        ConditionBarAIMain.fillAmount = Mathf.Lerp(ConditionBarAIMain.fillAmount, AIConditionMain / AIMaxConditionMain, lerpSpeed * Time.deltaTime);
        ConditionBarAICrew1.fillAmount = Mathf.Lerp(ConditionBarAICrew1.fillAmount, AIConditionCrew1 / AIMaxConditionCrew1, lerpSpeed * Time.deltaTime);
        ConditionBarAICrew2.fillAmount = Mathf.Lerp(ConditionBarAICrew2.fillAmount, AIConditionCrew2 / AIMaxConditionCrew2, lerpSpeed * Time.deltaTime);
        ConditionBarAICrew3.fillAmount = Mathf.Lerp(ConditionBarAICrew3.fillAmount, AIConditionCrew3 / AIMaxConditionCrew3, lerpSpeed * Time.deltaTime);
    }

    void ChangeColor()
    {
        // Player
        ConditionBarPlayerMain.color = Color.Lerp(Color.grey, Color.red, (PlayerConditionMain / playerMaxConditionMain));
        ConditionBarPlayerCrew1.color = Color.Lerp(Color.grey, Color.red, (PlayerConditionCrew1 / playerMaxConditionCrew1));
        ConditionBarPlayerCrew2.color = Color.Lerp(Color.grey, Color.red, (PlayerConditionCrew2 / playerMaxConditionCrew2));
        ConditionBarPlayerCrew3.color = Color.Lerp(Color.grey, Color.red, (PlayerConditionCrew3 / playerMaxConditionCrew3));

        // AI
        ConditionBarAIMain.color = Color.Lerp(Color.grey, Color.red, (AIConditionMain / AIMaxConditionMain));
        ConditionBarAICrew1.color = Color.Lerp(Color.grey, Color.red, (AIConditionCrew1 / AIMaxConditionCrew1));
        ConditionBarAICrew2.color = Color.Lerp(Color.grey, Color.red, (AIConditionCrew2 / AIMaxConditionCrew2));
        ConditionBarAICrew3.color = Color.Lerp(Color.grey, Color.red, (AIConditionCrew3 / AIMaxConditionCrew3));
    }
    #endregion

    #region Player take damage
    public void PlayerMainTakeDamage()
    {
        PlayerConditionMain -= 20;
    }

    public void PlayerCrew1TakeDamage()
    {
        PlayerConditionCrew1 -= 20;
    }

    public void PlayerCrew2TakeDamage()
    {
        PlayerConditionCrew2 -= 20;
    }

    public void PlayerCrew3TakeDamage()
    {
        PlayerConditionCrew3 -= 20;
    }
    #endregion

    #region AI  take damage
    public void AIMainTakeDamage()
    {
        AIConditionMain -= 20;
    }

    public void AICrew1TakeDamage()
    {
        AIConditionCrew1 -= 20;
    }

    public void AICrew2TakeDamage()
    {
        AIConditionCrew2 -= 20;
    }

    public void AICrew3TakeDamage()
    {
        AIConditionCrew3 -= 20;
    }
    #endregion
}
