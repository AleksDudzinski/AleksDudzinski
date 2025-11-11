using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Ball")]
    public Ball ball;

    [Header("Players")]
    public P1 playerOne;
    public P2 playerTwo;

    [Header("Score UI")]
    public TextMeshProUGUI playerOneText;
    public TextMeshProUGUI playerTwoText;

    private int playerOneScore;
    private int playerTwoScore;

    // wywoływana przez Goal.cs
    public void GoalScored(bool isPlayerOneGoal)
    {
        if (isPlayerOneGoal)
        {
            playerTwoScore++;
            playerTwoText.text = playerTwoScore.ToString();
        }
        else
        {
            playerOneScore++;
            playerOneText.text = playerOneScore.ToString();
        }

        ResetPositions();
    }

    void ResetPositions()
    {
        ball.ResetPosition();
        playerOne.ResetPosition();
        playerTwo.ResetPosition();
    }
}
