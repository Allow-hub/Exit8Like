using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnomalySaineji : AnomalyBase
{
    [SerializeField] private bool isClear = false;
    [SerializeField] private float distanceFromPlayer = 200f;
    [SerializeField] private int number;
    [SerializeField] private string explain;

    [SerializeField] private GameObject Saineji;
    [SerializeField] private GameObject Sainejianomaly;

    // Start is called before the first frame update
    void Awake()
    {
        SetProperety();
        Saineji.SetActive(true);
        Sainejianomaly.SetActive(false);
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
        Saineji.SetActive(false);
        Sainejianomaly.SetActive(true);
    }

    public override void ReverseAnomaly()
    {
        base.ReverseAnomaly();
        Saineji.SetActive(true);
        Sainejianomaly.SetActive(false);
    }


}
