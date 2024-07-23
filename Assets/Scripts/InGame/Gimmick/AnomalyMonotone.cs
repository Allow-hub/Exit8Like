using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class AnomalyMonotone : AnomalyBase
{
    [SerializeField] private bool isClear = false;
    [SerializeField] private GameObject player;
    [SerializeField] private Volume vol;
    [SerializeField] private float distanceFromPlayer = 2f;
    [SerializeField] private float anomalyDistance = 25;
    [SerializeField] private int number;
    [SerializeField] private string explain;
    private bool hasCheckedDistance = false;
    private bool once = false;
    private ChannelMixer channelMixer;
    private ColorCurves colorCurves;
    private void Start()
    {
        SetProperety();
        if (vol.profile.TryGet<ChannelMixer>(out channelMixer) && vol.profile.TryGet<ColorCurves>(out colorCurves))
        {
            colorCurves.active = false;
            channelMixer.active = false;
        }
        StartCoroutine(StartEffect());
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
        colorCurves.active = false;
        channelMixer.active = false;
    }

    private IEnumerator StartEffect()
    {
        while (IsAnomaly)
        {
            if (!hasCheckedDistance)
            {
                float distance = Vector3.Distance(this.transform.position, GameManager.Instance.player.transform.position);
                //Debug.Log(distance);
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
                channelMixer.active = true;
                colorCurves.active = true;
                once = true;
            }
            yield return null;
        }
        yield return null;
    }
}
