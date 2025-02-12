using System;
using UnityEngine;

public class SpeedBoostScript : MonoBehaviour
{
    public float speedBoost = 1.5f;

    public float duration = 3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            BallScript ball = other.GetComponent<BallScript>();
            if (ball != null)
            {
                ball.ActivateSpeedBoost(speedBoost, duration);
            }
            Destroy(gameObject);
        }
    }
}
// using System;
// using UnityEngine;
//
// public class SpeedBoostScript : MonoBehaviour
// {
//     public float speedBoost = 3f;
//
//     public float duration = 3f;
//
//
//     private bool isActive = false;  // Prevent activation until timer expires
//     public float activationDelay = 3f;  // Delay before the power-up can be activated
//
//     void Start()
//     {
//         StartCoroutine(EnablePowerUpAfterDelay());
//     }
//
//     IEnumerator EnablePowerUpAfterDelay()
//     {
//         yield return new WaitForSeconds(activationDelay); // Wait for the set time
//         isActive = true;  // Now it can be activated
//     }
//
//     // Start is called once before the first execution of Update after the MonoBehaviour is created
//     private void OnTriggerEnter(Collider other)
//     {
//         if (isActive && other.CompareTag("Ball"))
//         {
//             BallScript ball = other.GetComponent<BallScript>();
//             if (ball != null)
//             {
//                 ball.ActivateSpeedBoost(speedBoost, duration);
//             }
//             Destroy(gameObject);
//         }
//     }
// }
