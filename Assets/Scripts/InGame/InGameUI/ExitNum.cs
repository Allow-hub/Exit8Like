using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ExitNum : MonoBehaviour
{
    private int lastNum;
    [SerializeField] private TextMeshProUGUI tex;
    [SerializeField] private ExitTextAnomaly textAnomaly;

    void Start()
    {
        //if (GameManager.Instance == null)
        //{
        //    Debug.LogError("GameManager.Instance is null.");
        //    return;
        //}

        //if (tex == null)
        //{
        //    Debug.LogError("TextMeshProUGUI is not assigned.");
        //    return;
        //}

        //if (textAnomaly == null)
        //{
        //    Debug.LogError("ExitTextAnomaly is not assigned.");
        //    return;
        //}
        if (GameManager.Instance == null) return;
        lastNum = GameManager.Instance.CurrentNum;
        tex.text = lastNum.ToString();
    }

    void Update()
    {
        if (GameManager.Instance == null || tex == null || textAnomaly == null)
            return;

        if (lastNum != GameManager.Instance.CurrentNum && !textAnomaly.IsAnomaly)
        {
            lastNum = GameManager.Instance.CurrentNum;
            tex.text = lastNum.ToString();
        }
    }
}
