using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject Player;
    public float Jumpow  = 5f;
    public Rigidbody2D rb =new Rigidbody2D();
    int point = 0;
    bool isFly;
    int deadcount=0;
    GameManager gameManager;
    private void Start()
    {
        isFly = false;
        gameManager = GameObject.FindAnyObjectByType<GameManager>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Input.GetButton("Jump") )
        {
            btn_jump();
        }   
    }


    public void btn_jump()
    {
        isFly = true;
        rb.velocity = Vector2.up * Jumpow;
        Time.timeScale = 1;
        gameManager.isFly(isFly);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "addpoint")
        {            point += 1;
            gameManager.addPoint(point);
        }
        else if  ((collision.tag == "isWall" || collision.tag == "Ground") && deadcount < 1)
        {
            deadcount++;
            Gameover();
            gameManager.checkBirdDie(true);
            gameManager.setactive_Gameplay(false);
            gameManager.setWallSpeed(0);
            //Time.timeScale = 0;
            gameManager.updateHightPoint(point);
            Debug.Log("this ok");


        }
    }

    public void Gameover()
    {
        //Debug.Log("gameover");
        
        gameManager.setPoint_gameover(point);
        gameManager.setactive_Gameover(true);
        gameManager.setactive_Gameplay(false);
        gameManager.setspeed_bgScroll(0);
    }
    public void Gamestart()
    {
        deadcount = 0;
        point = 0;
        gameManager.setspeed_bgScroll(4.5f);
        gameManager.setWallSpeed(3);
        isFly = false;
        gameManager.checkBirdDie(false);
        gameManager.isFly(isFly);
        gameManager.setPoint_gameplay(point);
        gameManager.start_game();
        Player.transform.rotation = Quaternion.Euler(0, 0, 0);
    }
    
}
