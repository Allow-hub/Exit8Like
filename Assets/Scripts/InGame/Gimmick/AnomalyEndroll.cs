using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnomalyEndroll : AnomalyBase
{
    [SerializeField] private bool isClear = false;
    [SerializeField] private float distanceFromPlayer = 200f;
    [SerializeField] private float moveSpeed = 1;
    [SerializeField] private int number;
    [SerializeField] private string explain;
    [SerializeField] private RectTransform[] texts; // テキストのRectTransformを格納する配列
    [SerializeField] private float resetPositionY = -300f; // テキストをリセットするY座標
    [SerializeField] private float upperLimitY = 300f; // テキストが到達する上限Y座標
    [SerializeField] private float scrollDelay = 0.5f; // 各テキストのスクロール開始の遅延時間
    private bool once = false;
    private bool hasCheckedDistance = false;

    void Awake()
    {
        SetProperety();
        // テキストを非アクティブに設定
        foreach (RectTransform text in texts)
        {
            text.gameObject.SetActive(false);
        }
    }

    private void SetProperety()
    {
        IsClear = isClear;
        DistanceFromPlayer = distanceFromPlayer;
        Number = number;
        Explain = explain;
    }

    public override void Animation()
    {
        StartCoroutine(StartAnomaly());
    }

    public override void ReverseAnomaly()
    {
        base.ReverseAnomaly();
        StopAllCoroutines(); // 全てのコルーチンを停止
        ResetTextPositions();
        foreach (RectTransform text in texts)
        {
            text.gameObject.SetActive(false); // テキストを非アクティブに設定
        }
    }

    private IEnumerator StartAnomaly()
    {
        while (IsAnomaly)
        {
            if (!hasCheckedDistance)
            {
                float distance = Vector3.Distance(this.transform.position, GameManager.Instance.player.transform.position);
                if (distance < 40)
                {
                    hasCheckedDistance = true;
                }
                else
                {
                    yield return null;
                    continue;
                }
            }
            if (!once)
            {
                foreach (RectTransform text in texts)
                {
                    text.gameObject.SetActive(true); // テキストをアクティブに設定
                }
                for (int i = 0; i < texts.Length; i++)
                {
                    StartCoroutine(ScrollTextWithDelay(texts[i], i * scrollDelay));
                }
                once = true;
            }
            yield return null;
        }
    }

    private IEnumerator ScrollTextWithDelay(RectTransform text, float delay)
    {
        yield return new WaitForSeconds(delay);
        while (IsAnomaly)
        {
            text.anchoredPosition += Vector2.up * moveSpeed * Time.deltaTime;
            if (text.anchoredPosition.y > upperLimitY)
            {
                text.anchoredPosition = new Vector2(text.anchoredPosition.x, resetPositionY);
            }
            yield return null;
        }
    }

    private void ResetTextPositions()
    {
        foreach (RectTransform text in texts)
        {
            text.anchoredPosition = new Vector2(text.anchoredPosition.x, resetPositionY);
        }
    }
}
