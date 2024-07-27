using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnomalyEndroll : AnomalyBase
{
    [SerializeField] private bool isClear = false;
    [SerializeField] private float distanceFromPlayer = 200f;
    [SerializeField] private float moveSpeed = 1;
    [SerializeField] private int number;
    [SerializeField] private string explain;
    [SerializeField] private RectTransform[] texts; // �e�L�X�g��RectTransform���i�[����z��
    [SerializeField] private float resetPositionY = -300f; // �e�L�X�g�����Z�b�g����Y���W
    [SerializeField] private float upperLimitY = 300f; // �e�L�X�g�����B������Y���W
    [SerializeField] private float scrollDelay = 0.5f; // �e�e�L�X�g�̃X�N���[���J�n�̒x������
    private bool once = false;
    private bool hasCheckedDistance = false;

    void Awake()
    {
        SetProperety();
        // �e�L�X�g���A�N�e�B�u�ɐݒ�
        foreach (RectTransform text in texts)
        {
            text.gameObject.SetActive(false);
        }
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
        StartCoroutine(StartAnomaly());
    }

    public override void ReverseAnomaly()
    {
        base.ReverseAnomaly();
        StopAllCoroutines(); // �S�ẴR���[�`�����~
        ResetTextPositions();
        foreach (RectTransform text in texts)
        {
            text.gameObject.SetActive(false); // �e�L�X�g���A�N�e�B�u�ɐݒ�
        }
    }

    private IEnumerator StartAnomaly()
    {
        while (IsAnomaly)
        {
            if (!hasCheckedDistance)
            {
                float distance = Vector3.Distance(this.transform.position, GameManager.Instance.player.transform.position);
                if (distance < 40)
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
                foreach (RectTransform text in texts)
                {
                    text.gameObject.SetActive(true); // �e�L�X�g���A�N�e�B�u�ɐݒ�
                }
                for (int i = 0; i < texts.Length; i++)
                {
                    StartCoroutine(ScrollTextWithDelay(texts[i], i * scrollDelay));
                }
                once = true;
            }
            yield return null;
        }
    }

    private IEnumerator ScrollTextWithDelay(RectTransform text, float delay)
    {
        yield return new WaitForSeconds(delay);
        while (IsAnomaly)
        {
            text.anchoredPosition += Vector2.up * moveSpeed * Time.deltaTime;
            if (text.anchoredPosition.y > upperLimitY)
            {
                text.anchoredPosition = new Vector2(text.anchoredPosition.x, resetPositionY);
            }
            yield return null;
        }
    }

    private void ResetTextPositions()
    {
        foreach (RectTransform text in texts)
        {
            text.anchoredPosition = new Vector2(text.anchoredPosition.x, resetPositionY);
        }
    }
}
