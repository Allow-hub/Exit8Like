using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public static GameManager Instance => I;
    protected override bool DestroyTargetGameObject => true;
    public GameObject player;
    public int CurrentNum = 0; // ���݂̃V�A�^�[�̃J�E���g
    CheckAnomalies checkAnomalies;

    public bool isExsitAnomaly = false; // �ٕς����邩
    public bool isBack = false; // �����߂�����
    bool isInGame = false;

    bool once = false;
    bool titleStateSet = false; // �^�C�g���X�e�[�g���ݒ肳�ꂽ���ǂ���

    public enum GameState
    {
        Title,
        Menu,
        Tutorial, // �C���Q�[�����߂ٕ̈ς��Ȃ����
        CheckAnomaliesState, // �ٕϔ���A�d�l����A
        FindingAnomalies, // �ٕς�T���A�d�l����B
        GameOver,
        GameClear
    }
    public GameState currentState;

    protected override void Init()
    {
        base.Init();
        // VSyncCount �� Dont Sync �ɕύX
        QualitySettings.vSyncCount = 0;
        // fps60��ڕW�ɐݒ�
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

    // �Q�[���̏�Ԃ��Ǘ�
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
                Debug.Log("�Ή������Ԃ�����܂���");
                break;
        }
    }

    // �O������Q�[���̏�Ԃ�ύX
    public void SetState(GameState newState)
    {
        currentState = newState;
        Debug.Log("��ԕύX:" + currentState);
        // ��Ԃ̏���������������
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
