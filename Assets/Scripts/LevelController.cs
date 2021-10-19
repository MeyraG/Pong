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
        levelController.isPlaying = true;
        ball.ResetPosition();
        player1.ResetPositionPlayer1();
        player2.ResetPositionPlayer2();
    }

    public void RoundOver()
    {
        isPlaying = false;       

        if (currentRound == totalRound)
        {
            AllGameOver();
        }
        else
        {
            Invoke("NewRound", 1.2f);
        }
    }

    public void NewRound()
    {
        currentRound++;
        RestartLevel();
    }

    void AllGameOver()
    {   
        isPlaying = false;
        currentRound = 0;

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
        Replay();
    }

    public void Replay()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
            gameOverText.gameObject.SetActive(false);
        }
    }

    
    /*
     * Extra ozellikleri level controller uzerinden yapalim.
     * playerController scriptinde o ozelligin playera ne yapacagi ile ilgili fonksiyon olsun
     * sonra geri duzeltecek fonksiyon da playerControllerin icinde olsun.
     * her player yapmak istedigi hamleyi ve kime yapacagini levelController'a soylesin
     * levelController da ona gore ilgili fonksiyonu cagirsin.
     *
     * down size icin bunu yaptim. Bu fonksiyonun playerController da cagrildigi yeri de incele.
     */
    public void DownSize(int whichPlayer)
    {
        if (whichPlayer == 1)
        {
            player1.DownSize();
        }
        else if (whichPlayer == 2)
        {
            player2.DownSize();
        }
    }
}
