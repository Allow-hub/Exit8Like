using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �ÓI�Ȉٕ�
/// </summary>
public class AnomalyNomal : AnomalyBase
{
    [SerializeField] private bool isClear = false;
    [SerializeField] private float distanceFromPlayer = 200f;
    [SerializeField] private Sprite changeSprite;

    private void Start()
    {
        SetProperety();
    }

    // Update is called once per frame
    void Update()
    {
        PlayAnomaly(this.gameObject);
    }

    private void SetProperety()
    {
        IsClear = isClear;
        DistanceFromPlayer = distanceFromPlayer;
        spriteRenderer= gameObject.GetComponent<SpriteRenderer>();
    }

    public override void Animation()
    {
        base.Animation();
        spriteRenderer.sprite = changeSprite;
    }
}