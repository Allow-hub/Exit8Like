using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public static GameManager Instance => I;
    protected override bool DestroyTargetGameObject => true;
    public GameObject player;
    public int CurrentNum = 0; // 現在のシアターのカウント
    CheckAnomalies checkAnomalies;

    public bool isExsitAnomaly = false; // 異変があるか
    public bool isBack = false; // 引き戻したか
    bool isInGame = false;

    bool once = false;
    bool titleStateSet = false; // タイトルステートが設定されたかどうか

    public enum GameState
    {
        Title,
        Menu,
        Tutorial, // インゲーム初めの異変がない状態
        CheckAnomaliesState, // 異変判定、仕様書のA
        FindingAnomalies, // 異変を探す、仕様書のB
        GameOver,
        GameClear
    }
    public GameState currentState;

    protected override void Init()
    {
        base.Init();
        // VSyncCount を Dont Sync に変更
        QualitySettings.vSyncCount = 0;
        // fps60を目標に設定
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "InGame")
        {
            isInGame = true;
            titleStateSet = false; 
        }
        else
        {
            once = false;
            isInGame = false;
            if (!titleStateSet)
            {
                ChangeToTitleState();
                titleStateSet = true; 
            }
        }

        if (!once && isInGame)
        {
            ChangeToTutorialState();
            CurrentNum = 0;
            checkAnomalies = GameObject.Find("GameStateController").GetComponent<CheckAnomalies>();
            player = GameObject.Find("Player").gameObject;
            once = true;
        }
        StateHandler();
    }

    // ゲームの状態を管理
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
            case GameState.CheckAnomaliesState:
                CheckAnomaly();
                break;
            case GameState.FindingAnomalies:
                FindingAnomaly();
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

    // 外側からゲームの状態を変更
    public void SetState(GameState newState)
    {
        currentState = newState;
        Debug.Log("状態変更:" + currentState);
        // 状態の初期化処理を入れる
        switch (currentState)
        {
            case GameState.Title:
                // TitleInit();
                break;
            case GameState.Menu:
                // MenuInit();
                break;
            case GameState.Tutorial:
                break;
            case GameState.CheckAnomaliesState:
                break;
            case GameState.FindingAnomalies:
                break;
            case GameState.GameOver:
                // GameOverInit();
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
    private void FindingAnomaly()
    {
    }

    private void GameOver()
    {
    }

    private void GameClear()
    {
    }

    private void CheckAnomaly()
    {
        checkAnomalies.Check(isBack);
        checkAnomalies.Lottery(false);
        ChangeToFindingAnomaliesState();
    }

    public void ChangeToTitleState() => SetState(GameState.Title);
    public void ChangeToMenuState() => SetState(GameState.Menu);
    public void ChangeToTutorialState() => SetState(GameState.Tutorial);
    public void ChangeToCheckAnomaliesState() => SetState(GameState.CheckAnomaliesState);
    public void ChangeToFindingAnomaliesState() => SetState(GameState.FindingAnomalies);
    public void ChangeToGameClearState() => SetState(GameState.GameClear);
}
