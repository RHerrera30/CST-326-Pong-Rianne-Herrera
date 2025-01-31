using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleController : MonoBehaviour
{
    public Rigidbody rb;

    public float speed;

    private Vector3 _moveDirection;
    public float bound = 12f;

    public InputActionReference move;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // void Start()
    // {
    //     
    // }

    // Update is called once per frame
    void Update()
    {
        _moveDirection = move.action.ReadValue<Vector3>();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = _moveDirection * speed;
        rb.position = new Vector3(rb.position.x, rb.position.y, Mathf.Clamp(rb.position.z, -bound, bound));
    }
}
