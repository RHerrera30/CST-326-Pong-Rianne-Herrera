using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleScript : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    private Vector3 moveDirection;
    public InputActionReference moveAction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = moveAction.action.ReadValue<Vector3>();
    }

    private void FixedUpdate()
    {
        rb.velocity = moveDirection * speed;
    }
}
