using UnityEngine;

public class PoleLimits : MonoBehaviour
{
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (PlayerController.Instance.currentPoleIndex)
        {
            case 0:
                rb.transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Clamp(transform.position.z, -0.25f, 0.25f));
                break;
            case 1:
                rb.transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Clamp(transform.position.z, -0.25f, 0.25f));
                break;
            case 2:
                rb.transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Clamp(transform.position.z, -0.12f, 0.12f));
                break;
            case 3:
                rb.transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Clamp(transform.position.z, -0.2f, 0.2f));
                break;
        }
    }
}
