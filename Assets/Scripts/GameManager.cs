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
    BackgroundScroller[] backgroundScroller;
    AnimationManager AnimationManager;
    AudioManager audioManager;
    GameStartController gameStartController;
    GamePlayController gamePlayController;
    GamePauseController gamePauseController;
    GameOverController gameOverController;
    public List<GameObject> wallManagers;
    [SerializeField] SaveGameobj saveGameobj;

    WallManager[] WallManager;
    int point;
    bool isfly;
private void Start()
    {
        //
        saveGameobj.getTranform(wallManagers);
        gameStartController = GameObject.Find("GameStart").GetComponent<GameStartController>();
        gamePauseController = GameObject.Find("GamePause").GetComponent<GamePauseController>();
        gamePlayController = GameObject.Find("GamePlay").GetComponent<GamePlayController>();
        gameOverController = GameObject.Find("GameOver").GetComponent<GameOverController>();
        //
        audioManager = FindAnyObjectByType<AudioManager>();
        AnimationManager = FindAnyObjectByType<AnimationManager>();
        WallManager = FindObjectsOfType<WallManager>();
        backgroundScroller = FindObjectsOfType<BackgroundScroller>();
        //
        gameStartController.SetActiveGameStart(true);
        gamePlayController.SetActiveGamePlay(false);
        gamePauseController.SetActiveGamePause(false);
        gameOverController.setActive(false);
        audioManager.Audio_playLoop("music");
    }


    private void Update()
    {
        setpointwhenPause();
        if (gameStartController.isactive() || gamePauseController.isactive())
        {
            Time.timeScale = 0;
        }
    }


    public void setspeed_bgScroll(float speed)
    {
        backgroundScroller[0].setspeed(speed);
        backgroundScroller[1].setspeed(speed);
    }
    public void setWallSpeed( float speed)
    {
        foreach(WallManager wall in WallManager)
        {
            wall.setMoveSpeed(speed);
        }
    }
    public void checkBirdDie(bool isdie)
    {
        //Debug.Log(isdie);
        AnimationManager.checkBirdDie(isdie);
    }
    public void isFly (bool isfly)
    {
         this.isfly = isfly;
        gamePauseController.isFly(isfly);
    }

    //gameplaycontroller
    public void setactive_Gameplay(bool setactive)
    {
        gamePlayController.SetActiveGamePlay(setactive);
    }
    public void addPoint( int point)
    {
        audioManager.Audio_playoneshot("point_sound") ;
        gamePlayController.SetPoint(point);
        this.point = point;
    }
    public void setPoint_gameplay(int point)
    {
        gamePlayController.SetPoint(point);
        this.point = point;
    }

    //gamepausecontroller
    public void setpointwhenPause()
    {
        if(gamePauseController.isactive())
            gamePauseController.setPoint(point);
    }

    //gameovercontroller
    public void setactive_Gameover(bool setactive)
    {
        gameOverController.setActive(setactive);
        audioManager.audioSource_Music.mute = true;
        audioManager.Audio_playoneshot("gameover_sound");
    }
    public void setPoint_gameover(int point)
    {
        gameOverController.set_txtPoint(point);
    }
    public void setTimeScale(int number_1_or_0)
    {
        Time.timeScale = number_1_or_0;
    }

    public void start_game()
    {
        saveGameobj.gameStart(wallManagers);
        gameOverController.setActive(false);
        gameStartController.SetActiveGameStart(true);
        audioManager.audioSource_Music.mute = false;
    }

    public void updateHightPoint(int hightpoint)
    {
        gameStartController.updatePoint(hightpoint);
    }

}

