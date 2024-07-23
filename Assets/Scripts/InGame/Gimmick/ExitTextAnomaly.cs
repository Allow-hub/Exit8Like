using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ExitTextAnomaly : AnomalyBase
{
    [SerializeField] private bool isClear = false;
    [SerializeField] private TextMeshProUGUI tex;
    public string anomalyText;
    [SerializeField] private float distanceFromPlayer = 200f;
    [SerializeField] private int number;
    [SerializeField] private string explain;
    private void Start()
    {
        SetProperety();
    }
    public override void Animation()
    {
        base.Animation();
        tex.text = anomalyText;
    }
    public override void ReverseAnomaly()
    {
        base.ReverseAnomaly();
        tex.text = GameManager.Instance.CurrentNum.ToString();
    }


    private void SetProperety()
    {
        IsClear = isClear;
        DistanceFromPlayer = distanceFromPlayer;
        //spriteRenderer = GetComponent<SpriteRenderer>();
        Number = number;
        Explain = explain;
    }
}
