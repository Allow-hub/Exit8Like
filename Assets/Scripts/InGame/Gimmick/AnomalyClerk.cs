using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnomalyClerk : AnomalyBase
{
    [SerializeField] private bool isClear = false;
    [SerializeField] private float distanceFromPlayer = 2f;
    Vector3 playerPos;
    private void Start()
    {
        SetProperety();
        StartCoroutine(ChangeSprite());
    }

    private void SetProperety()
    {
        IsClear = isClear;
        DistanceFromPlayer = distanceFromPlayer;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public override void Animation()
    {
        base.Animation();

    }
    IEnumerator ChangeSprite()
    {
        if (GameManager.Instance == null) yield  break;

        playerPos = GameManager.Instance.player.transform.position;
        Vector3 anomalyPos = transform.position;
        Vector3 localAnomalyPos = transform.InverseTransformPoint(playerPos);

        if (localAnomalyPos.x > 0)
        {
            Debug.Log("Player is to the right of the anomaly.");
        }
        else if (localAnomalyPos.x < 0)
        {
            Debug.Log("Player is to the left of the anomaly.");
        }
        else
        {
            Debug.Log("Player is exactly at the anomaly.");
        }

        yield return null;
    }

}
