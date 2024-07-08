using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anomaly1 : AnomalyBase
{
    [SerializeField] private bool isClear=false;
    [SerializeField] private float distanceFromPlayer = 2f;
    
    private void Start()
    {
        SetProperety();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void SetProperety()
    {
        IsClear = isClear;
        DistanceFromPlayer = distanceFromPlayer;
    }

    //public override void PlayAnomaly()
    //{
    //    base.PlayerAnomaly();
    //}
}
