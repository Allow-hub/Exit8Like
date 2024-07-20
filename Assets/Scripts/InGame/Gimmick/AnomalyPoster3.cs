using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UIElements;

public class AnomalyPoster3 : AnomalyBase
{
    [SerializeField] private bool isClear = false;
    [SerializeField] private GameObject poster;
    [SerializeField] private GameObject anomalyPoster;
    [SerializeField] private GameObject blackEye;
    [SerializeField] private GameObject whiteEye;
    [SerializeField] private GameObject RightEyeParts1;
    [SerializeField] private GameObject RightEyeParts2;
    [SerializeField] private GameObject LeftEyeParts1;
    [SerializeField] private GameObject LeftEyeParts2;
    [SerializeField] private GameObject player;

    Vector3 RightEyePos1;
    Vector3 RightEyePos2;
    Vector3 LeftEyePos1;
    Vector3 LeftEyePos2;


    public float moveSpeed = 1.0f; // 黒目の動くスピード

    // Start is called before the first frame update
    void Start()
    {
        // 画像の表示/非表示
        poster.SetActive(false);
        anomalyPoster.SetActive(true);
        blackEye.SetActive(true);
        whiteEye.SetActive(true);

        // 範囲指定のObjectのTrnsform
        RightEyePos1 = RightEyeParts1.transform.position;
        RightEyePos2 = RightEyeParts2.transform.position;
        LeftEyePos1 = LeftEyeParts1.transform.position;
        LeftEyePos2 = LeftEyeParts2.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        Move();

        //黒目の位置を範囲内に制限
        blackEye.transform.position = new Vector3(
            Mathf.Clamp (blackEye.transform.position.x, RightEyePos1.x, RightEyePos2.x),
            Mathf.Clamp (blackEye.transform.position.x,LeftEyePos1.x, LeftEyePos2.x),
            blackEye.transform.position.y
            );

    }

    private void Move()
    {
        if(GameManager.Instance==null) return;
        float distance = Vector3.Distance(anomalyPoster.gameObject.transform.position, GameManager.Instance.player.transform.position);
        Debug.Log (distance);


    }
}
