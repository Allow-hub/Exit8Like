using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class AnomalyRec : AnomalyBase
{
    [SerializeField] private bool isClear = false;
    [SerializeField] private float distanceFromPlayer = 2f; 
    [SerializeField] private Image rec;
    [SerializeField] private Volume vol;
    [SerializeField] private int number;
    [SerializeField] private string explain; 
    FilmGrain filmGrain;

    private ChromaticAberration chromaticAberration;
    // Start is called before the first frame update
    void Start()
    {
        SetProperety();
       
    }

    public override void Animation()
    {
        base.Animation();
        StartCoroutine(StartEffect());

    }
    IEnumerator StartEffect()
    {
        float duration = 2f;
        float elapsedTime = 0f;

        Color recColor = rec.color;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration;

            // Film Grain の Intensity を 0 から 1 へ
            if (filmGrain != null)
            {
                filmGrain.intensity.value = Mathf.Lerp(0f, 1f, t);
            }

            // Chromatic Aberration の Intensity を 0 から 0.25 へ
            if (chromaticAberration != null)
            {
                chromaticAberration.intensity.value = Mathf.Lerp(0f, 0.25f, t);
            }

            // rec の alpha 値を 0 から 1 へ
            recColor.a = Mathf.Lerp(0f, 1f, t);
            rec.color = recColor;

            yield return null;
        }

        // 最後に完全な値をセット
        if (filmGrain != null)
        {
            filmGrain.intensity.value = 1f;
        }
        if (chromaticAberration != null)
        {
            chromaticAberration.intensity.value = 0.25f;
        }
        recColor.a = 1f;
        rec.color = recColor;
    }
    private void SetProperety()
    {
        IsClear = isClear;
        DistanceFromPlayer = distanceFromPlayer;
     //   spriteRenderer = GetComponent<SpriteRenderer>();
        Number = number;
        Explain = explain;
    }
    public override void ReverseAnomaly()
    {
    }
}
