using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnomalyPanel : AnomalyBase
{
    [SerializeField] private bool isClear = false;
    [SerializeField] private float distanceFromPlayer = 200f;
    [SerializeField] private int number;
    [SerializeField] private string explain;

    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject poster1;
    [SerializeField] private GameObject poster2;

    // Start is called before the first frame update
    void Awake()
    {
        SetProperety();
        panel.SetActive(false);
        poster1.SetActive(false);
        poster2.SetActive(false);

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
        panel.SetActive(true);
        poster1.SetActive (true);
        poster2.SetActive(true);
    }

    public override void ReverseAnomaly()
    {
        base.ReverseAnomaly();
        panel.SetActive(false);
        poster1.SetActive(false);
        poster2.SetActive(false);


    }
}
