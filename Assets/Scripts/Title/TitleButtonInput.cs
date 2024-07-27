using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleButtonInput : MonoBehaviour
{
    //[SerializeField] Button startButton,optionButton,exitButton;
    [SerializeField] GameObject mainCanvas, optionCanvas;
    // Start is called before the first frame update
    void Start()
    {
        //mainCanvas.SetActive(true);
        //optionCanvas.SetActive(false);
        //startButton.onClick.AddListener(OnInGame);
        //optionButton.onClick.AddListener(OnOption);
        //exitButton.onClick.AddListener(OnExit);
    }

    private void Update()
    {
        if(Input.anyKey)
            OnInGame();
    }
    public  void OnInGame()
    {
        SceneManager.LoadScene(1);
        BGMManager.I.StopBGM();
    }

    //public void OnOption()
    //{
    //    optionCanvas.gameObject.SetActive(true);
    //}

    //public void OnExit()
    //{
    //    optionCanvas.gameObject.SetActive(false);
    //    mainCanvas.SetActive(true);
    //}
}
