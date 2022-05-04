using UnityEngine;

public class FrontTriggerboxAI : MonoBehaviour
{
    public AIController AIController;
    public PolesAI PolesAI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            if (AIController.ShootingState == ShootingState.ShootBack)
            {

            }
            else
            {
                AIController.ShootingState = ShootingState.ShootFront;
                PolesAI.ShootIndex = 0;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            if (AIController.ShootingState == ShootingState.ShootBack)
            {

            }
            else
            {
                AIController.ShootingState = ShootingState.Default;
                PolesAI.ShootIndex = 0;
            }
        }
    }
}
