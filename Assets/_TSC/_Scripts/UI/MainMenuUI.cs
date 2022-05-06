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
        StartCoroutine(StartGameDelay());
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator StartGameDelay()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(3);
    }
}
