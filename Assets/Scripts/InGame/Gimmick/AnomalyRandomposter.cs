using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class AnomalyRandomposter : AnomalyBase
{
    [SerializeField] private bool isClear = false;
    [SerializeField] private float distanceFromPlayer = 200f;
    [SerializeField] private int number;
    [SerializeField] private string explain;

    [SerializeField] private GameObject[] posters;
    [SerializeField] private Sprite[] images;
    //[SerializeField] private Sprite[] nomal;

    private Sprite[] originalSprite;
    private SpriteRenderer[] AnomalyRenderer;

    // Start is called before the first frame update
    void Start()
    {
        SetProperety();
        originalSprite = new Sprite[posters.Length];
        AnomalyRenderer = new SpriteRenderer[posters.Length];

        for (int i = 0; i < posters.Length; i++)
        {
            AnomalyRenderer[i] = posters[i].GetComponent<SpriteRenderer>();
            originalSprite[i] = AnomalyRenderer[i].sprite;
        }
    }

    public override void Animation()
    {
        base.Animation();
        RandomPoster();
    }

    private void RandomPoster()
    {
        Sprite randomImage = images[Random.Range(0, images.Length)];

        foreach (SpriteRenderer poster in AnomalyRenderer)
        {
            poster.sprite = randomImage;
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
        base.ReverseAnomaly();

        for (int i = 0; i< posters.Length; i++)
        {
            AnomalyRenderer[i].sprite = originalSprite[i];
        }

        //for (int i = 0; i < posters.Length; i++)
        //{
        //    posters[i].GetComponent<SpriteRenderer>().sprite = nomal[i];
        //}
    }


}
