using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleController : MonoBehaviour
{
    public Rigidbody rb;

    public float speed;

    private Vector3 paddleForce;
    public float bound = 3f;

    public InputActionReference move;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // void Start()
    // {
    //     
    // }

    // Update is called once per frame
    void Update()
    {
        // Transform paddleTransform = GetComponent<Transform>();
        
        paddleForce = move.action.ReadValue<Vector3>();
        
        Vector3 newPos = transform.position + new Vector3(0f, 0f, paddleForce.z * speed *Time.deltaTime);
        newPos.z = Math.Clamp(newPos.z, -bound, bound);
        
        transform.position = newPos;
       
    }

    void FixedUpdate()
    {
        // // rb.linearVelocity = paddleForce * speed;
        // rb.position = new Vector3(rb.position.x, rb.position.y, Mathf.Clamp(rb.position.z, -bound, bound));
        // // rb.AddForce(paddleForce * speed, ForceMode.Force);
        // rb.position = paddleForce * speed;
    }
}
