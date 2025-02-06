using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public float bound = 3f;
    public AudioSource audioSrc;
    public AudioClip clip;
    
    private Vector3 paddleForce;
    public InputActionReference move;

    // Update is called once per frame
    void Update()
    {
        // Transform paddleTransform = GetComponent<Transform>();
        
        paddleForce = move.action.ReadValue<Vector3>();
        
        Vector3 newPos = transform.position + new Vector3(0f, 0f, paddleForce.z * speed *Time.deltaTime);
        newPos.z = Math.Clamp(newPos.z, -bound, bound);
        
        transform.position = newPos;
       
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Ball"))
        {
            audioSrc.PlayOneShot(clip);
        }
    }
}
