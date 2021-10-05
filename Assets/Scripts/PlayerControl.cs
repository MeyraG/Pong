using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D rb2d;
    
    public float speed;

    void Start()
    {
      rb2d = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        rb2d.velocity = Vector2.right * Input.GetAxisRaw("Horizontal") * speed;
    }
}
