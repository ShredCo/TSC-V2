using UnityEngine;

public class TriggerBoxFollowPole : MonoBehaviour
{
    public GameObject Pole;
    public GameObject PlayerToFollow;
    public bool Front = true;

    void Update()
    {
        if (Front)
        {
            transform.position = new Vector3(Pole.transform.position.x + 0.5f, transform.position.y, PlayerToFollow.transform.position.z);
        }
        else
        {
            transform.position = new Vector3(Pole.transform.position.x, transform.position.y, PlayerToFollow.transform.position.z);
        }
    }
}
