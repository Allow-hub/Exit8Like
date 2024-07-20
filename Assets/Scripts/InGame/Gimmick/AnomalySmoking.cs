using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class AnomalySmoking : AnomalyBase
{
    [SerializeField] private bool isClear = false;
    [SerializeField] private float distanceFromPlayer = 2f;
    [SerializeField] private Sprite[] smoke;
    [SerializeField] private float coolDown = 0.3f;



    private bool reverseOrder = false;


    // Start is called before the first frame update
    void Start()
    {
        SetProperety();
    }

    public override void Animation()
    {
        base.Animation();

        StartCoroutine(ChangeSprite());
    }

    private void SetProperety()
    {
        IsClear = isClear;
        DistanceFromPlayer = distanceFromPlayer;
    }

    

    private IEnumerator ChangeSprite()
    {
        while (true)
        {
            if (!reverseOrder)
            {
                for (int i = 0; i < smoke.Length; i++)
                {
                    spriteRenderer.sprite = smoke[i];
                    yield return new WaitForSeconds(coolDown);
                }
            }
            else
            {
                for (int i = smoke.Length - 1; i >= 0; i--)
                {
                    spriteRenderer.sprite = smoke[i];
                    yield return new WaitForSeconds(coolDown);
                }
            }
        }
    }
}
