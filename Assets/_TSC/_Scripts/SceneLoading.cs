using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public enum NextScene
{
    Overworld,
    MainMenu,
    Soccerfield
}
public class SceneLoading : MonoBehaviour
{
    #region Singleton
    public static SceneLoading Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    #endregion
    
    // References
    [SerializeField] GameObject[] tipps = new GameObject[11];
    [SerializeField] Image progressBar;
    public NextScene nextScene;
    
    string scene;
    void Start()
    {
        DisplayTipp();
        StartCoroutine(LoadAsyncOperation());
    }

    IEnumerator LoadAsyncOperation()
    {
        yield return new WaitForSeconds(2);
        // create an async operation
        switch(nextScene)
        {
            case NextScene.MainMenu:
                scene = "MainMenu";
                break;
            case NextScene.Overworld:
                scene = "Overworld";
                break;
        }

        // Loads the right scene
        AsyncOperation gameLevel = SceneManager.LoadSceneAsync(scene);
        while (gameLevel.progress < 1)
        {
            // take the progress bar fill = async operation progress.
            progressBar.fillAmount = gameLevel.progress;
            yield return new WaitForEndOfFrame();
        }
       
        // when finished, load the game scene
        yield return new WaitForEndOfFrame();
    }

    void DisplayTipp()
    {
        // Displays a random tipp on the loading screen
        int randomTipp = Random.Range(0, 10);
        tipps[randomTipp].SetActive(true);
    }
}
