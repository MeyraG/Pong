using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public BallControl ball;
    public PlayerControl player1;

    public void RestartLevel()
    {
        ball.gameObject.SetActive(true);
        ball.ResetPosition();
        player1.ResetPositionPaddle();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
        }
    }
}
