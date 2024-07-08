using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAnomalies : MonoBehaviour
{
    [SerializeField] private GameObject anomalyParent;
    [SerializeField] private GameObject notAnomalyObject;
    [SerializeField] private float initProb = 20;
    private float currentProb;//�ٕς��I�΂�Ȃ������Ƃ����Z���邽��
    private const float addProb = 20;
    private List<GameObject> anomalyObjects = new List<GameObject>();
    private AnomalyBase anomalyBase;

    private bool existAnomaly=false;

    private void OnEnable()
    {
        TurnBackCollider.onTurnBack += Check;
    }

    private void OnDisable()
    {
        TurnBackCollider.onTurnBack -= Check;
    }

    private void Awake()
    {
        currentProb = initProb;
        // anomalyParent ��null�łȂ����Ƃ��m�F
        if (anomalyParent != null)
        {
            // anomalyParent �̎q�I�u�W�F�N�g�̐����擾
            int childCount = anomalyParent.transform.childCount;

            // �q�I�u�W�F�N�g�����X�g�ɒǉ����Ă���
            for (int i = 0; i < childCount; i++)
            {
                GameObject childObject = anomalyParent.transform.GetChild(i).gameObject;
                anomalyObjects.Add(childObject);
                childObject.SetActive(false); // �q�I�u�W�F�N�g���A�N�e�B�u�ɂ���
            }

            // Lottery() ���\�b�h�͕K�v�ȃ^�C�~���O�ŌĂяo��
        }
        else
        {
            Debug.LogError("Anomaly Parent is not assigned in CheckAnomalies script.");
        }
        
    }
    private void Start()
    {
        Lottery();
    }

    //���I
    public void Lottery()
    {
        int anomalyProb = Random.Range(0, 100);
        if (currentProb <= anomalyProb)
        {
            Anomaly();
        }
        else
        {
            NotAnomaly();
        }

    }

    private void NotAnomaly()
    {
        notAnomalyObject.gameObject.SetActive(true);
        existAnomaly = false;
        currentProb += addProb;
    }

    private void Anomaly()
    {
        notAnomalyObject.gameObject.SetActive(false);
        // �ُ킪��A�N�e�B�u�ȃC���f�b�N�X��ێ����郊�X�g���쐬����
        List<int> notClearIndices = new List<int>();

        // �ُ킪 IsClear �� false �̏ꍇ�ɂ��̃C���f�b�N�X�����X�g�ɒǉ�����
        for (int i = 0; i < anomalyObjects.Count; i++)
        {
            AnomalyBase anomaly = anomalyObjects[i].GetComponent<AnomalyBase>();

            if (anomaly != null && !anomaly.IsClear)
            {
                notClearIndices.Add(i);
            }
            anomalyObjects[i].SetActive(false);
        }

        // IsClear �� false �ُ̈킪������Ȃ��ꍇ�͌x�����o���ď������I������
        if (notClearIndices.Count == 0)
        {
            Debug.LogWarning("IsClear �� false �ُ̈킪������܂���ł����B");
            NotAnomaly();
            return;
        }

        // ��A�N�e�B�u�Ȉُ�̒����烉���_���ɃC���f�b�N�X��I��
        int randomIndex = Random.Range(0, notClearIndices.Count);
        int selectedIndex = notClearIndices[randomIndex];

        // �I�΂ꂽ�ُ���A�N�e�B�u�ɂ���
        anomalyBase = anomalyObjects[selectedIndex].GetComponent<AnomalyBase>();
        anomalyObjects[selectedIndex].SetActive(true);

        // �K�v�ɉ����āA�I�΂ꂽ�ُ�̏������O�o�͂���
        Debug.Log("�I�����ꂽ�ُ�: " + anomalyObjects[selectedIndex].name);
        currentProb = initProb;
        existAnomaly = true;
    }

    //�ٕς̐���
    public void Check()
    {
        if (GameManager.Instance == null) return;
        if (existAnomaly)
        {

        }
        else
        {

        }
    }
}
