using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnomalyRandomposter : AnomalyBase
{
    [SerializeField] private bool isClear = false;
    [SerializeField] private float distanceFromPlayer = 200f;
    [SerializeField] private int number;
    [SerializeField] private string explain;

    [SerializeField] private GameObject[] posters;
    [SerializeField] private Sprite[] images;

    // Start is called before the first frame update
    void Start()
    {
        SetProperety();

    }


    private void randomPoster()
    {
        Sprite randomImage = images[Random.Range(0, images.Length)];

        foreach (GameObject poster in posters)
        {
            poster.GetComponent<SpriteRenderer>().sprite = randomImage;
        }
    }


    private void SetProperety()
    {
        IsClear = isClear;
        DistanceFromPlayer = distanceFromPlayer;
        Number = number;
        Explain = explain;
    }

    public override void ReverseAnomaly()
    {
    }


}
