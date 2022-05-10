
using UnityEngine;
using UnityEngine.InputSystem;
public class AxHit : MonoBehaviour
{
    //Array of clips
    [SerializeField]
    private AudioClip[] clips;
    //the gameobject to deactivate
    public GameObject objectToDeactivate;

    private AudioSource audioSource;
    private bool actionTriggert;

    //links to the Component AudioSource
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

    }

    private void Update()
    {


        //if Event PreAxHit has happed then the selected Object will be activated
        if (actionTriggert == true)
        {
            objectToDeactivate.SetActive(true);
        }
        //if Event AfterAxHit has happed then the selected Object will be deactivated
        if (actionTriggert == false)
        {
            objectToDeactivate.SetActive(false);
        }


    }

    /*private bool NewEvent()
    {
        Debug.Log("New event");
        return actionTriggert = true;
    }*/
    private bool PreAxHit()
    {
        Debug.Log("PreAxHit");
        return actionTriggert = true;
    }



    //Method uses random AudioClip and play it. bool set to true.
    private void Hit()
    {
        Debug.Log("Hit");
        AudioClip clip = GetRandomClip();
        audioSource.PlayOneShot(clip);

    }

    private bool AfterAxHit()
    {
        Debug.Log("AfterAxHit");
        return actionTriggert = false;
    }

    //returns a random clip from the total soundlibary array
    private AudioClip GetRandomClip()
    {
        return clips[UnityEngine.Random.Range(0, clips.Length)];

    }
}