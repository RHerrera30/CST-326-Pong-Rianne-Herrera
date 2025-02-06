using System;
using Unity.VisualScripting;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public Material mat;
    
    private Vector3 newVelocity;
    private bool updateVelocity;
    private Vector3 startPosition;
    private Vector3 direction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // rb.linearVelocity = Vector3.left * speed;
        startPosition = transform.position;
        mat.color = Color.white;
        LaunchBall();
    }
    
    void OnCollisionEnter(Collision other)
    {
        // Debug.Log($"Collided with: {other.gameObject.name}");

        if (other.gameObject.CompareTag("LeftPaddle") || other.gameObject.CompareTag("RightPaddle"))
        {
            Transform paddle = other.gameObject.transform;
            
            float relativeHitPos = (transform.position.z - paddle.position.z) / (paddle.localScale.z / 2);
            // Debug.Log($"Relative Hit Position: {relativeHitPos}");
            
            float newXDirection = (other.gameObject.CompareTag("LeftPaddle")) ? 1 : -1;
            float newZDirection = Mathf.Clamp(relativeHitPos, -1f, 1f);
            
            direction = new Vector3(newXDirection, 0, newZDirection).normalized;
            // Debug.Log($"Calculated direction: {direction}");

            newVelocity = direction * speed;
            updateVelocity = true;
            speed += 1f;

            //Change the color of the ball to match last paddle hit
            if (other.gameObject.CompareTag("LeftPaddle"))
            {
                mat.color = Color.cyan;
            } else if (other.gameObject.CompareTag("RightPaddle"))
            {
                mat.color = Color.red;
            }
            
        } else if (other.gameObject.CompareTag("TopBorder") || other.gameObject.CompareTag("BotBorder"))
        {
            direction = new Vector3(direction.x, 0, -direction.z).normalized;
            newVelocity = direction * speed;
            updateVelocity = true;
            // Debug.Log($"New Direction After Border Bounce: {direction}");
        }
    }

    void FixedUpdate()
    {
        if (updateVelocity)
        {
            rb.linearVelocity = newVelocity;
            updateVelocity = false;
            // Debug.Log($"New Velocity Applied in FixedUpdate: {rb.linearVelocity}");
        }
    }

    void LaunchBall()
    {
        if (ScorekeeperScript.instance.leftScored)
        {
            rb.linearVelocity = Vector3.right * speed;
            ScorekeeperScript.instance.leftScored = false;
        } else if (ScorekeeperScript.instance.rightScored)
        {
            rb.linearVelocity = Vector3.left * speed;
            ScorekeeperScript.instance.rightScored = false;
        } else
        {
            rb.linearVelocity = Vector3.left * speed;
        }
        
    }

    public void ResetBall()
    {
        transform.position = startPosition;
        rb.linearVelocity = Vector3.zero;
        speed = 5f;
        mat.color = Color.white;
        Invoke(nameof(LaunchBall), 1f);
    }
}
