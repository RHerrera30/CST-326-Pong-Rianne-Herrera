using TMPro;
using UnityEngine;

public class ScorekeeperScript : MonoBehaviour
{
    public static ScorekeeperScript instance;

    public int leftScore = 0;
    public int rightScore = 0;
    public TextMeshProUGUI leftScoreText;
    public TextMeshProUGUI rightScoreText;
    public bool leftScored;
    public bool rightScored;
    public AudioSource audioSrc;
    public AudioClip clip;
    void Awake()
    {
        instance = this;
    }

    public void addPoint(int player)
    {
        //left = 1; right = 2
        if (player == 1)
        {
            leftScore++;
            leftScoreText.text = leftScore.ToString();
            leftScored = true;
            Debug.Log("Left score " + leftScore);
        } else if (player == 2)
        {
            rightScore++;
            rightScoreText.text = rightScore.ToString();
            rightScored = true;
            Debug.Log("Right score " + rightScore);
        }
        audioSrc.PlayOneShot(clip);
        CheckWinCondition();
    }

    void CheckWinCondition()
    {
        int winScore = 11;
    
        if (leftScore >= winScore)
        {
            leftScoreText.color = Color.yellow;
            leftScoreText.text = "WINNER!";
            rightScoreText.color = Color.red;
            rightScoreText.text = "LOSER!";
            Debug.Log("Game Over, Left Paddle Wins");
            Invoke(nameof(ResetGame),2f);

        } else if (rightScore >= winScore)
        {
            rightScoreText.color = Color.yellow;
            rightScoreText.text = "WINNER!";
            leftScoreText.color = Color.red;
            leftScoreText.text = "LOSER!";
            Debug.Log("Game Over, Right Paddle Wins");
            Invoke(nameof(ResetGame),2f);

        } }

    private void ResetGame()
    {
        leftScore = 0;
        rightScore = 0;
        leftScoreText.text = "0";
        rightScoreText.text = "0";
    }
}
