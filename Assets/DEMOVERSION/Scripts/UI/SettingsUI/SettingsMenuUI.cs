using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Audio;


public class SettingsMenuUI : MonoBehaviour
{
    [SerializeField]
    public Text moveSpeedCount;
    [SerializeField]
    private Text rotationSpeedCount;

    [Header("UserInterfaces")]
    public GameObject settingsMenuUI;
    public GameObject pauseMenuUI;

    [Header("Buttons")]
    public GameObject resumeButton;


    [Header("Audio")]
    public AudioMixer musicMixer;
    public AudioMixer ballMixer;

    [Header("Light")]
    public GameObject dayLight;
    public GameObject nightLight;

    // Update is called once per frame
    void Update()
    {
        moveSpeedCount.text = Pole.Instance.moveSpeed.ToString();
        rotationSpeedCount.text = Pole.Instance.rotationSpeed.ToString();
    }

    public void GoBack()
    {
        settingsMenuUI.SetActive(false);
        pauseMenuUI.SetActive(true);

        // clear selected button
        EventSystem.current.SetSelectedGameObject(null);
        // set a new selected object
        EventSystem.current.SetSelectedGameObject(resumeButton);
    }

    public void DecreaseMoveSpeed()
    {
        if(Pole.Instance.moveSpeed > 0)
        {
            Pole.Instance.moveSpeed -= 0.1f;
        }      
    }

    public void IncreaseMoveSpeed()
    {
        if (Pole.Instance.moveSpeed < 3)
        {
            Pole.Instance.moveSpeed += 0.1f;
        }
    }

    public void DecreaseRotationSpeed()
    {
        if (Pole.Instance.rotationSpeed > 0)
        {
            Pole.Instance.rotationSpeed -= 50f;
        }
    }

    public void IncreaseRotationSpeed()
    {
        if (Pole.Instance.rotationSpeed < 3000)
        {
            Pole.Instance.rotationSpeed += 50f;
        }
    }

    public void ChangeTimeToDay()
    {
        dayLight.SetActive(true);
        nightLight.SetActive(false);
    }

    public void ChangeTimeToNight()
    {
        dayLight.SetActive(false);
        nightLight.SetActive(true);
    }


    // changes the volume of the music
    public void SetMusicAudioLevel(float sliderValue)
    {
        musicMixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 50);
    }

    // changes the volume of the music
    public void SetBallAudioLevel(float sliderValue)
    {
        ballMixer.SetFloat("BallVolume", Mathf.Log10(sliderValue) * 50);
    }
}
