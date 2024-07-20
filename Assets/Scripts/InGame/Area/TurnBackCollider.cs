using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TurnBackCollider : MonoBehaviour
{
    public delegate void TurnBack();
    public static TurnBack onTurnBack;
    [SerializeField] private Image fade;
    [SerializeField] private GameObject player;
    Rigidbody rb;
    private void Start()
    {
        rb=player.GetComponent<Rigidbody>();
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

    private IEnumerator FadeIn()
    {
        rb.velocity = Vector3.zero;
        PlayerController playerController = player.GetComponent<PlayerController>();
        playerController.enabled = false;
        RectTransform rectTransform = fade.GetComponent<RectTransform>();
        Vector2 startSize = new Vector2(0, 0);
        Vector2 endSize = new Vector2(2500, 2500);
        float duration = 1.0f;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            rectTransform.sizeDelta = Vector2.Lerp(startSize, endSize, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        rectTransform.sizeDelta = endSize;
        yield return new  WaitForSeconds(1f);
        StartCoroutine(FadeOut());
    }
    private IEnumerator FadeOut()
    {
        RectTransform rectTransform = fade.GetComponent<RectTransform>();
        Vector2 startSize = new Vector2(2500, 2500);
        Vector2 endSize = new Vector2(0, 0);
        float duration = 1.0f;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            rectTransform.sizeDelta = Vector2.Lerp(startSize, endSize, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        PlayerController playerController = player.GetComponent<PlayerController>();
        playerController.enabled = true;
        rectTransform.sizeDelta = endSize;
    }
}
