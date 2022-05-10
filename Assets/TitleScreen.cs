using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void LoadMainMenu()
    {
      StartCoroutine(LoadMenu());
    }

    public IEnumerator LoadMenu()
    {
       yield return new WaitForSeconds(1.5f);
       SceneManager.LoadScene(1);
    }
}
