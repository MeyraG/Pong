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
    float startTime;
    public float featureDuration = 8;

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
        Move();
        DownFeature();
        RotateFeature();
        ReverseFeature();
    }

    private void Move()
    {
        if (isPlayer1)
        {
            if (isInverse)
            {
                rb2d.velocity = -(Vector2.right * Input.GetAxisRaw("Horizontal") * speed);
            }
            else
            {
                rb2d.velocity = Vector2.right * Input.GetAxisRaw("Horizontal") * speed;
            }

        }
        else
        {
            if (isInverse)
            {
                rb2d.velocity = -(Vector2.right * Input.GetAxisRaw("Horizontal2") * speed);
            }
            else
            {
                rb2d.velocity = Vector2.right * Input.GetAxisRaw("Horizontal2") * speed;
            }
        }

    }

    void DownFeature()
    {
        if (!isPlayer1 && Input.GetKeyDown(KeyCode.Q)) //Pressed by Player2
        {
            /*
             * Ben (yani bu scriptin bagli oldugu game object) player 2 olduguna gore
             * player1 in kuculmesini istiyorum. Bunu levelController a soyluyorum o da 
             * player1'in downSize fonksiyonunu cagiriyor.
             */
            levelController.DownSize(1);
        }

        if (isPlayer1 && Input.GetKeyDown(KeyCode.L)) //Pressed by Player1
        {
            /*
             * Ben (yani bu scriptin bagli oldudu game object) player 1 olduguna gore
             * player2 in kuculmesini istiyorum. Bunu levelController a soyluyorum o da 
             * player2'in downSize fonksiyonunu cagiriyor.
             */
            levelController.DownSize(2);
        }

        if (hasAlreadyDownSize && startTime + featureDuration < Time.time)
        {
            /*
             * geri buyume sadece zamana bagli oldugu icin playerlarin kim olduklari onemsiz
             * eger kuculduysem ve 8 saniye gectiyse beni buyult diyorum
             * bu 8 saniye inspector'den belirlenebilir olacakti,
             * yukarida degeri yazmissin buradaki sayiyla 8 yerine onu koymayi unutmussun, koydum ben.
             */
            UpSize();
        }

    }

    void RotateFeature()
    {

        if (!isPlayer1 && Input.GetKeyDown(KeyCode.Z))
        {
            levelController.Rotate(1);
        }
        else if (isPlayer1 && Input.GetKeyDown(KeyCode.K))
        {
            levelController.Rotate(2);
        }

        if (hasAlreadyRotated && startTime + featureDuration < Time.time)
        {
            NotRotate();
        }
    }

    void ReverseFeature()
    {

        if (isPlayer1 && Input.GetKeyDown(KeyCode.P))
        {
            levelController.Reverse(2);
            Debug.Log("p is pressed");
        }
        else if (!isPlayer1 && Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("x is pressed");
            levelController.Reverse(1);
        }
        if (isInverse && startTime + featureDuration < Time.time)
        {
            Debug.Log("reverse is over");
            NotReverse();
        }
    }
    public void DownSize()
    {
        /*
         * bu fonksiyon cagrildigi zaman bagli oldugu game objecti kucultecek,
         * bunun ne zaman cagrilacagini levelController da belirliyoruz 
         */
        if (!hasAlreadyDownSize)
        {
            startTime = Time.time;
            transform.localScale = transform.localScale / 3;
            hasAlreadyDownSize = true;
        }
    }

    private void UpSize()
    {
        transform.localScale = transform.localScale * 3;
        hasAlreadyDownSize = false;
    }

    bool hasAlreadyRotated;

    public void Rotate()
    {
        if (hasAlreadyRotated == false)
        {
            startTime = Time.time;
            transform.rotation = Quaternion.Euler(0, 0, 90);
            hasAlreadyRotated = true;
        }
    }

    void NotRotate()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        hasAlreadyRotated = false;
    }

    bool isInverse;
    public void Reverse()
    {
        
        if (isInverse == false)
        {
            startTime = Time.time;
            isInverse = true;

        }
    }

    void NotReverse()
    {
        isInverse = false;
    }
}