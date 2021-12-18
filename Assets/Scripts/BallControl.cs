using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    Rigidbody2D rb2d;
    LevelController levelController;
    public float speed;
    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        StartingForce();
        levelController = GameObject.FindGameObjectWithTag("LevelController").GetComponent<LevelController>();
    }

    public void StartingForce()
    {
        Vector2 direction = new Vector2(Random.Range(3, 5), Random.Range(3, 5)).normalized;
        rb2d.AddForce(direction * speed, ForceMode2D.Impulse);
    }

    public void GameOver()
    {       
        gameObject.SetActive(false);
        rb2d.velocity = Vector2.zero;
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
    //public void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "ScoreZone1" || collision.gameObject.tag == "ScoreZone2")
    //    {           
    //        GameOver();         
    //    }
    //}
}