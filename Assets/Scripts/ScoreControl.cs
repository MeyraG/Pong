using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreControl : MonoBehaviour
{
    public Text scoreText;
    int score;

    void Start()
    {
        score = 0;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        score++;
        scoreText.text = score.ToString();
    }
}
