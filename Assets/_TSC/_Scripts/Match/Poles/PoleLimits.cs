using UnityEngine;

public class PoleLimits : MonoBehaviour
{
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (PlayerController.Instance.currentPoleIndexLeftHand)
        {
            case 0:
                rb.transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Clamp(transform.position.z, -3f, 3f));
                break;
            case 1:
                rb.transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Clamp(transform.position.z, -2.5f, 2.5f));
                break;
            case 2:
                rb.transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Clamp(transform.position.z, -0.9f, 0.9f));
                break;
            case 3:
                rb.transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Clamp(transform.position.z, -2f, 2f));
                break;
        }
    }
}
