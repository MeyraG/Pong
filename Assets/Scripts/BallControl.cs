using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    Rigidbody2D rb2d;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        StartingForce();
    }
    public void StartingForce()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(3, 7), Random.Range(3, 7)), 
            ForceMode2D.Impulse);
    }
    public void GameOver()
    {
        gameObject.SetActive(false);
        Debug.Log("Game OVER!");

    }
    public void ResetPosition()
    {
       
        gameObject.transform.position = rb2d.position = Vector3.zero;

        StartingForce();
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DeathZone")
        {           
              GameOver();
            
        }
    }

    public void RestartLevel()
    {
        gameObject.SetActive(true);
        ResetPosition();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
       
            RestartLevel();
            
        }
    }
}
