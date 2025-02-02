using System;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 10f;
    private Vector3 newVelocity;
    private bool updateVelocity;

    private Vector3 direction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb.linearVelocity = Vector3.left * speed;
    }
    
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log($"Collided with: {other.gameObject.name}");

        if (other.gameObject.CompareTag("LeftPaddle") || other.gameObject.CompareTag("RightPaddle"))
        {
            Transform paddle = other.gameObject.transform;
            
            float relativeHitPos = (transform.position.z - paddle.position.z) / (paddle.localScale.z / 2);
            Debug.Log($"Relative Hit Position: {relativeHitPos}");
            
            float newXDirection = (other.gameObject.CompareTag("LeftPaddle")) ? 1 : -1;
            float newZDirection = Mathf.Clamp(relativeHitPos, -1f, 1f);
            
            direction = new Vector3(newXDirection, 0, newZDirection).normalized;
            Debug.Log($"Calculated direction: {direction}");

            newVelocity = direction * speed;
            updateVelocity = true;
        } else if (other.gameObject.CompareTag("TopBorder") || other.gameObject.CompareTag("BotBorder"))
        {
            direction = new Vector3(direction.x, 0, -direction.z).normalized;
            newVelocity = direction * speed;
            updateVelocity = true;
            Debug.Log($"New Direction After Border Bounce: {direction}");
        }
    }

    private void FixedUpdate()
    {
        if (updateVelocity)
        {
            rb.linearVelocity = newVelocity;
            updateVelocity = false;
            Debug.Log($"New Velocity Applied in FixedUpdate: {rb.linearVelocity}");
        }
    }
}
