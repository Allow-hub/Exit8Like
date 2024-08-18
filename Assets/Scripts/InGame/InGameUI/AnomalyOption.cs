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
    [SerializeField] private List<AnomalyBase> anomalyObjects = new List<AnomalyBase>();

    private AnomalyBase anomalyBaseCheck;


 
    public void OnPointerEnter(int num)
    {
        // インデックスが範囲内かチェック
        if (num >= 0 && num < anomalyObjects.Count)
        {
            Debug.Log("Pointer Entered: " + anomalyObjects[num].name + anomalyObjects[num].Explain + anomalyObjects[num].IsClear);

            // 最新の IsClear 状態を確認
            if (anomalyObjects[num].IsClear == false)
            {
                tex.text = "???";
            }
            else
            {
                tex.text = anomalyObjects[num].Explain;
            }
        }
        else
        {
            Debug.LogWarning("Invalid index: " + num);
            tex.text = "Invalid selection";
        }
    }

}
