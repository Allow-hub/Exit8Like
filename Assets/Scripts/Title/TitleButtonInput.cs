using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleButtonInput : MonoBehaviour
{
    //[SerializeField] Button startButton,optionButton,exitButton;
    [SerializeField] GameObject mainCanvas, optionCanvas;
    [SerializeField] private Image fade;
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
        if (Input.anyKey)
            StartCoroutine(Fade());
    }
    public  void OnInGame()
    {
        SceneManager.LoadScene(1);
        //BGMManager.I.StopBGM();
    }

    IEnumerator Fade()
    {

        // Imageコンポーネントを使ってカラーを操作する場合
        Image fadeImage = fade.GetComponent<Image>();
        Color canvasColor = fadeImage.color;

        float startAlpha = 0f;
        float endAlpha = 1f; // アルファ値は0.0f〜1.0fの範囲
        float duration = 1.0f;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            canvasColor.a = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / duration);
            fadeImage.color = canvasColor; // 色を更新
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        // 最終的なアルファ値を設定
        canvasColor.a = endAlpha;
        fadeImage.color = canvasColor;
        yield return new WaitForSeconds(1f);
        OnInGame();

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
