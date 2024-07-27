using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnomalyClerk : AnomalyBase
{
    [SerializeField] private bool isClear = false;
    [SerializeField] private GameObject player;
    [SerializeField] private Sprite right, left, initSprite;
    [SerializeField] private float distanceFromPlayer = 2f;
    [SerializeField] private int number;
    [SerializeField] private string explain;
    Vector3 playerPos;
    private int count = 0;
    private void Awake()
    {
        SetProperety();
    }

    private void SetProperety()
    {
        IsClear = isClear;
        DistanceFromPlayer = distanceFromPlayer;
        spriteRenderer = GetComponent<SpriteRenderer>(); 
        Number = number;
        Explain = explain;
    }

    public override void Animation()
    {
        base.Animation();
        StartCoroutine(ChangeSprite());

    }
    IEnumerator ChangeSprite()
    {
        while (IsAnomaly)
        {
            count++;
            if (count >= 100000)
            {
                Debug.Log("ˆ—Ž¸”s");
                yield break;
            }
            playerPos = player.transform.position;
            Vector3 anomalyPos = transform.position;
            Vector3 localAnomalyPos = transform.InverseTransformPoint(playerPos);
            if (localAnomalyPos.x > 0.5f)
            {
                spriteRenderer.sprite = right;
            }
            else if (localAnomalyPos.x < -0.5f)
            {
                spriteRenderer.sprite =left;
            }
            else
            {
                spriteRenderer.sprite = initSprite;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
    public override void ReverseAnomaly()
    {
        base.ReverseAnomaly();
        spriteRenderer.sprite = initSprite;
    }
}
