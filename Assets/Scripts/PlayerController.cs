using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject Player;
    public float Jumpow  = 5f;
    public Rigidbody2D rb =new Rigidbody2D();
    int point = 0;
    GameManager gameManager;
    private void Start()
    {
        gameManager = GameObject.FindAnyObjectByType<GameManager>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Input.GetButton("Jump") )
        {
            /*Debug.Log("this ok !");*/
            rb.velocity = Vector2.up * Jumpow ;
        }   
    }

    public void btn_jump()
    {
        rb.velocity = Vector2.up * Jumpow;
        Time.timeScale = 1;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "addpoint")
        {            point += 1;
            gameManager.addPoint(point);
        }
        else if  (collision.tag == "isWall" || collision.tag == "Ground")
        {
            gameManager.gameplay.SetActive(false);
            Time.timeScale = 0;
            gameManager.updateHightPoint(point);
            StartCoroutine(gamestart());
        }
    }
    IEnumerator gamestart()
    {
        point = 0;
        gameManager.addPoint(point);
        yield return new WaitForSecondsRealtime(1);
        Debug.Log("game over!!!");
        
        gameManager.start_game();
        
    }
}
