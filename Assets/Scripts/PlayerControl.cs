using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public bool isPlayer1;
    Rigidbody2D rb2d;

    public float speed;

    LevelController levelController;

    bool hasAlreadyDownSize;
    float startDowningTime;
    public float downSizeDuration = 5;

    public int score;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        levelController = GameObject.FindGameObjectWithTag("LevelController").GetComponent<LevelController>();
    }

    public void ResetPositionPlayer1()
    {
        transform.position = new Vector3(0, -4.4f, 0);
        //if (isPlayer1)
        //{
        //    transform.position = new Vector3(0, -4.4f, 0);
        //}
        //else
        //{
        //    transform.position = new Vector3(0, 4.4f, 0);
        //}

        //transform.position = new Vector3(0, 4.4f * (isPlayer1 ? -1 : 1), 0);
    }
    public void ResetPositionPlayer2()
    {
        transform.position = new Vector3(0, 4.4f, 0);
    }
    void Update()
    {
        if (isPlayer1)
        {
            rb2d.velocity = Vector2.right * Input.GetAxisRaw("Horizontal") * speed;
        }
        else
        {
            rb2d.velocity = Vector2.right * Input.GetAxisRaw("Horizontal2") * speed;
        }

        if (!hasAlreadyDownSize)
        {
            if (!isPlayer1 && Input.GetKeyDown(KeyCode.Q)) //Pressed by Player2
            {
                DownSize(isPlayer1);
            }

            if (isPlayer1 && Input.GetKeyDown(KeyCode.L))  //Pressed by Player1
            {
                DownSize(!isPlayer1);
            }
        }

        if (hasAlreadyDownSize && startDowningTime + 5 < Time.time)
        {
            UpSize(isPlayer1);
        }
    }


    void DownSize(bool isPlayer1)
    {
        startDowningTime = Time.time;

        if (isPlayer1)
        {
            transform.localScale = transform.localScale / 2;
            Debug.Log("Küçüldüm");
        }

        hasAlreadyDownSize = true;
    }

    void UpSize(bool isPlayer1)
    {
        if (isPlayer1)
        {
            transform.localScale = transform.localScale * 2;
        }


        hasAlreadyDownSize = false;
    }

}