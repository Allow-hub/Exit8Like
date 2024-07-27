using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class AnomalyFace : AnomalyBase
{
    [SerializeField] private bool isClear = false;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject anomalyFace;
    [SerializeField] private float distanceFromPlayer = 2f;
    [SerializeField] private float anomalyDistance = 25;
    [SerializeField] private int number;
    [SerializeField] private string explain;
    private bool hasCheckedDistance = false;
    private bool once = false;
    private void Awake()
    {
        SetProperety();
        anomalyFace.gameObject.SetActive(false);
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
        anomalyFace.gameObject.SetActive(false);
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
                anomalyFace.gameObject.SetActive(true);
                once = true;
            }
            yield return null;
        }
        yield return null;
    }
}
