using UnityEngine;

public class Powerpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            if (gameObject.CompareTag("Powerfield Blue"))
            {
                // Blue player picks up a powerpoint from powerfield
                Destroy(gameObject);
                SpawnPowerfields.instance.PowerfieldsCountBlue -= 1;
                if (GameManagerOneVsOne.Instance.powerpointsCountBlue < 5)
                {
                    GameManagerOneVsOne.Instance.powerpointsCountBlue += 1;
                }
            }
            if (gameObject.CompareTag("Powerfield Red"))
            {
                // Red player picks up a powerpoint from powerfield
                Destroy(gameObject);
                SpawnPowerfields.instance.PowerfieldsCountRed -= 1;
                if (GameManagerOneVsOne.Instance.powerpointsCountRed < 5)
                {
                    GameManagerOneVsOne.Instance.powerpointsCountRed += 1;
                }
            }
        }
    }
}
