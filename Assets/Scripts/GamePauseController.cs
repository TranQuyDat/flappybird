using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GamePauseController : MonoBehaviour
{
    public GameObject gamepause;
    public TextMeshProUGUI txt_point;
    public bool isfly;
    public void SetActiveGamePause(bool setactive)
    {
        gamepause.SetActive(setactive);
    }
    public bool isactive()
    {
        return gamepause.active;
    }
    public void isFly(bool isfly)
    {
        this.isfly = isfly;
    }
    public void btn_Resume()
    {
        gamepause.SetActive(false);
        if (this.isfly == false) return;
        Time.timeScale = 1;
    }

    public void setPoint(int point)
    {
        this.txt_point.text = "Point : "+ point.ToString();
    }
}
