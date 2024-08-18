using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShopAnomaly : AnomalyBase
{
    [SerializeField] private bool isClear = false;
    [SerializeField] private float distanceFromPlayer = 200f;
    [SerializeField] private int number;
    [SerializeField] private string explain;

    [SerializeField] private GameObject dai;
    [SerializeField] private GameObject daiAnomaly;

    // Start is called before the first frame update
    void Awake()
    {
        SetProperety();
        dai.SetActive(true);
        daiAnomaly.SetActive(false);
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
        base.Animation();
        dai.SetActive(false);
        daiAnomaly.SetActive(true);
    }

    public override void ReverseAnomaly()
    {
        base.ReverseAnomaly();
        dai.SetActive(true);
        daiAnomaly.SetActive(false);
    }


}
