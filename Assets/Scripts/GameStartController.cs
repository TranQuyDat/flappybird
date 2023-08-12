using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameStartController : MonoBehaviour
{
    public GameObject gamestart;
    public TextMeshProUGUI txt_hightpoint;

    private void Start()
    {
        txt_hightpoint.text = "HighPoint : " + PlayerPrefs.GetInt("highpoint",0).ToString();
        //Debug.Log(PlayerPrefs.GetInt("hightpoint").ToString());
    }
    public void SetActiveGameStart(bool setactive)
    {
        gamestart.SetActive(setactive);
    }
    public bool isactive()
    {
        return gamestart.active;
    }
    public void btn_Quit()
    {
        Application.Quit();
    }
    public void updatePoint(int Hightpoint)
    {
        if (Hightpoint > PlayerPrefs.GetInt("highpoint", 0))
        {
            PlayerPrefs.SetInt("highpoint", Hightpoint);
            txt_hightpoint.text = "HighPoint : " + Hightpoint.ToString();
        }
        ;
    }
}
