using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    [SerializeField] private GameObject[] texObj;
    [SerializeField] private GameObject trueObj, badObj,thanksObj;
    [SerializeField] private Transform spawnPos;
    [SerializeField] private float scrollSpeed;
    [SerializeField] private float spawnInterval = 1f; // スポーン間隔

    [SerializeField] private FadeManager fadeManager;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < texObj.Length; i++)
        {
            texObj[i].SetActive(false);
        }
        trueObj.SetActive(false);
        badObj.SetActive(false);
        thanksObj.SetActive(false);
    }

    public IEnumerator EndRoll(bool isBad)
    {
        for (int i = 0; i < texObj.Length; i++)
        {
            GameObject obj = texObj[i];

            // オブジェクトを非アクティブからアクティブにする
            obj.SetActive(true);

            // Rigidbodyがアタッチされていない場合はアタッチする
            Rigidbody rb = obj.GetComponent<Rigidbody>();
            if (rb == null)
            {
                rb = obj.AddComponent<Rigidbody>();
            }

            // Rigidbodyの設定
            rb.velocity = Vector3.zero; // 初期速度をゼロに設定
            rb.angularVelocity = Vector3.zero; // 初期回転速度をゼロに設定

            // スポーン位置にオブジェクトを配置
            obj.transform.position = spawnPos.position;

            // 上方向にスクロールさせる
            rb.velocity = new Vector3(0, scrollSpeed, 0);

            // スポーン間隔の待機
            yield return new WaitForSeconds(spawnInterval);
        }
        yield return new WaitForSeconds(spawnInterval);
        if (isBad)
        {
            badObj.SetActive(true);
            Rigidbody rb = badObj.GetComponent<Rigidbody>();
            if (rb == null)
            {
                rb = badObj.AddComponent<Rigidbody>();
            }            
            // Rigidbodyの設定
            rb.velocity = Vector3.zero; // 初期速度をゼロに設定
            rb.angularVelocity = Vector3.zero; // 初期回転速度をゼロに設定
                                               // スポーン位置にオブジェクトを配置
            badObj.transform.position = spawnPos.position;

            // 上方向にスクロールさせる
            rb.velocity = new Vector3(0, scrollSpeed, 0);

            yield return new WaitForSeconds(spawnInterval + 1f);
            thanksObj.SetActive(true);
            rb=thanksObj.GetComponent<Rigidbody>();
            // Rigidbodyの設定
            rb.velocity = Vector3.zero; // 初期速度をゼロに設定
            rb.angularVelocity = Vector3.zero; // 初期回転速度をゼロに設定
                                               // スポーン位置にオブジェクトを配置
            thanksObj.transform.position = spawnPos.position;

            // 上方向にスクロールさせる
            rb.velocity = new Vector3(0, scrollSpeed, 0);
        }
        else
        {
            trueObj.SetActive(true);
            Rigidbody rb = trueObj.GetComponent<Rigidbody>();
            if (rb == null)
            {
                rb = trueObj.AddComponent<Rigidbody>();
            }
            // Rigidbodyの設定
            rb.velocity = Vector3.zero; // 初期速度をゼロに設定
            rb.angularVelocity = Vector3.zero; // 初期回転速度をゼロに設定
                                               // スポーン位置にオブジェクトを配置
            trueObj.transform.position = spawnPos.position;

            // 上方向にスクロールさせる
            rb.velocity = new Vector3(0, scrollSpeed, 0);
            yield return new WaitForSeconds(spawnInterval+1f);
            thanksObj.SetActive(true);
            rb = thanksObj.GetComponent<Rigidbody>();
            // Rigidbodyの設定
            rb.velocity = Vector3.zero; // 初期速度をゼロに設定
            rb.angularVelocity = Vector3.zero; // 初期回転速度をゼロに設定
                                               // スポーン位置にオブジェクトを配置
            thanksObj.transform.position = spawnPos.position;

            // 上方向にスクロールさせる
            rb.velocity = new Vector3(0, scrollSpeed, 0);
        }
        // すべてのオブジェクトをスポーンさせた後、必要に応じて処理を終了する
        Debug.Log("All objects have been spawned and are scrolling.");
        yield return new WaitForSeconds(4f);
        fadeManager.StartCoroutine(fadeManager.FadeIn(2f));
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(0);
    }
}
