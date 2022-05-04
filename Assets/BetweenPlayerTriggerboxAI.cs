using UnityEngine;

public class BetweenPlayerTriggerboxAI : MonoBehaviour
{
    [SerializeField] AIController aiController;
    [SerializeField] PolesAI polesAI;
    
    float timeCounter = 0f;
    float reactionTimeAI = 3f;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            timeCounter = 0;
        } 
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Ball"))
        {
            timeCounter += Time.deltaTime;
            if (timeCounter >= reactionTimeAI)
            {
                aiController.AIState = AIState.BetweenPlayerPositions;
                if (aiController.ShootingState == ShootingState.ShootBack)
                {

                }
                else
                {
                    aiController.ShootingState = ShootingState.LoadShot;
                    polesAI.ShootIndex = 1;
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            timeCounter = 0;
            aiController.AIState = AIState.OutOfRange;
        }
    }
}
