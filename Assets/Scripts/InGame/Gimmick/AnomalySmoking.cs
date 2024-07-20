using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnomalySmoking : AnomalyBase
{
    [SerializeField] private bool isClear = false;
    [SerializeField] private float distanceFromPlayer = 2f;
    [SerializeField] private Sprite[] smoke;
    [SerializeField] private float coolDown = 0.3f;
    [SerializeField] private float disappearTime = 0.5f; // 煙が消える時間を追加

    private bool reverseOrder = false;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        SetProperety();
        Animation(); // テスト用に呼び出し
    }

    public override void Animation()
    {
        base.Animation();
        StartCoroutine(ChangeSprite());
    }

    private void SetProperety()
    {
        IsClear = isClear;
        DistanceFromPlayer = distanceFromPlayer;
    }

    private IEnumerator ChangeSprite()
    {
        while (true)
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