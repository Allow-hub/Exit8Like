using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnomalyHair : AnomalyBase
{
    [SerializeField] private bool isClear = false;
    [SerializeField] private float distanceFromPlayer = 2f;
    [SerializeField] private Sprite[] normalHair;
    [SerializeField] private GameObject moveHair;
    [SerializeField] private float coolDown = 0.3f;
    [SerializeField] private float moveSpeed=1;
    [SerializeField] private Rigidbody rb;

    private bool reverseOrder = false;
    private void Start()
    {
        SetProperety();

    }
    public override void Animation()
    {
        base.Animation();

        StartCoroutine(ChangeSprite());
        Move();
    }

    private void SetProperety()
    {
        IsClear = isClear;
        DistanceFromPlayer = distanceFromPlayer;
    }

    private void Move()
    {
        rb.velocity = new Vector3(moveSpeed, 0, 0);
    }

    private IEnumerator ChangeSprite()
    {
        while (true)
        {
            if (!reverseOrder)
            {
                for (int i = 0; i < normalHair.Length; i++)
                {
                    spriteRenderer.sprite = normalHair[i];
                    yield return new WaitForSeconds(coolDown);
                }
            }
            else
            {
                for (int i = normalHair.Length - 1; i >= 0; i--)
                {
                    spriteRenderer.sprite = normalHair[i];
                    yield return new WaitForSeconds(coolDown);
                }
            }

            reverseOrder = !reverseOrder;
        }
    }
}
