using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnomalySmoking : AnomalyBase
{
    [SerializeField] private bool isClear = false;
    [SerializeField] private float distanceFromPlayer = 2f;
    [SerializeField] private int number;
    [SerializeField] private string explain;
    [SerializeField] private Sprite[] smoke;
    [SerializeField] private float coolDown = 0.3f;
    [SerializeField] private float disappearTime = 0.5f; // 煙が消える時間を追加
    [SerializeField] private GameObject normal, anomaly;

    private bool reverseOrder = false;

    // Start is called before the first frame update
    void Awake()
    {
        SetProperety();
        anomaly.gameObject.SetActive(false);
        normal.gameObject.SetActive(true);
        //Animation(); // テスト用に呼び出し
    }

    public override void Animation()
    {
        base.Animation();
        normal.gameObject.SetActive(false);
        anomaly.gameObject.SetActive(true);
        StartCoroutine(ChangeSprite());
    }
    public override void ReverseAnomaly()
    {
        base.ReverseAnomaly();
        anomaly.gameObject.SetActive(false);
        normal.gameObject.SetActive(true);
    }
    private void SetProperety()
    {
        IsClear = isClear;
        DistanceFromPlayer = distanceFromPlayer;
        Number = number;
        Explain = explain;
    }

    private IEnumerator ChangeSprite()
    {
        while (IsAnomaly)
        {

            for (int i = 0; i < smoke.Length; i++)
            {
                spriteRenderer.sprite = smoke[i];
                yield return new WaitForSeconds(coolDown);
            }

            // スプライトを消す
            spriteRenderer.sprite = null;
            yield return new WaitForSeconds(disappearTime);
        }
    }
}