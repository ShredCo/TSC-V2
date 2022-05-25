using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainCharacterCreator : MonoBehaviour
{
    public Text ChoosedPlayerName;
    [SerializeField] private Text textCurrentIndex;
    [SerializeField] private MainCharacterManager mainCharacterManager;
    [SerializeField] [Range(0,10)] private int currentItemIndex;
    
    [Header("Gender")]
    [SerializeField] private GameObject maleBody;
    [SerializeField] private GameObject femaleBody;
    private Gender gender;
    
    
    
    
    public List<GameObject> headgear;
    
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

    
    
    public void IndexUp()
    {
        if (currentItemIndex < 10)
        {
            currentItemIndex += 1;
            textCurrentIndex.text = currentItemIndex.ToString();
        }
    }

    public void IndexDown()
    {
        if (currentItemIndex > 0)
        {
            currentItemIndex -= 1;
            textCurrentIndex.text = currentItemIndex.ToString();
        }
    }

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
}
