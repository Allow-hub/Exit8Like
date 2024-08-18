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
    private bool isAnimating = false;
    // Start is called before the first frame update
    void Start()
    {
        fade.color = Color.black;
        StartCoroutine(FadeOut());
        //exitButton.onClick.AddListener(OnExit);
    }

    private void Update()
    {
        if (isAnimating) return;
        if (Input.anyKey)
        {
            StartCoroutine(Fade());
            isAnimating = true;
        }
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
    IEnumerator FadeOut()
    {

        // Imageコンポーネントを使ってカラーを操作する場合
        Image fadeImage = fade.GetComponent<Image>();
        Color canvasColor = fadeImage.color;

        float startAlpha = 1f;
        float endAlpha = 0f; // アルファ値は0.0f〜1.0fの範囲
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
