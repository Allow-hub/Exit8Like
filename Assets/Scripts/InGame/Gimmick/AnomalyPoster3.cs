using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UIElements;

public class AnomalyPoster3 : AnomalyBase
{
    [SerializeField] private bool isClear = false;
    [SerializeField] private float distanceFromPlayer = 200f;
    [SerializeField] private int number;
    [SerializeField] private string explain;
    [SerializeField] private GameObject poster;
    [SerializeField] private GameObject anomalyPoster;
    [SerializeField] private GameObject blackEye; // ����������
    [SerializeField] private GameObject whiteEye;
    [SerializeField] private GameObject eyeLimitLeft; // �ڂ̐�����
    [SerializeField] private GameObject eyeLimitRight; // �ڂ̐����E
    [SerializeField] private GameObject player;

    [SerializeField] private float moveSpeed = 1.0f; // ���ڂ̓����X�s�[�h
    private bool hasCheckedDistance = false;
    void Start()
    {
        poster.SetActive(true);
        anomalyPoster.SetActive(false);
        blackEye.SetActive(false);
        whiteEye.SetActive(false);
        SetProperty();
        // Debug
        poster.SetActive(false);
        anomalyPoster.SetActive(true);
        blackEye.SetActive(true);
        whiteEye.SetActive(true);
        StartCoroutine(MoveEye());
    }

    void Update()
    {
        // ���ڂ̈ʒu��͈͓��ɐ���
        blackEye.transform.position = new Vector3(
            Mathf.Clamp(blackEye.transform.position.x, eyeLimitLeft.transform.position.x, eyeLimitRight.transform.position.x),
            blackEye.transform.position.y,
            blackEye.transform.position.z
        );
    }

    private void SetProperty()
    {
        IsClear = isClear;
        DistanceFromPlayer = distanceFromPlayer;
        Number = number;
        Explain = explain;
    }

    public override void Animation()
    {
        poster.SetActive(false);
        anomalyPoster.SetActive(true);
        blackEye.SetActive(true);
        whiteEye.SetActive(true);
        StartCoroutine(MoveEye());
    }

    public override void ReverseAnomaly()
    {
        base.ReverseAnomaly();
        poster.SetActive(true);
        anomalyPoster.SetActive(false);
        blackEye.SetActive(false);
        whiteEye.SetActive(false);
    }

    private IEnumerator MoveEye()
    {
        // �ٕϒ��I���Őe��IsAnomaly��true�ɂ��Ă�
        while (true )
        {
            // �e�̋����𑪂�R�[�h�͕s�s�����������̂ł����Ŋm�F
            if (!hasCheckedDistance)
            {
                float distance = Vector3.Distance(this.transform.position, player.transform.position);

                if (distance < distanceFromPlayer)
                {
                    hasCheckedDistance = true;
                }
                else
                {
                    yield return null;
                    continue; // �������ʂ�܂ł��������̏����̓X�L�b�v
                }
            }
            Vector3 playerPos = player.transform.position;
            Vector3 direction = (playerPos - blackEye.transform.position).normalized; // �v���C���[�̕������v�Z
            direction.y = 0; // Y�������̈ړ��𖳌��ɂ���
            direction.z = 0; // Z�������̈ړ��𖳌��ɂ���
            blackEye.transform.position += direction * moveSpeed * Time.deltaTime; // ���X�Ƀv���C���[�̕����ɓ�����

            yield return new WaitForSeconds(0.1f);
        }
    }
}
