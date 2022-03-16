using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlayManager : MonoBehaviour
{
    [Header("Audio")]
    public AudioMixer mixer;

    [Header("Inventory")]
    public Inventory myInventory;

    [Header("UserInterface")]
    public GameObject mainPlayPanel;
    public GameObject oneVsOnePanel;
    public GameObject twoVsTwoPanel;
    public GameObject settingsScreenPanel;
    public GameObject readMePanel;

    [Header("Buttons")]
    public GameObject singlePlayerButton;
    public GameObject goBackFromOneVsOneChooseMapButton;
    public GameObject goBackFromTwoVsTwoChooseMapButton;
    public GameObject goBackFromSettingsButton;
    public GameObject goBackFromReadMeButton;

    #region Play Canvas Methods
    public void PlaySingleplayer()
    {
        SceneManager.LoadScene(1);
    }

    public void PlayOneVsOne()
    {
        mainPlayPanel.SetActive(false);
        oneVsOnePanel.SetActive(true);

        // clear selected button
        EventSystem.current.SetSelectedGameObject(null);
        // set a new selected object
        EventSystem.current.SetSelectedGameObject(goBackFromOneVsOneChooseMapButton);
    }

    public void PlayTwoVsTwo()
    {
        mainPlayPanel.SetActive(false);
        twoVsTwoPanel.SetActive(true);

        // clear selected button
        EventSystem.current.SetSelectedGameObject(null);
        // set a new selected object
        EventSystem.current.SetSelectedGameObject(goBackFromTwoVsTwoChooseMapButton);
    }

    public void QuitGame()
    {
        Debug.Log("runs Quit Game Method");
        Application.Quit();
    }

    public void LoadSettingsScreen()
    {
        mainPlayPanel.SetActive(false);
        settingsScreenPanel.SetActive(true);

        // clear selected button
        EventSystem.current.SetSelectedGameObject(null);
        // set a new selected object
        EventSystem.current.SetSelectedGameObject(goBackFromSettingsButton);
    }

    public void LoadReadMeScreen()
    {
        mainPlayPanel.SetActive(false);
        readMePanel.SetActive(true);

        // clear selected button
        EventSystem.current.SetSelectedGameObject(null);
        // set a new selected object
        EventSystem.current.SetSelectedGameObject(goBackFromReadMeButton);
    }

    public void GoBackToMainPlayPanel()
    {
        mainPlayPanel.SetActive(true);
        settingsScreenPanel.SetActive(false);
        readMePanel.SetActive(false);
        oneVsOnePanel.SetActive(false);
        twoVsTwoPanel.SetActive(false);


        // clear selected button
        EventSystem.current.SetSelectedGameObject(null);
        // set a new selected object
        EventSystem.current.SetSelectedGameObject(singlePlayerButton);
    }
    #endregion

    #region One Vs One Map Selection Methods
    public void OneVsOneChooseSamuraiMap()
    {
        SceneManager.LoadScene(2);
    }
    public void OneVsOneChoosePirateMap()
    {
        SceneManager.LoadScene(3);
    }
    #endregion

    #region Two Vs Two Map Selection Methods
    public void TwoVsTwoChooseSamuraiMap()
    {
        SceneManager.LoadScene(4);
    }
    public void TwoVsTwoChoosePirateMap()
    {
        SceneManager.LoadScene(5);
    }
    #endregion

    #region Settings
    // changes the volume of the music
    public void SetLevel(float sliderValue)
    {
        mixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);
    }
    #endregion
}
