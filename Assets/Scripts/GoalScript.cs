using System;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    public int player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        { 
            ScorekeeperScript.instance.addPoint(player);
            other.gameObject.GetComponent<BallScript>().ResetBall();
        }
    }
}
