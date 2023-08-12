using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    Material mat;
    float num;
    [Range(-1f, 1f)]
    public float scroller;
    public float speed;
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        num  -= (Time.deltaTime * scroller*speed) /10f ;
        mat.SetTextureOffset("_MainTex", new Vector2(num,0));
    }

    public void setspeed(float speed)
    {
        this.speed = speed;
    }
}
