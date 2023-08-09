using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GamePauseController : MonoBehaviour
{
    public GameObject gamepause;
    public TextMeshProUGUI txt_point;
    public void SetActiveGamePause(bool setactive)
    {
        gamepause.SetActive(setactive);
    }
    public bool isactive()
    {
        return gamepause.active;
    }

    public void btn_Resume()
    {
        gamepause.SetActive(false);
        Time.timeScale = 1;
    }

    public void setPoint(int point)
    {
        this.txt_point.text = "Point : "+ point.ToString();
    }
}
