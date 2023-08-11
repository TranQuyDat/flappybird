using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameOverController : MonoBehaviour
{
    public TextMeshProUGUI txt_Point;
    public GameObject gameover;

    public void setActive(bool setactive)
    {
        gameover.SetActive(setactive);
    }

    public bool isactive()
    {
        return gameover.active;
    }

    public void set_txtPoint(int point)
    {
        txt_Point.text = "point : " + point.ToString();
    }

}
