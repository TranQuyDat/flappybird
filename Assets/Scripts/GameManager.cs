using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveGameobj
{
    public  List<Vector3> pos;
    
    public void getTranform( List<GameObject> wallManagers)
    {
        for(int i = 0;i < wallManagers.Count;i++ )
        {
            pos.Add(wallManagers[i].transform.position);
            //Debug.Log(pos[i]);
            
        }
    }
    public void gameStart(List<GameObject> wallManagers  )
    {
        for (int i = 0; i < wallManagers.Count; i++)
        {
            wallManagers[i].transform.position = pos[i];
        }
    }
}
public class GameManager : MonoBehaviour
{
    AudioManager audioManager;
    GameStartController gameStartController;
    GamePlayController gamePlayController;
    GamePauseController gamePauseController;
    public GameObject gamestart;
    public GameObject gamepause;
    public GameObject gameplay;
    public List<GameObject> wallManagers;
    [SerializeField] SaveGameobj saveGameobj;
    int point;
    bool isfly;
private void Start()
    {
        saveGameobj.getTranform(wallManagers);
        gameStartController = gamestart.GetComponent<GameStartController>();
        gamePauseController = gamepause.GetComponent<GamePauseController>();
        gamePlayController = gameplay.GetComponent<GamePlayController>();
        audioManager = FindAnyObjectByType<AudioManager>();
        gameStartController.SetActiveGameStart(true);
    }


    private void Update()
    {
        setpointwhenPause();
        if (gameStartController.isactive() || gamePauseController.isactive())
        {
            Time.timeScale = 0;
        }
    }

    public void isFly (bool isfly)
    {
         this.isfly = isfly;
        gamePauseController.isFly(isfly);
    }

    public void addPoint( int point)
    {
        audioManager.Audio_AddPoint();
        gamePlayController.SetPoint(point);
        this.point = point;
    }
    public void setpointwhenPause()
    {
        if(gamePauseController.isactive())
            gamePauseController.setPoint(point);
    }
    public void setTimeScale(int number_1_or_0)
    {
        Time.timeScale = number_1_or_0;
    }

    public void start_game()
    {
        saveGameobj.gameStart(wallManagers);
        gamePlayController.SetActiveGamePlay(false);
        gameStartController.SetActiveGameStart(true);
    }

    public void updateHightPoint(int hightpoint)
    {
        gameStartController.updatePoint(hightpoint);
    }

}

