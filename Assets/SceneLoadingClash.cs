using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class SceneLoadingClash : MonoBehaviour
{
    [SerializeField] private GameObject[] tipps = new GameObject[11];
    [SerializeField] Image progressBar;
    
    void Start()
    {
        DisplayTipp();
        StartCoroutine(LoadAsyncOperation());
    }

    IEnumerator LoadAsyncOperation()
    {
        // create an async operation
        AsyncOperation gameLevel = SceneManager.LoadSceneAsync("Training Center");

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
