using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnomalyHorrorFace : AnomalyBase
{
    [SerializeField] private GameObject anomaly;
    [SerializeField] private bool isClear = false;
    [SerializeField] private float distanceFromPlayer = 200f;
    [SerializeField] private int number;
    [SerializeField] private string explain;
    [SerializeField] private float disappearTime = 0.5f;

    private bool once = false;
    private bool hasCheckedDistance = false;

    void Awake()
    {
        SetProperety();
        anomaly.gameObject.SetActive(false);
    }


    public override void Animation()
    {
        base.Animation();
        StartCoroutine(StartAnomaly());
    }
    public override void ReverseAnomaly()
    {
        base.ReverseAnomaly();
        anomaly.gameObject.SetActive(false);
    }

    private void SetProperety()
    {
        IsClear = isClear;
        DistanceFromPlayer = distanceFromPlayer;
        Number = number;
        Explain = explain;
    }

    private IEnumerator StartAnomaly()
    {
        while (IsAnomaly)
        {
            if (!hasCheckedDistance)
            {
                float distance = Vector3.Distance(this.transform.position, GameManager.Instance.player.transform.position);

                if (distance < 15)
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
                anomaly.gameObject.SetActive(true);
                SEManager.Instance.ScreamSe();
                yield return new WaitForSeconds(disappearTime);
                anomaly.gameObject.SetActive(false);
                SEManager.Instance.StopSe();
                once = true;
            }
            yield return null;
        }
    }
}
