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
        // �S�Ă� AnomalyBase �I�u�W�F�N�g���擾
        AnomalyBase[] allAnomalies = FindObjectsOfType<AnomalyBase>();

        // �ԍ�����v������̂��t�B���^�����O���� PlayAnomaly ���\�b�h�����s
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