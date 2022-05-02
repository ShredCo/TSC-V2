using UnityEngine;

public class BackTriggerboxAI : MonoBehaviour
{
    public AIController AIController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            AIController.ShootingState = ShootingState.ShootBack;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            AIController.ShootingState = ShootingState.Default;
        }
    }
}
