using System;
using System.Collections;
using UnityEngine;

public class ReverseBoost : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            BallScript ball = other.GetComponent<BallScript>();
            if (ball != null)
            {
                // ball.ReverseVelocity();
            }
            Destroy(gameObject);
        }
    }
}
