using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ê√ìIÇ»àŸïœ
/// </summary>
public class AnomalyNomal : AnomalyBase
{
    [SerializeField] private bool isClear = false;
    [SerializeField] private float distanceFromPlayer = 200f;
    [SerializeField] private Sprite changeSprite;
    private Sprite initSprite;

    private void Start()
    {
        SetProperety();
    }

    // Update is called once per frame
    void Update()
    {
        //PlayAnomaly(this.gameObject);
    }

    private void SetProperety()
    {
        IsClear = isClear;
        DistanceFromPlayer = distanceFromPlayer;
        spriteRenderer= gameObject.GetComponent<SpriteRenderer>();
        initSprite=spriteRenderer.sprite;
    }

    public override void Animation()
    {
        base.Animation();
        spriteRenderer.sprite = changeSprite;
    }

    public override void ReverseAnomaly()
    {
        spriteRenderer.sprite = initSprite;
    }

}
