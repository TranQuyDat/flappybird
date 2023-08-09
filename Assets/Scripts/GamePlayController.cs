using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GamePlayController : MonoBehaviour
{
    public GameObject gameplay;
    public TextMeshProUGUI txt_point;
    public void SetActiveGamePlay(bool setactive)
    {
        gameplay.SetActive(setactive);
    }

    public void SetPoint(int point)
    {
        txt_point.text ="Point : "+ point.ToString();
    }

    public bool isactive()
    {
        return gameplay.active;
    }

    
}
