using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    Rigidbody2D rb2d;
    LevelController levelController;
    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        StartingForce();
        levelController = GameObject.FindGameObjectWithTag("LevelController").GetComponent<LevelController>();
    }
    public void StartingForce()
    {
        rb2d.AddForce(new Vector2(Random.Range(4, 7), Random.Range(4, 7)),ForceMode2D.Impulse);
    }
    public void GameOver()
    {
       
        gameObject.SetActive(false);
        levelController.isPlaying = false;
        levelController.RoundOver();

    }
    public void ResetPosition()
    {
        gameObject.SetActive(true);
        levelController.isPlaying = true;
        gameObject.transform.position = Vector3.zero;
        StartingForce();
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ScoreZone1" || collision.gameObject.tag == "ScoreZone2")
        {           
            GameOver();
           
        }
    }
}
