using UnityEngine;

public class AbilityWind : MonoBehaviour
{
    [SerializeField] private float speed;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(-speed*Vector3.right, ForceMode.Impulse);
        }
    }
}
