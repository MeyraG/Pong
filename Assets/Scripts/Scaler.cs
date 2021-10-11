using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaler : MonoBehaviour
{
    public GameObject bgImage;
    public Camera mainCamera; 
    LevelController levelController;
    
    void Start()
    {
        ScaleScreenSize();
        levelController = GameObject.FindGameObjectWithTag("LevelController").GetComponent<LevelController>();      
    }

    void ScaleScreenSize()
    {
        //Hedef Cihazın Çözünürlüğünü Alma
        Vector2 deviceScreen = new Vector2(Screen.width, Screen.height);

        float screenHeight = Screen.height;
        float screenWidth = Screen.width;

        float deviceAspect = screenWidth / screenHeight;

        //MainCamera'nın çözünürlüğünü cihazınkine eşitleme
        mainCamera.aspect = deviceAspect;

        //Background'ı kameraya sığdırma
        float cameraHeight = 100.0f * mainCamera.orthographicSize * 2.0f;
        float cameraWidth = cameraHeight * deviceAspect;

        //Background'ın size'ını alma
        SpriteRenderer bgImageS = bgImage.GetComponent<SpriteRenderer>();
        float bgImageHeight = bgImageS.sprite.rect.height;
        float bgImageWidth = bgImageS.sprite.rect.width;

        //Oran hesaplama
        float bgImageRatioH = cameraHeight / bgImageHeight;
        float bgImageRatioW = cameraWidth / bgImageWidth;
        bgImage.transform.localScale = new Vector3(bgImageRatioW, bgImageRatioH, 1);
    }
}
