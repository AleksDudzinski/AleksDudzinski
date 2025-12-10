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

    [Header("Win Screen")]
    public GameObject winScreen;
    public TextMeshProUGUI winText;

    [Header("Pause Menu")]
    public GameObject pauseMenu;

    private int playerOneScore;
    private int playerTwoScore;

    private bool gameEnded = false;
    private bool isPaused = false;

    void Start()
    {
        winScreen.SetActive(false);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void GoalScored(bool isPlayerOneGoal)
    {
        if (gameEnded || isPaused)
            return;

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

        CheckWin();

        if (!gameEnded)
            ResetPositions();
    }

    void CheckWin()
    {
        if (playerOneScore >= 5 || playerTwoScore >= 5)
        {
            EndGame(playerOneScore > playerTwoScore ? 1 : 2);
            return;
        }

        if (Mathf.Abs(playerOneScore - playerTwoScore) >= 3)
        {
            EndGame(playerOneScore > playerTwoScore ? 1 : 2);
        }
    }

    void EndGame(int winner)
    {
        gameEnded = true;

        ball.StopBall();
        playerOne.enabled = false;
        playerTwo.enabled = false;

        winText.text = "Player " + winner + " Wins!";
        winScreen.SetActive(true);

        Time.timeScale = 0f;
    }

    public void ResetPositions()
    {
        ball.ResetPosition();
        playerOne.ResetPosition();
        playerTwo.ResetPosition();
    }

    void Update()
    {
        if (gameEnded)
        {
            if (Input.GetKeyDown(KeyCode.R))
                RestartGame();

            return;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex
        );
    }
}
