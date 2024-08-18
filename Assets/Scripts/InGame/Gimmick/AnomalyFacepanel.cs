using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnomalyFacepanel : AnomalyBase
{
    [SerializeField] private bool isClear = false;
    [SerializeField] private float distanceFromPlayer = 200f;
    [SerializeField] private int number;
    [SerializeField] private string explain;

    [SerializeField] private GameObject Kohame;
    [SerializeField] private GameObject KohameAnomaly;

    // Start is called before the first frame update
    void Awake()
    {
        SetProperety();
        Kohame.SetActive(true);
        KohameAnomaly.SetActive(false);

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
        Kohame.SetActive(false);
        KohameAnomaly.SetActive(true);
    }

    public override void ReverseAnomaly()
    {
        base.ReverseAnomaly();
        Kohame.SetActive(true);
        KohameAnomaly.SetActive(false);

    }

}
