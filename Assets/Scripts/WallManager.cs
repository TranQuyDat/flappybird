using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour
{
    public GameObject wall;
    public GameObject spawWall;
    public float movespeed = 3f;
    private Vector3 cur_posWall = new Vector3();
    // Start is called before the first frame update
    void Start()
    {
        cur_posWall = spawWall.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        wall.transform.Translate(new Vector3(-1*Time.deltaTime* movespeed, 0, 0));
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "resetwall")
            wall.transform.position = new Vector3(cur_posWall.x,Random.Range(1,4),0);
    }
    public void setMoveSpeed(float speed)
    {
        this.movespeed = speed;
    }
}
