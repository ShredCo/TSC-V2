using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    private void Awake()
    {
        ES3AutoSaveMgr.Current.Load();
    }

    // Audio
    [SerializeField] private GameObject audioSlider;
    [SerializeField] private AudioMixer musicMixer;
    
    public void StartGame()
    {
        SceneManager.LoadScene("LoadingOverworld");
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
