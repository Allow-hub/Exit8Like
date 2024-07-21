using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAnomalies : MonoBehaviour
{
    [SerializeField] private GameObject anomalyParent;
    [SerializeField] private GameObject notAnomalyObject;
    [SerializeField] private GameObject notAnomalyArea;
    [SerializeField] private float initProb = 100;
    [SerializeField] private float addPosition = 119;
    private float currentProb;//異変が選ばれなかったとき加算するため
    private const float addProb = 20;
    private List<AnomalyBase> anomalyObjects = new List<AnomalyBase>();

    private AnomalyBase anomalyBaseCheck;
    private void Awake()
    {
        currentProb = initProb;
        // anomalyParent がnullでないことを確認
        if (anomalyParent != null)
        {
            // AnomalyBase コンポーネントを持つすべてのオブジェクトを取得
            AnomalyBase[] anomalies = FindObjectsOfType<AnomalyBase>();
            foreach (AnomalyBase anomaly in anomalies)
            {
                anomalyObjects.Add(anomaly);
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

    //抽選
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
        notAnomalyArea.gameObject.SetActive(true);
        currentProb += addProb;
    }

    private void Anomaly()
    {
        notAnomalyArea.gameObject.SetActive(false);

        // 異常が非アクティブなインデックスを保持するリストを作成する
        List<int> notClearIndices = new List<int>();

        // 異常が IsClear が false の場合にそのインデックスをリストに追加する
        for (int i = 0; i < anomalyObjects.Count; i++)
        {
            //Debug.Log(anomalyObjects[i].IsClear);
            if (anomalyObjects[i] != null && !anomalyObjects[i].IsClear)
            {
                notClearIndices.Add(i);
            }
        }

        // IsClear が false の異常が見つからない場合は警告を出して処理を終了する
        if (notClearIndices.Count == 0)
        {
            Debug.LogError("IsClear が false の異常が見つかりませんでした。");
            NotAnomaly();
            return;
        }

        // 非アクティブな異常の中からランダムにインデックスを選ぶ
        int randomIndex = Random.Range(0, notClearIndices.Count);
        int selectedIndex = notClearIndices[randomIndex];

       // 必要に応じて、選ばれた異常の情報をログ出力する
        Debug.Log("選択された異常: " + anomalyObjects[selectedIndex].name);
        anomalyBaseCheck = anomalyObjects[selectedIndex];
        anomalyBaseCheck.IsAnomaly = true;
        anomalyBaseCheck.PlayAnomaly(anomalyBaseCheck.gameObject);
        currentProb = initProb;
        if (GameManager.Instance == null) return;
        GameManager.Instance.isExsitAnomaly = true;
    }

    //異変の正誤、引数は戻ったときtrue、進んだときfalse
    public void Check(bool isBack)
    {
        if (GameManager.Instance == null) return;
        Rigidbody rb =GameManager.Instance.player.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;

        //異変があるときに
        if (GameManager.Instance.isExsitAnomaly)
        {
            //戻ると加算
            if(isBack)
            {
                if (GameManager.Instance.CurrentNum != 8)
                {
                    GameManager.Instance.CurrentNum++;
                    anomalyBaseCheck.IsClear = true;
                    anomalyBaseCheck.ReverseAnomaly();
                }else if(GameManager.Instance.CurrentNum == 8)
                {
                    anomalyBaseCheck.IsClear = true;
                    anomalyBaseCheck.ReverseAnomaly();

                }
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
        if(anomalyBaseCheck!=null) 
        anomalyBaseCheck.IsAnomaly = false;
    }
}
