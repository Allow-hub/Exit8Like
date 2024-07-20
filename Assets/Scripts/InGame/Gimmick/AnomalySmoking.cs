using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnomalySmoking : AnomalyBase
{
    [SerializeField] private bool isClear = false;
    [SerializeField] private float distanceFromPlayer = 2f;
    [SerializeField] private Sprite[] smoke;
    [SerializeField] private float coolDown = 0.3f;
    [SerializeField] private float disappearTime = 0.5f; // ���������鎞�Ԃ�ǉ�

    private bool reverseOrder = false;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        SetProperety();
        Animation(); // �e�X�g�p�ɌĂяo��
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

            for (int i = 0; i < smoke.Length; i++)
            {
                spriteRenderer.sprite = smoke[i];
                yield return new WaitForSeconds(coolDown);
            }

            // �X�v���C�g������
            spriteRenderer.sprite = null;
            yield return new WaitForSeconds(disappearTime);
        }
    }
}