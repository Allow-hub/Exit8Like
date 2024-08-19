using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private PlayerAnimation playerAnimation;
    [SerializeField] private Option option;

    [SerializeField] private Image fade;
    [SerializeField] private GameObject player;
    Rigidbody rb;

    private void Start()
    {
        rb = player.GetComponent<Rigidbody>();
        if (GameManager.Instance == null) return;
        playerController.enabled = false;
        playerInput.ResetInput();
        playerAnimation.StopAnimation();
        fade.color = Color.black;
        StartCoroutine(FadeOut());
        StartCoroutine(OpenOptionFirst());
    }
    /// <summary>
    /// 黒Imageのα値操作
    /// </summary>
    /// <returns></returns>
    public IEnumerator FadeIn(float time)
    {
        rb.velocity = Vector3.zero;
        playerController.enabled = false;
        playerInput.ResetInput();
        playerAnimation.StopAnimation();
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

        yield return new WaitForSeconds(time);
        StartCoroutine(FadeOut());
    }

    /// <summary>
    /// 黒Imageのα値操作
    /// </summary>
    /// <returns></returns>
    private IEnumerator FadeOut()
    {
        rb.velocity = Vector3.zero;
        playerController.enabled = false;

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

        playerController.enabled = true;
    }

    private IEnumerator OpenOptionFirst()
    {
        yield return new WaitForSeconds(1f);
        option.ActiveCanvas();

    }
}
