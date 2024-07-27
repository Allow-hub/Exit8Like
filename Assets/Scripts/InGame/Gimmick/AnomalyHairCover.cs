using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AnomalyHairCover : AnomalyBase
{
    [SerializeField] private bool isClear = false;
    [SerializeField] private float distanceFromPlayer = 200f;
    [SerializeField] private int number;
    [SerializeField] private string explain;
    [SerializeField] private Sprite[] back, forward;
    [SerializeField] private SpriteRenderer backSpriteRenderer, forwardSpriteRenderer;
    [SerializeField] private float coolDown = 0.4f;
    private bool reverseOrder = false;
    private bool hasCheckedDistance = false;

    private void Start()
    {
        SetProperety();
        StartCoroutine(ChangeSprite());
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
        StartCoroutine(ChangeSprite());
    }
    public override void ReverseAnomaly()
    {
        base.ReverseAnomaly();
    }

    private IEnumerator ChangeSprite()
    {

        while (true)
        {
            //if (!hasCheckedDistance)
            //{
            //    float distance = Vector3.Distance(this.transform.position, GameManager.Instance.player.transform.position);

            //    if (distance < 15)
            //    {
            //        hasCheckedDistance = true;
            //    }
            //    else
            //    {
            //        yield return null;
            //        continue;
            //    }
            //}

          

            if (!reverseOrder)
            {
                for (int i = 0; i < back.Length; i++)
                {
                    backSpriteRenderer.sprite = back[i];
                    forwardSpriteRenderer.sprite = forward[i];
                    yield return new WaitForSeconds(coolDown);
                }
            }
            else
            {
                for (int i = back.Length - 1; i >= 0; i--)
                {

                    backSpriteRenderer.sprite = back[i];
                    forwardSpriteRenderer.sprite = forward[i];
                    yield return new WaitForSeconds(coolDown);
                }
            }

            reverseOrder = !reverseOrder;
        }
    }
}
