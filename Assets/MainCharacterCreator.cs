using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainCharacterCreator : MonoBehaviour
{
    public Text ChoosedPlayerName;
    [SerializeField] private Text textCurrentIndex;
    [SerializeField] private Text textCurrentBodypart;
    [SerializeField] private MainCharacterManager mainCharacterManager;
    
    [Header("Bodyparts")]
    [SerializeField] private List<GameObject> bodyparts;
    public int CurrentBodypartIndex;
    
    [Header("Gender")]
    [SerializeField] private GameObject maleBody;
    [SerializeField] private GameObject femaleBody;
    private Gender gender;
    
    [Header("Hair")]
    [SerializeField] private List<GameObject> hairtypes;
    [SerializeField] private int currentHairIndex;
    
    [Header("Heads")]
    [SerializeField] private List<GameObject> headsMale;
    [SerializeField] private List<GameObject> headsFemale;
    [SerializeField] private int currentHeadsMaleIndex;
    [SerializeField] private int currentHeadsFemaleIndex;
    
    [Header("Eyebrows")]
    [SerializeField] private List<GameObject> eyebrowsMale;
    [SerializeField] private List<GameObject> eyebrowsFemale;
    [SerializeField] private int currentEyebrowsMaleIndex;
    [SerializeField] private int currentEyebrowsFemaleIndex;
    
    [Header("FacialHair")]
    [SerializeField] private List<GameObject> facialHairMale;
    [SerializeField] private int currentFacialHairMaleIndex;
    
    [Header("UpperBody")]
    [SerializeField] private List<GameObject> upperBodyMale;
    [SerializeField] private List<GameObject> upperBodyFemale;
    [SerializeField] private int currentUpperBodyMaleIndex;
    [SerializeField] private int currentUpperBodyFemaleIndex;
    
    [Header("LowerBody")]
    [SerializeField] private List<GameObject> lowerBodyMale;
    [SerializeField] private List<GameObject> lowerBodyFemale;
    [SerializeField] private int currentLowerBodyMaleIndex;
    [SerializeField] private int currentLowerBodyFemaleIndex;


    public enum Gender { Male, Female }
    public enum Race { Human, Elf }
    public enum SkinColor { White, Brown, Black, Elf }
    public enum Elements {  Yes, No }
    public enum HeadCovering { HeadCoverings_Base_Hair, HeadCoverings_No_FacialHair, HeadCoverings_No_Hair }
    public enum FacialHair { Yes, No }
    
    [Header("Material")]
    public Material mat;
    
    [Header("Skin Colors")]
    public Color[] whiteSkin = { new Color(1f, 0.8000001f, 0.682353f) };
    public Color[] brownSkin = { new Color(0.8196079f, 0.6352941f, 0.4588236f) };
    public Color[] blackSkin = { new Color(0.5647059f, 0.4078432f, 0.3137255f) };
    public Color[] elfSkin = { new Color(0.9607844f, 0.7843138f, 0.7294118f) };

    [Header("Hair Colors")]
    public Color[] whiteHair = { new Color(0.3098039f, 0.254902f, 0.1764706f), new Color(0.2196079f, 0.2196079f, 0.2196079f), new Color(0.8313726f, 0.6235294f, 0.3607843f), new Color(0.8901961f, 0.7803922f, 0.5490196f), new Color(0.8000001f, 0.8196079f, 0.8078432f), new Color(0.6862745f, 0.4f, 0.2352941f), new Color(0.5450981f, 0.427451f, 0.2156863f), new Color(0.8470589f, 0.4666667f, 0.2470588f) };
    public Color whiteStubble = new Color(0.8039216f, 0.7019608f, 0.6313726f);
    public Color[] brownHair = { new Color(0.3098039f, 0.254902f, 0.1764706f), new Color(0.1764706f, 0.1686275f, 0.1686275f), new Color(0.3843138f, 0.2352941f, 0.0509804f), new Color(0.6196079f, 0.6196079f, 0.6196079f), new Color(0.6196079f, 0.6196079f, 0.6196079f) };
    public Color brownStubble = new Color(0.6588235f, 0.572549f, 0.4627451f);
    public Color[] blackHair = { new Color(0.2431373f, 0.2039216f, 0.145098f), new Color(0.1764706f, 0.1686275f, 0.1686275f), new Color(0.1764706f, 0.1686275f, 0.1686275f) };
    public Color blackStubble = new Color(0.3882353f, 0.2901961f, 0.2470588f);
    public Color[] elfHair = { new Color(0.9764706f, 0.9686275f, 0.9568628f), new Color(0.1764706f, 0.1686275f, 0.1686275f), new Color(0.8980393f, 0.7764707f, 0.6196079f) };
    public Color elfStubble = new Color(0.8627452f, 0.7294118f, 0.6862745f);
    
    [Header("Scar Colors")]
    public Color whiteScar = new Color(0.9294118f, 0.6862745f, 0.5921569f);
    public Color brownScar = new Color(0.6980392f, 0.5450981f, 0.4f);
    public Color blackScar = new Color(0.4235294f, 0.3176471f, 0.282353f);
    public Color elfScar = new Color(0.8745099f, 0.6588235f, 0.6313726f);
    
    [Header("Body Art Colors")]
    public Color[] bodyArt = { new Color(0.0509804f, 0.6745098f, 0.9843138f), new Color(0.7215686f, 0.2666667f, 0.2666667f), new Color(0.3058824f, 0.7215686f, 0.6862745f), new Color(0.9254903f, 0.882353f, 0.8509805f), new Color(0.3098039f, 0.7058824f, 0.3137255f), new Color(0.5294118f, 0.3098039f, 0.6470588f), new Color(0.8666667f, 0.7764707f, 0.254902f), new Color(0.2392157f, 0.4588236f, 0.8156863f) };

    
    
    #region Methods -> Back / Use
    public void Use()
    {
        if (CurrentBodypartIndex < bodyparts.Count - 1)
        {
            bodyparts[CurrentBodypartIndex].SetActive(false);
            CurrentBodypartIndex += 1;
            bodyparts[CurrentBodypartIndex].SetActive(true);
            textCurrentBodypart.text = bodyparts[CurrentBodypartIndex].name.ToString();
        }
    }
    public void Back()
    {
        if (CurrentBodypartIndex > 0)
        {
            bodyparts[CurrentBodypartIndex].SetActive(false);
            CurrentBodypartIndex -= 1;
            bodyparts[CurrentBodypartIndex].SetActive(true);
            textCurrentBodypart.text = bodyparts[CurrentBodypartIndex].name.ToString();
        }
    }
   
    #endregion

    #region Methods -> Gender
    public void ChooseMale()
    {
        gender = Gender.Male;
        maleBody.SetActive(true);
        femaleBody.SetActive(false);
    }
    public void ChooseFemale()
    {
        gender = Gender.Female;
        maleBody.SetActive(false);
        femaleBody.SetActive(true);
    }
    #endregion
    
    #region Methods -> Hairs
    public void IndexHairUp()
    {
        if (currentHairIndex < hairtypes.Count - 1)
        {
            hairtypes[currentHairIndex].SetActive(false);
            currentHairIndex += 1;
            hairtypes[currentHairIndex].SetActive(true);
            textCurrentIndex.text = currentHairIndex.ToString();
        }
    }
    public void IndexHairDown()
    {
        if (currentHairIndex > 0)
        {
            hairtypes[currentHairIndex].SetActive(false);
            currentHairIndex -= 1;
            hairtypes[currentHairIndex].SetActive(true);
            textCurrentIndex.text = currentHairIndex.ToString();
        }
    }
    #endregion
    
    #region Methods -> Heads
    public void IndexHeadsUp()
    {
        if (maleBody.active)
        {
            if (currentHeadsMaleIndex < headsMale.Count - 1)
            {
                headsMale[currentHeadsMaleIndex].SetActive(false);
                currentHeadsMaleIndex += 1;
                headsMale[currentHeadsMaleIndex].SetActive(true);
                textCurrentIndex.text = currentHeadsMaleIndex.ToString();
            }
        }
        else if (femaleBody.active)
        {
            if (currentHeadsFemaleIndex < headsFemale.Count - 1)
            {
                headsFemale[currentHeadsFemaleIndex].SetActive(false);
                currentHeadsFemaleIndex += 1;
                headsFemale[currentHeadsFemaleIndex].SetActive(true);
                textCurrentIndex.text = currentHeadsFemaleIndex.ToString();
            }
        }
        
    }
    public void IndexHeadsDown()
    {
        if (maleBody.active)
        {
            if (currentHeadsMaleIndex > 0)
            {
                headsMale[currentHeadsMaleIndex].SetActive(false);
                currentHeadsMaleIndex -= 1;
                headsMale[currentHeadsMaleIndex].SetActive(true);
                textCurrentIndex.text = currentHeadsMaleIndex.ToString();
            }
        }
        else if (femaleBody.active)
        {
            if (currentHeadsFemaleIndex > 0)
            {
                headsFemale[currentHeadsFemaleIndex].SetActive(false);
                currentHeadsFemaleIndex -= 1;
                headsFemale[currentHeadsFemaleIndex].SetActive(true);
                textCurrentIndex.text = currentHeadsFemaleIndex.ToString();
            }
        }
    }
    #endregion
    
    #region Methods -> Eyebrows
    public void IndexEyebrowsUp()
    {
        if (maleBody.active)
        {
            if (currentEyebrowsMaleIndex < eyebrowsMale.Count - 1)
            {
                eyebrowsMale[currentEyebrowsMaleIndex].SetActive(false);
                currentEyebrowsMaleIndex += 1;
                eyebrowsMale[currentEyebrowsMaleIndex].SetActive(true);
                textCurrentIndex.text = currentEyebrowsMaleIndex.ToString();
            }
        }
        else if (femaleBody.active)
        {
            if (currentEyebrowsFemaleIndex < eyebrowsFemale.Count - 1)
            {
                eyebrowsFemale[currentEyebrowsFemaleIndex].SetActive(false);
                currentEyebrowsFemaleIndex += 1;
                eyebrowsFemale[currentEyebrowsFemaleIndex].SetActive(true);
                textCurrentIndex.text = currentEyebrowsFemaleIndex.ToString();
            }
        }
        
    }
    public void IndexEyebrowsDown()
    {
        if (maleBody.active)
        {
            if (currentEyebrowsMaleIndex > 0)
            {
                eyebrowsMale[currentEyebrowsMaleIndex].SetActive(false);
                currentEyebrowsMaleIndex -= 1;
                eyebrowsMale[currentEyebrowsMaleIndex].SetActive(true);
                textCurrentIndex.text = currentEyebrowsMaleIndex.ToString();
            }
        }
        else if (femaleBody.active)
        {
            if (currentEyebrowsFemaleIndex > 0)
            {
                eyebrowsFemale[currentEyebrowsFemaleIndex].SetActive(false);
                currentEyebrowsFemaleIndex -= 1;
                eyebrowsFemale[currentEyebrowsFemaleIndex].SetActive(true);
                textCurrentIndex.text = currentEyebrowsFemaleIndex.ToString();
            }
        }
    }
    #endregion
    
    #region Methods -> FacialHair
    public void IndexFacialHairUp()
    {
        if (maleBody.active)
        {
            if (currentFacialHairMaleIndex < facialHairMale.Count - 1)
            {
                facialHairMale[currentFacialHairMaleIndex].SetActive(false);
                currentFacialHairMaleIndex += 1;
                facialHairMale[currentFacialHairMaleIndex].SetActive(true);
                textCurrentIndex.text = currentFacialHairMaleIndex.ToString();
            }
        }
    }
    public void IndexFacialHairDown()
    {
        if (maleBody.active)
        {
            if (currentFacialHairMaleIndex > 0)
            {
                facialHairMale[currentFacialHairMaleIndex].SetActive(false);
                currentFacialHairMaleIndex -= 1;
                facialHairMale[currentFacialHairMaleIndex].SetActive(true);
                textCurrentIndex.text = currentFacialHairMaleIndex.ToString();
            }
        }
    }
    #endregion
    
    #region Methods -> UpperBody
    public void IndexUpperBodyUp()
    {
        if (maleBody.active)
        {
            if (currentUpperBodyMaleIndex < upperBodyMale.Count - 1)
            {
                upperBodyMale[currentUpperBodyMaleIndex].SetActive(false);
                currentUpperBodyMaleIndex += 1;
                upperBodyMale[currentUpperBodyMaleIndex].SetActive(true);
                textCurrentIndex.text = currentUpperBodyMaleIndex.ToString();
            }
        }
        else if (femaleBody.active)
        {
            if (currentUpperBodyFemaleIndex < upperBodyFemale.Count - 1)
            {
                upperBodyFemale[currentUpperBodyFemaleIndex].SetActive(false);
                currentUpperBodyFemaleIndex += 1;
                upperBodyFemale[currentUpperBodyFemaleIndex].SetActive(true);
                textCurrentIndex.text = currentUpperBodyFemaleIndex.ToString();
            }
        }
        
    }
    public void IndexUpperBodyDown()
    {
        if (maleBody.active)
        {
            if (currentUpperBodyMaleIndex > 0)
            {
                upperBodyMale[currentUpperBodyMaleIndex].SetActive(false);
                currentUpperBodyMaleIndex -= 1;
                upperBodyMale[currentUpperBodyMaleIndex].SetActive(true);
                textCurrentIndex.text = currentUpperBodyMaleIndex.ToString();
            }
        }
        else if (femaleBody.active)
        {
            if (currentUpperBodyFemaleIndex > 0)
            {
                upperBodyFemale[currentUpperBodyFemaleIndex].SetActive(false);
                currentUpperBodyFemaleIndex -= 1;
                upperBodyFemale[currentUpperBodyFemaleIndex].SetActive(true);
                textCurrentIndex.text = currentUpperBodyFemaleIndex.ToString();
            }
        }
    }
    #endregion
    
    #region Methods -> LowerBody
    public void IndexLowerBodyUp()
    {
        if (maleBody.active)
        {
            if (currentLowerBodyMaleIndex < lowerBodyMale.Count - 1)
            {
                lowerBodyMale[currentLowerBodyMaleIndex].SetActive(false);
                currentLowerBodyMaleIndex += 1;
                lowerBodyMale[currentLowerBodyMaleIndex].SetActive(true);
                textCurrentIndex.text = currentLowerBodyMaleIndex.ToString();
            }
        }
        else if (femaleBody.active)
        {
            if (currentLowerBodyFemaleIndex < lowerBodyFemale.Count - 1)
            {
                lowerBodyFemale[currentLowerBodyFemaleIndex].SetActive(false);
                currentLowerBodyFemaleIndex += 1;
                lowerBodyFemale[currentLowerBodyFemaleIndex].SetActive(true);
                textCurrentIndex.text = currentLowerBodyFemaleIndex.ToString();
            }
        }
        
    }
    public void IndexLowerBodyDown()
    {
        if (maleBody.active)
        {
            if (currentLowerBodyMaleIndex > 0)
            {
                lowerBodyMale[currentLowerBodyMaleIndex].SetActive(false);
                currentLowerBodyMaleIndex -= 1;
                lowerBodyMale[currentLowerBodyMaleIndex].SetActive(true);
                textCurrentIndex.text = currentLowerBodyMaleIndex.ToString();
            }
        }
        else if (femaleBody.active)
        {
            if (currentLowerBodyFemaleIndex > 0)
            {
                lowerBodyFemale[currentLowerBodyFemaleIndex].SetActive(false);
                currentLowerBodyFemaleIndex -= 1;
                lowerBodyFemale[currentLowerBodyFemaleIndex].SetActive(true);
                textCurrentIndex.text = currentLowerBodyFemaleIndex.ToString();
            }
        }
    }
    #endregion
}
