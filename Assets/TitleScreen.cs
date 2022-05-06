using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
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
