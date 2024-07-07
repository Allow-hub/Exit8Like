using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public static GameManager Instance => I;
    protected override bool DestroyTargetGameObject => true;

    bool isInGame = false;

    bool once = false;

    public enum GameState
    {
        Title,
        Menu,
        Tutorial,//インゲーム初めの異変がない状態
        CheckAnomalies, //異変判定、仕様書のA
        FindingAnomalies,　//異変を探す、仕様書のB
        GameOver,
        GameClear
    }
    public GameState currentState;

    protected override void Init()
    {
        base.Init();
    }


    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "InGame")
        {
            isInGame = true;
        }
        else
        {
            once = false;
            isInGame = false;
            ChangeToTitleState();
        }

        if (!once && isInGame)
        {
            ChangeToTutorialState();
            once = true;
        }
        StateHandler();
    }

    //ゲームの状態を管理
    private void StateHandler()
    {
        switch (currentState)
        {
            case GameState.Title:
                Title();
                break;
            case GameState.Menu:
                Menu();
                break;
            case GameState.Tutorial:
                Tutorial();
                break;
            case GameState.CheckAnomalies:
                break;
            case GameState.FindingAnomalies:
                break;
            case GameState.GameClear:
                GameClear();
                break;
            case GameState.GameOver:
                GameOver();
                break;
            default:
                Debug.Log("対応する状態がありません");
                break;
        }
    }
    //外側からゲームの状態を変更
    public void SetState(GameState newState)
    {
        currentState = newState;
        //状態の初期化処理を入れる
        switch (currentState)
        {
            case GameState.Title:
                //TitleInit();
                break;
            case GameState.Menu:
                //MenuInit();
                break;
       
            case GameState.Tutorial:

                break;
            case GameState.CheckAnomalies:
                break;
            case GameState.FindingAnomalies:
                break;
            case GameState.GameOver:
                //GameOverInit();
                break;
        }
    }
    private void Title()
    {

    }
    private void Menu()
    {

    }
    private void Tutorial()
    {

    }
    private void GameOver()
    {

    }
    private void GameClear()
    {

    }

    public void ChangeToTitleState() => SetState(GameState.Title);
    public void ChangeToMenuState() => SetState(GameState.Menu);
    public void ChangeToTutorialState() => SetState(GameState.Tutorial);
    public void ChangeToCheckAnomaliesState() => SetState(GameState.CheckAnomalies);

    public void ChangeToFindingAnomaliesState() => SetState(GameState.FindingAnomalies);


}
