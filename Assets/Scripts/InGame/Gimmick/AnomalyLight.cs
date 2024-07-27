using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class AnomalyLight : AnomalyBase
{
    [SerializeField] private bool isClear = false;
    [SerializeField] private GameObject player;
    [SerializeField] private Volume vol;
    [SerializeField] private Color targetColor;
    [SerializeField] private float distanceFromPlayer = 2f;
    [SerializeField] private float anomalyDistance = 25;
    [SerializeField] private int number;
    [SerializeField] private string explain;
    private bool hasCheckedDistance = false;
    private bool once = false;
    private ColorAdjustments colorAdjustments;
    private Color initColor;
    // Start is called before the first frame update
    void Awake()
    {
        SetProperety();
        if (vol.profile.TryGet<ColorAdjustments>(out colorAdjustments) )
        {
            initColor = colorAdjustments.colorFilter.value;
        }
    }
    public override void Animation()
    {
        base.Animation();
        StartCoroutine(StartEffect());
    }


    private void SetProperety()
    {
        IsClear = isClear;
        DistanceFromPlayer = distanceFromPlayer;
        //spriteRenderer = GetComponent<SpriteRenderer>();
        Number = number;
        Explain = explain;
    }
    public override void ReverseAnomaly()
    {
        base.ReverseAnomaly();
        colorAdjustments.colorFilter.value = initColor;
    }
    private IEnumerator StartEffect()
    {
        while (IsAnomaly)
        {
            if (!hasCheckedDistance)
            {
                float distance = Vector3.Distance(this.transform.position, GameManager.Instance.player.transform.position);
                Debug.Log(distance);
                if (distance < anomalyDistance)
                {
                    hasCheckedDistance = true;
                }
                else
                {
                    yield return null;
                    continue;
                }
            }
            if (!once)
            {
                SEManager.Instance.MonotoneSe();
                colorAdjustments.colorFilter.value = targetColor;

                once = true;
            }
            yield return null;
        }
        yield return null;
    }
}
