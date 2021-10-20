using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreControl : MonoBehaviour
{
    public Text scoreText;
   
    LevelController levelController;

    public bool isPlayer1;
    
    void Start()
    {
       
        levelController = GameObject.FindGameObjectWithTag("LevelController").GetComponent<LevelController>();
      
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isPlayer1)
        {
            levelController.player1.score++;
            scoreText.text = levelController.player1.score.ToString();
        }
        else
        {
            levelController.player2.score++;
            scoreText.text = levelController.player2.score.ToString();
        }      
    }

    public void ResetScore()
    {
        levelController.player1.score = 0;
        levelController.player2.score = 0;
        scoreText.text = levelController.player1.score.ToString();
        scoreText.text = levelController.player2.score.ToString();
    }
}