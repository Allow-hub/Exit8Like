using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TurnBackCollider : MonoBehaviour
{
    public delegate void TurnBack();
    public static TurnBack onTurnBack;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private PlayerAnimation playerAnimation;

    [SerializeField] private Image fade;
    [SerializeField] private GameObject player;
    Rigidbody rb;

    private void Start()
    {
        rb = player.GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (onTurnBack == null) return;
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.isBack = true;
            onTurnBack?.Invoke();
            StartCoroutine(FadeIn());
        }
    }

    /// <summary>
    /// 黒Imageのα値操作
    /// </summary>
    /// <returns></returns>
    private IEnumerator FadeIn()
    {
        rb.velocity = Vector3.zero;
        PlayerController playerController = player.GetComponent<PlayerController>();
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

        yield return new WaitForSeconds(2f);
        StartCoroutine(FadeOut());
    }

    /// <summary>
    /// 黒Imageのα値操作
    /// </summary>
    /// <returns></returns>
    private IEnumerator FadeOut()
    {
        rb.velocity = Vector3.zero;
        PlayerController playerController = player.GetComponent<PlayerController>();
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
}
