using System;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    public int player;
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
            ScorekeeperScript.instance.addPoint(player);
            other.gameObject.GetComponent<BallScript>().ResetBall();
        }
    }
}
