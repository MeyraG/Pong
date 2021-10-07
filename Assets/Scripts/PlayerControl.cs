using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public bool isPlayer1;
    Rigidbody2D rb2d;
    
    public float speed;


    void Start()
    {
      rb2d = GetComponent<Rigidbody2D>();
    }

    public void ResetPositionPlayer1()
    {
        transform.position = new Vector3(0, -4.4f, 0);        
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
    }
}
