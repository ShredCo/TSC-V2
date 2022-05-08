using UnityEngine;

public class AbilityWind : MonoBehaviour
{
    [SerializeField] private float speed;
    
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce((transform.position - other.gameObject.transform.position) * -speed, ForceMode.Impulse);
        }
    }
}
