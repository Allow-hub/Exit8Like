using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class AnomalyHair : AnomalyBase
{
    [SerializeField] private bool isClear = false;
    [SerializeField] private float distanceFromPlayer = 2f;
    [SerializeField] private Sprite[] normalHair;
    [SerializeField] private GameObject moveHair;
    [SerializeField] private float coolDown = 0.3f;
    [SerializeField] private float moveSpeed=1;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private int number;
    [SerializeField] private string explain;
    private bool reverseOrder = false; 
    private bool hasCheckedDistance = false;

    private void Start()
    {
        moveHair.gameObject.SetActive(false);
        SetProperety();
        //StartCoroutine(ChangeSprite());
        //Move();
    }
    public override void Animation()
    {
        moveHair.gameObject.SetActive(true);
        StartCoroutine(ChangeSprite());
        Move();
    }

    private void SetProperety()
    {
        IsClear = isClear;
        DistanceFromPlayer = distanceFromPlayer; 
        Number = number;
        Explain = explain;
    }

    private void Move()
    {

        //rb.velocity = new Vector3(moveSpeed, 0, 0);
    }
    public override void ReverseAnomaly()
    {
        base .ReverseAnomaly();
        rb.velocity = Vector3.zero;
        moveHair.gameObject.SetActive (false);
    }

    private IEnumerator ChangeSprite()
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

            rb.velocity = new Vector3(moveSpeed, 0, 0);

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