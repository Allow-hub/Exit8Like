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
    [SerializeField] private GameObject blackEye; // 動かす黒目
    [SerializeField] private GameObject whiteEye;
    [SerializeField] private GameObject eyeLimitLeft; // 目の制限左
    [SerializeField] private GameObject eyeLimitRight; // 目の制限右
    [SerializeField] private GameObject player;

    [SerializeField] private float moveSpeed = 1.0f; // 黒目の動くスピード
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
        // 黒目の位置を範囲内に制限
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
        // 異変抽選側で親のIsAnomalyをtrueにしてる
        while (true )
        {
            // 親の距離を測るコードは不都合があったのでここで確認
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
                    continue; // 条件が通るまでここから先の処理はスキップ
                }
            }
            Vector3 playerPos = player.transform.position;
            Vector3 direction = (playerPos - blackEye.transform.position).normalized; // プレイヤーの方向を計算
            direction.y = 0; // Y軸方向の移動を無効にする
            direction.z = 0; // Z軸方向の移動を無効にする
            blackEye.transform.position += direction * moveSpeed * Time.deltaTime; // 徐々にプレイヤーの方向に動かす

            yield return new WaitForSeconds(0.1f);
        }
    }
}
