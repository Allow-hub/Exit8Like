using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    [SerializeField] private int number;
    [SerializeField] private string explain;
    private void Start()
    {
        SetProperety();
    }

    // Update is called once per frame
    void Update()
    {
        //CheckAnomaliesÇ≈åƒÇÒÇ≈Ç¢ÇÈ
        //PlayAnomaly(this.gameObject);
    }

    private void SetProperety()
    {
        IsClear = isClear;
        DistanceFromPlayer = distanceFromPlayer;
        spriteRenderer= gameObject.GetComponent<SpriteRenderer>();
        initSprite=spriteRenderer.sprite;
        Number = number;
        Explain = explain;
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
