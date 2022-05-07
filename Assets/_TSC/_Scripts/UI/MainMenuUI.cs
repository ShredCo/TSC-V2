using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    // Audio
    [SerializeField] private GameObject audioSlider;
    [SerializeField] private AudioMixer musicMixer;
    
    public void StartGame()
    {
        SceneManager.LoadScene("LoadingScene");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void ShowAudioSlider()
    {
        EventSystem.current.SetSelectedGameObject(audioSlider);
    }
    public void SetMusicAudioLevel(float sliderValue)
    {
        musicMixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 50);
    }
}
