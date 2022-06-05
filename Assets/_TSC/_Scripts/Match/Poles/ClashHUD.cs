using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClashHUD : MonoBehaviour
{
    #region Health Variables
    [Header("Player Pole Health")]
    // Pole 1
    public Image ConditionBarPole1;
    public TextMeshProUGUI TextCurrentConditionPole1;
    public TextMeshProUGUI TextMaxConditionPole1;
    public float ConditionPole1;
    private float maxConditionPole1;
    // Pole 2
    public Image ConditionBarPole2;
    public TextMeshProUGUI TextCurrentConditionPole2;
    public TextMeshProUGUI TextMaxConditionPole2;
    public float ConditionPole2;
    private float maxConditionPole2;
    // Pole 3
    public Image ConditionBarPole3;
    public TextMeshProUGUI TextCurrentConditionPole3;
    public TextMeshProUGUI TextMaxConditionPole3;
    public float ConditionPole3;
    private float maxConditionPole3;
    // Pole 4
    public Image ConditionBarPole4;
    public TextMeshProUGUI TextCurrentConditionPole4;
    public TextMeshProUGUI TextMaxConditionPole4;
    public float ConditionPole4;
    private float maxConditionPole4;
    
    [Header("AI Pole Health")]
    // AI Pole 1
    public Image ConditionBarAIPole1;
    public TextMeshProUGUI TextCurrentConditionAIPole1;
    public TextMeshProUGUI TextMaxConditionAIPole1;
    public float ConditionAIPole1;
    private float maxConditionAIPole1;
    // AI Pole 2
    public Image ConditionBarAIPole2;
    public TextMeshProUGUI TextCurrentConditionAIPole2;
    public TextMeshProUGUI TextMaxConditionAIPole2;
    public float ConditionAIPole2;
    private float maxConditionAIPole2;
    // AI Pole 3
    public Image ConditionBarAIPole3;
    public TextMeshProUGUI TextCurrentConditionAIPole3;
    public TextMeshProUGUI TextMaxConditionAIPole3;
    public float ConditionAIPole3;
    private float maxConditionAIPole3;
    // AI Pole 4
    public Image ConditionBarAIPole4;
    public TextMeshProUGUI TextCurrentConditionAIPole4;
    public TextMeshProUGUI TextMaxConditionAIPole4;
    public float ConditionAIPole4;
    private float maxConditionAIPole4;
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

    public TextMeshProUGUI TextPowerpointsRed;
    public TextMeshProUGUI TextPowerpointsBlue;
    
    
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
        ConditionPole1 = LineUpController.PlayerDefaultCardLineUP[0].Condition;
        maxConditionPole1 = LineUpController.PlayerDefaultCardLineUP[0].MaxCondition;
        ConditionPole2 = LineUpController.PlayerDefaultCardLineUP[1].Condition;
        maxConditionPole2 = LineUpController.PlayerDefaultCardLineUP[1].MaxCondition;
        ConditionPole3 = LineUpController.PlayerDefaultCardLineUP[2].Condition;
        maxConditionPole3 = LineUpController.PlayerDefaultCardLineUP[2].MaxCondition;
        ConditionPole4 = LineUpController.PlayerDefaultCardLineUP[3].Condition;
        maxConditionPole4 = LineUpController.PlayerDefaultCardLineUP[3].MaxCondition;

        // AI poles
        ConditionAIPole1 = LineUpController.AIDefaultCardLineUP[0].Condition;
        maxConditionAIPole1 = LineUpController.AIDefaultCardLineUP[0].MaxCondition;
        ConditionAIPole2 = LineUpController.AIDefaultCardLineUP[1].Condition;
        maxConditionAIPole2 = LineUpController.AIDefaultCardLineUP[1].MaxCondition;
        ConditionAIPole3 = LineUpController.AIDefaultCardLineUP[2].Condition;
        maxConditionAIPole3 = LineUpController.AIDefaultCardLineUP[2].MaxCondition;
        ConditionAIPole4 = LineUpController.AIDefaultCardLineUP[3].Condition;
        maxConditionAIPole4 = LineUpController.AIDefaultCardLineUP[3].MaxCondition;
    }

    public void SavePoleHealth()
    {
        LineUpController.PlayerDefaultCardLineUP[0].Condition = ConditionPole1;
        LineUpController.PlayerDefaultCardLineUP[1].Condition = ConditionPole2;
        LineUpController.PlayerDefaultCardLineUP[2].Condition = ConditionPole3;
        LineUpController.PlayerDefaultCardLineUP[3].Condition = ConditionPole4;
    }

    #region Poles GameObjects

    void PoleChangeColor()
    {
        // Player
        //PlayerPoleMain.GetComponent<Renderer>().material.color = Color.Lerp(Color.black, new Color(0.6705f, 0.3176f, 0.3176f), (ConditionPole1 / maxConditionPole1));
        //PlayerPoleCrew1.GetComponent<Renderer>().material.color = Color.Lerp(Color.black, new Color(0.6705f, 0.3176f, 0.3176f), (ConditionPole2 / maxConditionPole2));
        //PlayerPoleCrew2.GetComponent<Renderer>().material.color = Color.Lerp(Color.black, new Color(0.6705f, 0.3176f, 0.3176f), (ConditionPole3 / maxConditionPole3));
        //PlayerPoleCrew3.GetComponent<Renderer>().material.color = Color.Lerp(Color.black, new Color(0.6705f, 0.3176f, 0.3176f), (ConditionPole4 / maxConditionPole4));

        // AI
        //AIPoleMain.GetComponent<Renderer>().material.color = Color.Lerp(Color.black, new Color(0.3066038f, 0.3803922f, 1f), (ConditionAIPole1 / maxConditionAIPole1));
        //AIPoleCrew1.GetComponent<Renderer>().material.color = Color.Lerp(Color.black, new Color(0.3066038f, 0.3803922f, 1f), (ConditionAIPole2 / maxConditionAIPole2));
        //AIPoleCrew2.GetComponent<Renderer>().material.color = Color.Lerp(Color.black, new Color(0.3066038f, 0.3803922f, 1f), (ConditionAIPole3 / maxConditionAIPole3));
        //AIPoleCrew3.GetComponent<Renderer>().material.color = Color.Lerp(Color.black, new Color(0.3066038f, 0.3803922f, 1f), (ConditionAIPole4 / maxConditionAIPole4));
    }

    #endregion

    #region UI
    void UpdatePowerpointText()
    {
        TextPowerpointsRed.text = GameManagerClash.Instance.powerpointsCountRed.ToString();
        TextPowerpointsBlue.text = GameManagerClash.Instance.powerpointsCountBlue.ToString();
    }

    void UpdateConditionText()
    {
        // Player
        TextCurrentConditionPole1.text = Mathf.Clamp(Mathf.Round(ConditionPole1), 0f, maxConditionPole1).ToString();
        TextCurrentConditionPole2.text = Mathf.Clamp(Mathf.Round(ConditionPole2), 0f, maxConditionPole2).ToString();                                          
        TextCurrentConditionPole3.text = Mathf.Clamp(Mathf.Round(ConditionPole3), 0f, maxConditionPole3).ToString();                                          
        TextCurrentConditionPole4.text = Mathf.Clamp(Mathf.Round(ConditionPole4), 0f, maxConditionPole4).ToString();

        // AI
        TextCurrentConditionAIPole1.text = Mathf.Clamp(Mathf.Round(ConditionAIPole1), 0f, maxConditionAIPole1).ToString();
        TextCurrentConditionAIPole2.text = Mathf.Clamp(Mathf.Round(ConditionAIPole2), 0f, maxConditionAIPole2).ToString();
        TextCurrentConditionAIPole3.text = Mathf.Clamp(Mathf.Round(ConditionAIPole3), 0f, maxConditionAIPole3).ToString();
        TextCurrentConditionAIPole4.text = Mathf.Clamp(Mathf.Round(ConditionAIPole4), 0f, maxConditionAIPole4).ToString();
    }

    void UpdateCondition()
    {
        // Player
        ConditionBarPole1.fillAmount = Mathf.Lerp(ConditionBarPole1.fillAmount, ConditionPole1 / maxConditionPole1, lerpSpeed * Time.deltaTime);
        ConditionBarPole2.fillAmount = Mathf.Lerp(ConditionBarPole2.fillAmount, ConditionPole2 / maxConditionPole2, lerpSpeed * Time.deltaTime);
        ConditionBarPole3.fillAmount = Mathf.Lerp(ConditionBarPole3.fillAmount, ConditionPole3 / maxConditionPole3, lerpSpeed * Time.deltaTime);
        ConditionBarPole4.fillAmount = Mathf.Lerp(ConditionBarPole4.fillAmount, ConditionPole4 / maxConditionPole4, lerpSpeed * Time.deltaTime);

        // AI
        ConditionBarAIPole1.fillAmount = Mathf.Lerp(ConditionBarAIPole1.fillAmount, ConditionAIPole1 / maxConditionAIPole1, lerpSpeed * Time.deltaTime);
        ConditionBarAIPole2.fillAmount = Mathf.Lerp(ConditionBarAIPole2.fillAmount, ConditionAIPole2 / maxConditionAIPole2, lerpSpeed * Time.deltaTime);
        ConditionBarAIPole3.fillAmount = Mathf.Lerp(ConditionBarAIPole3.fillAmount, ConditionAIPole3 / maxConditionAIPole3, lerpSpeed * Time.deltaTime);
        ConditionBarAIPole4.fillAmount = Mathf.Lerp(ConditionBarAIPole4.fillAmount, ConditionAIPole4 / maxConditionAIPole4, lerpSpeed * Time.deltaTime);
    }

    void ChangeColor()
    {
        
        // Player Red
        ConditionBarPole1.color = Color.Lerp(Color.grey, new Color(0.6705f, 0.3176f, 0.3176f), (ConditionPole1 / maxConditionPole1));
        ConditionBarPole2.color = Color.Lerp(Color.grey, new Color(0.6705f, 0.3176f, 0.3176f), (ConditionPole2 / maxConditionPole2));
        ConditionBarPole3.color = Color.Lerp(Color.grey, new Color(0.6705f, 0.3176f, 0.3176f), (ConditionPole3 / maxConditionPole3));
        ConditionBarPole4.color = Color.Lerp(Color.grey, new Color(0.6705f, 0.3176f, 0.3176f), (ConditionPole4 / maxConditionPole4));

        // Player Blue
        ConditionBarAIPole1.color = Color.Lerp(Color.grey, new Color(0.1215f, 0.1921f, 0.8392f), (ConditionAIPole1 / maxConditionAIPole1));
        ConditionBarAIPole2.color = Color.Lerp(Color.grey, new Color(0.1215f, 0.1921f, 0.8392f), (ConditionAIPole2 / maxConditionAIPole2));
        ConditionBarAIPole3.color = Color.Lerp(Color.grey, new Color(0.1215f, 0.1921f, 0.8392f), (ConditionAIPole3 / maxConditionAIPole3));
        ConditionBarAIPole4.color = Color.Lerp(Color.grey, new Color(0.1215f, 0.1921f, 0.8392f), (ConditionAIPole4 / maxConditionAIPole4));
    }
    #endregion

    #region Player take damage
    public void PlayerMainTakeDamage()
    {
        ConditionPole1 -= 20;
    }

    public void PlayerCrew1TakeDamage()
    {
        ConditionPole2 -= 20;
    }

    public void PlayerCrew2TakeDamage()
    {
        ConditionPole3 -= 20;
    }

    public void PlayerCrew3TakeDamage()
    {
        ConditionPole4 -= 20;
    }
    #endregion

    #region AI  take damage
    public void AIMainTakeDamage()
    {
        ConditionAIPole1 -= 20;
    }

    public void AICrew1TakeDamage()
    {
        ConditionAIPole2 -= 20;
    }

    public void AICrew2TakeDamage()
    {
        ConditionAIPole3 -= 20;
    }

    public void AICrew3TakeDamage()
    {
        ConditionAIPole4 -= 20;
    }
    #endregion
}
