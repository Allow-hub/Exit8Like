using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAnomalies : MonoBehaviour
{
    [SerializeField] private GameObject anomalyParent;
    [SerializeField] private GameObject notAnomalyObject;
    [SerializeField] private float initProb = 20;
    private float currentProb;//異変が選ばれなかったとき加算するため
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
        // anomalyParent がnullでないことを確認
        if (anomalyParent != null)
        {
            // anomalyParent の子オブジェクトの数を取得
            int childCount = anomalyParent.transform.childCount;

            // 子オブジェクトをリストに追加していく
            for (int i = 0; i < childCount; i++)
            {
                GameObject childObject = anomalyParent.transform.GetChild(i).gameObject;
                anomalyObjects.Add(childObject);
                childObject.SetActive(false); // 子オブジェクトを非アクティブにする
            }

            // Lottery() メソッドは必要なタイミングで呼び出す
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

    //抽選
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
        // 異常が非アクティブなインデックスを保持するリストを作成する
        List<int> notClearIndices = new List<int>();

        // 異常が IsClear が false の場合にそのインデックスをリストに追加する
        for (int i = 0; i < anomalyObjects.Count; i++)
        {
            AnomalyBase anomaly = anomalyObjects[i].GetComponent<AnomalyBase>();

            if (anomaly != null && !anomaly.IsClear)
            {
                notClearIndices.Add(i);
            }
            anomalyObjects[i].SetActive(false);
        }

        // IsClear が false の異常が見つからない場合は警告を出して処理を終了する
        if (notClearIndices.Count == 0)
        {
            Debug.LogWarning("IsClear が false の異常が見つかりませんでした。");
            NotAnomaly();
            return;
        }

        // 非アクティブな異常の中からランダムにインデックスを選ぶ
        int randomIndex = Random.Range(0, notClearIndices.Count);
        int selectedIndex = notClearIndices[randomIndex];

        // 選ばれた異常をアクティブにする
        anomalyBase = anomalyObjects[selectedIndex].GetComponent<AnomalyBase>();
        anomalyObjects[selectedIndex].SetActive(true);

        // 必要に応じて、選ばれた異常の情報をログ出力する
        Debug.Log("選択された異常: " + anomalyObjects[selectedIndex].name);
        currentProb = initProb;
        existAnomaly = true;
    }

    //異変の正誤
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
