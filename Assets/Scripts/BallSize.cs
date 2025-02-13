using System;
using UnityEngine;

public class BallSize : MonoBehaviour
{
    public float sizeMultiplier = 1.5f;

    public float duration = 3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            BallScript ball = other.GetComponent<BallScript>();
            if (ball != null)
            {
                ball.ChangeBallSize(sizeMultiplier, duration);
            }
            Destroy(gameObject);
        }
    }
}
