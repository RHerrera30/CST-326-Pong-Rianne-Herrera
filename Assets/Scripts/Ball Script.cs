using System;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb.AddForce(Vector3.left * 300f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 up = new Vector3(1, 0, 0);
    }

    private void FixedUpdate()
    {
        // rb.AddForce(Vector3.left * 50f);
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.tag == "LeftPaddle")
        {
            rb.AddForce(Vector3.right * 300f);
        } else if (other.gameObject.tag == "RightPaddle")
        {
            rb.AddForce(Vector3.left * 300f);
        }
    }
}
