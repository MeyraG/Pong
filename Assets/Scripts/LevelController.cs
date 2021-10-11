using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public BallControl ball;
    public PlayerControl player1;
    public PlayerControl player2;

    public int totalRound;
    public int currentRound;

    LevelController levelController;
    public bool isPlaying = true;

    public Text gameOverText;

    private void Start()
    {
        levelController = GameObject.FindGameObjectWithTag("LevelController").GetComponent<LevelController>();
    }

    public void RestartLevel()
    {
        ball.ResetPosition();
        player1.ResetPositionPlayer1();
        player2.ResetPositionPlayer2();
    }

    public void RoundOver()
    {
        isPlaying = false;
        Debug.Log("Round Over");
        InvokeRepeating("NewRound", 1.2f, 0);

        if (currentRound == totalRound)
        {
            AllGameOver();
        }
    }

    public void NewRound()
    {
        currentRound++;
        RestartLevel();
    }

    void AllGameOver()
    {
        gameObject.SetActive(false);
        levelController.isPlaying = false;
        currentRound = 0;
        CancelInvoke();

        if (player1.score > player2.score)
        {
            gameOverText.text = "The Winner is Player 1 ";
        }
        else
        {
            gameOverText.text = "The Winner is Player 2 ";
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
        }
    }
}
