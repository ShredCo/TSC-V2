using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public GameObject FirstSelectedButton;

    public void StartGame()
    {
        SceneManager.LoadScene("LoadingScene");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
