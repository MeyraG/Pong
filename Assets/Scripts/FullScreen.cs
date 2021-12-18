using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreen : MonoBehaviour
{
    LevelController levelController;
    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Vector2 tempScale = transform.localScale;

        float spriteWidth = spriteRenderer.size.x;
        float screenHeight = Camera.main.orthographicSize * 2.0f;
        float screenWidth = screenHeight / Screen.height * Screen.width;
        tempScale.x = screenWidth / spriteWidth;
        transform.localScale = tempScale;
        levelController = GameObject.FindGameObjectWithTag("LevelController").GetComponent<LevelController>();
    }
}
