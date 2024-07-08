using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAnomalies : MonoBehaviour
{
    [SerializeField] private GameObject anomalyParent;
    [SerializeField] private GameObject notAnomalyObject;
    [SerializeField] private GameObject notAnomalyArea;
    [SerializeField] private float initProb = 20;
    [SerializeField] private float addPosition = 119;
    private float currentProb;//�ٕς��I�΂�Ȃ������Ƃ����Z���邽��
    private const float addProb = 20;
    private List<GameObject> anomalyObjects = new List<GameObject>();
    private AnomalyBase anomalyBase;
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

        }
        else
        {
            Debug.LogError("Anomaly Parent is not assigned in CheckAnomalies script.");
        }
        
    }
    private void Start()
    {
        Lottery(true);
    }

    //���I
    public void Lottery(bool isTutorial)
    {
        int anomalyProb = Random.Range(0, 100);
        if (isTutorial)
            anomalyProb = 100;
        if (anomalyProb<=currentProb)
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
        if (GameManager.Instance == null) return;
        GameManager.Instance.isExsitAnomaly = false;
        for (int i = 0; i < anomalyObjects.Count; i++)
        {
            anomalyObjects[i].SetActive(false);
        }
        notAnomalyArea.gameObject.SetActive(true);
        currentProb += addProb;
    }

    private void Anomaly()
    {
        notAnomalyArea.gameObject.SetActive(false);

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
            Debug.LogError("IsClear �� false �ُ̈킪������܂���ł����B");
            NotAnomaly();
            return;
        }

        // ��A�N�e�B�u�Ȉُ�̒����烉���_���ɃC���f�b�N�X��I��
        int randomIndex = Random.Range(0, notClearIndices.Count);
        int selectedIndex = notClearIndices[randomIndex];

        // �I�΂ꂽ�ُ���A�N�e�B�u�ɂ���
        anomalyBase = anomalyObjects[selectedIndex].GetComponent<AnomalyBase>();
        anomalyObjects[selectedIndex].SetActive(true);
        //anomalyObjects[selectedIndex].gameObject.transform.position = anomalyParent.transform.position;
        // �K�v�ɉ����āA�I�΂ꂽ�ُ�̏������O�o�͂���
        Debug.Log("�I�����ꂽ�ُ�: " + anomalyObjects[selectedIndex].name);
        currentProb = initProb;
        if (GameManager.Instance == null) return;
        GameManager.Instance.isExsitAnomaly = true;
    }

    //�ٕς̐���A�����͖߂����Ƃ�true�A�i�񂾂Ƃ�false
    public void Check(bool isBack)
    {
        if (GameManager.Instance == null) return;
        Rigidbody rb =GameManager.Instance.player.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        //�ٕς�����Ƃ���
        if (GameManager.Instance.isExsitAnomaly)
        {
            //�߂�Ɖ��Z
            if(isBack)
            {
                GameManager.Instance.CurrentNum++;
            }
            else
            {
                notAnomalyObject.gameObject.transform.position = new Vector3(notAnomalyObject.transform.position.x + addPosition, notAnomalyObject.transform.position.y, notAnomalyObject.transform.position.z);

                anomalyParent.transform.position = new Vector3(anomalyParent.transform.position.x + addPosition, anomalyParent.transform.position.y, anomalyParent.transform.position.z);

                GameManager.Instance.CurrentNum = 0;
            }
        }
        else
        {
            if (isBack)
            {

                GameManager.Instance.CurrentNum = 0;
            }
            else
            {
                notAnomalyObject.gameObject.transform.position = new Vector3(notAnomalyObject.transform.position.x + addPosition, notAnomalyObject.transform.position.y, notAnomalyObject.transform.position.z);

                anomalyParent.transform.position = new Vector3(anomalyParent.transform.position.x + addPosition, anomalyParent.transform.position.y, anomalyParent.transform.position.z);
                GameManager.Instance.CurrentNum++;
            }
        }
    }
}
