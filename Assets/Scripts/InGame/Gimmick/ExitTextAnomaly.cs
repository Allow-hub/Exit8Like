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
    private int originalText;

    private void Start()
    {
        SetProperety();
        if (GameManager.Instance == null) return;
        originalText = GameManager.Instance.CurrentNum;
    }

    public override void Animation()
    {
        base.Animation();
        tex.text = anomalyText;
    }

    public override void ReverseAnomaly()
    {
        base.ReverseAnomaly();
        tex.text = originalText.ToString();
    }

    private void SetProperety()
    {
        IsClear = isClear;
        DistanceFromPlayer = distanceFromPlayer;
        Number = number;
        Explain = explain;
    }
}
