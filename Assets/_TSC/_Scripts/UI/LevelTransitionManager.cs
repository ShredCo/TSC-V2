using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransitionManager : MonoBehaviour
{
    #region Singleton
    public static LevelTransitionManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion

    #region Variables / References
    public Animator Animator;
    public float TransitionTime = 2.5f;
    #endregion

    #region Functions
    public IEnumerator StartTransition()
    {
        Animator.SetTrigger("Start");
        yield return new WaitForSeconds(TransitionTime);
        GameObject.FindGameObjectWithTag("DialogueManager").GetComponent<DialogueManager>().dialogueStarted = false;
        SceneManager.LoadScene(4);
    }
    public void EndTransition()
    {
        Animator.SetTrigger("End");
    }
    #endregion
}
