using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnomalyMikan : AnomalyBase
{
    [SerializeField] private bool isClear = false;
    [SerializeField] private float distanceFromPlayer = 200f;
    [SerializeField] private int number;
    [SerializeField] private string explain;

    [SerializeField] private GameObject reji;
    [SerializeField] private GameObject mikan;

    // Start is called before the first frame update
   
    void Awake()
    { 
        SetProperety();
        reji.SetActive(true);
        mikan.SetActive(false);
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
        reji.SetActive(false);
        mikan.SetActive(true);
    }

    public override void ReverseAnomaly()
    {
        base.ReverseAnomaly();
        reji.SetActive(true);
        mikan.SetActive(false);

    }
    // Update is called once per frame

}
