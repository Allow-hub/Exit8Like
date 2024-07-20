using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugAnomaly : MonoBehaviour
{
    [SerializeField] private int number;

    private void Start()
    {
        //DebugAnomalies(number);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.B)) 
            DebugAnomalies(number);
    }
    public void DebugAnomalies(int num)
    {
        // 全ての AnomalyBase オブジェクトを取得
        AnomalyBase[] allAnomalies = FindObjectsOfType<AnomalyBase>();

        // 番号が一致するものをフィルタリングして PlayAnomaly メソッドを実行
        foreach (AnomalyBase anomaly in allAnomalies)
        {
            if (anomaly.Number == num)
            {
                anomaly.PlayAnomaly(anomaly.gameObject);
                Debug.Log(anomaly.gameObject.name);
            }
        }
    }
}