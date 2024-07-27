using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;  // EventTrigger ���g�p���邽�߂ɕK�v

public class AnomalyOption : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tex;
    [SerializeField] private GameObject[] chear;
    private SpriteRenderer spriteRenderer;
    private List<AnomalyBase> anomalyObjects = new List<AnomalyBase>();

    private AnomalyBase anomalyBaseCheck;

    void Start()
    {
        // AnomalyBase �R���|�[�l���g�������ׂẴI�u�W�F�N�g���擾
        AnomalyBase[] anomalies = FindObjectsOfType<AnomalyBase>();
        foreach (AnomalyBase anomaly in anomalies)
        {
            anomalyObjects.Add(anomaly);
        }

  
    }

    public void OnPointerEnter(int num)
    {
        // �}�E�X�� UI �v�f�ɏ�����Ƃ��̏���
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
        // �K�v�ȍX�V����������΂����ɒǉ�
    }
}
