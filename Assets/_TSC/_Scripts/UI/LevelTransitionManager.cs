using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransitionManager : MonoBehaviour
{
    public static LevelTransitionManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public Animator Animator;
    public float TransitionTime = 2.5f;

    public IEnumerator StartTransition()
    {
        Animator.SetTrigger("Start");
        yield return new WaitForSeconds(TransitionTime);
        SceneManager.LoadScene(2);
    }
    public void EndTransition()
    {
        Animator.SetTrigger("End");
    }
}
