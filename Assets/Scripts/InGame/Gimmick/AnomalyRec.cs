using System.Collections;
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
    private bool hasCheckedDistance = false;
    private Coroutine startEffectCoroutine;
    private FilmGrain filmGrain;
    private ChromaticAberration chromaticAberration;

    void Start()
    {
        SetProperety();
        // ボリュームからエフェクトを取得
        if (vol.profile.TryGet<FilmGrain>(out filmGrain) && vol.profile.TryGet<ChromaticAberration>(out chromaticAberration))
        {
            // エフェクトの初期値を設定
            filmGrain.intensity.value = 0f;
            chromaticAberration.intensity.value = 0f;
            rec.color = new Color(rec.color.r, rec.color.g, rec.color.b, 0f);
        }
    }

    public override void Animation()
    {
        if (startEffectCoroutine != null)
        {
            StopCoroutine(startEffectCoroutine);
        }
        hasCheckedDistance = false;
        startEffectCoroutine = StartCoroutine(StartEffect());
    }

    private IEnumerator StartEffect()
    {
        float duration = 4f;
        float elapsedTime = 0f;
        Color recColor = rec.color;

        while (IsAnomaly)
        {
            if (!hasCheckedDistance)
            {
                float distance = Vector3.Distance(this.transform.position, GameManager.Instance.player.transform.position);
                //Debug.Log(distance);
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

            while (elapsedTime < duration)
            {
                elapsedTime += Time.deltaTime;
                float t = elapsedTime / duration;

                // Film Grain の Intensity を 0 から 1 へ
                if (filmGrain != null)
                {
                    filmGrain.intensity.value = Mathf.Lerp(0f, 1f, t);
                }

                // Chromatic Aberration の Intensity を 0 から 0.4 へ
                if (chromaticAberration != null)
                {
                    chromaticAberration.intensity.value = Mathf.Lerp(0f, 0.4f, t);
                }

                // rec の alpha 値を 0 から 1 へ
                recColor.a = Mathf.Lerp(0f, 1f, t);
                rec.color = recColor;

                yield return null;
            }
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
        Number = number;
        Explain = explain;
    }

    public override void ReverseAnomaly()
    {
        if (startEffectCoroutine != null)
        {
            StopCoroutine(startEffectCoroutine);
        }
        // エフェクトをリセット
        if (filmGrain != null)
        {
            filmGrain.intensity.value = 0f;
        }
        if (chromaticAberration != null)
        {
            chromaticAberration.intensity.value = 0f;
        }
        rec.color = new Color(rec.color.r, rec.color.g, rec.color.b, 0f);
    }
}
