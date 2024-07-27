using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;  // EventTrigger を使用するために必要

public class AnomalyOption : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tex;
    [SerializeField] private GameObject[] chear;
    private SpriteRenderer spriteRenderer;
    private List<AnomalyBase> anomalyObjects = new List<AnomalyBase>();

    private AnomalyBase anomalyBaseCheck;

    void Start()
    {
        // AnomalyBase コンポーネントを持つすべてのオブジェクトを取得
        AnomalyBase[] anomalies = FindObjectsOfType<AnomalyBase>();
        foreach (AnomalyBase anomaly in anomalies)
        {
            anomalyObjects.Add(anomaly);
        }

  
    }

    public void OnPointerEnter(int num)
    {
        // マウスが UI 要素に乗ったときの処理
        Debug.Log("Pointer Entered: ");
        if (anomalyObjects[num].IsClear == false)
            tex.text = "???";
        else
        {
            tex.text = anomalyObjects[num].Explain;
        }
    }

    void Update()
    {
        // 必要な更新処理があればここに追加
    }
}
