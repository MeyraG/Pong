using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public BallControl ball;
    public PlayerControl player1;
    public PlayerControl player2;


    public void RestartLevel()
    {
        ball.gameObject.SetActive(true);
        ball.ResetPosition();
        player1.ResetPositionPlayer1();
        player2.ResetPositionPlayer2();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
        }
    }
}
