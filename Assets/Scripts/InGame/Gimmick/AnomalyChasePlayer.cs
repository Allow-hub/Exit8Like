using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnomalyChasePlayer : AnomalyBase
{
    [SerializeField] private bool isClear = false;
    [SerializeField] private float distanceFromPlayer = 2f;
    [SerializeField] private GameObject player, anomaly;
    [SerializeField] private float shiftX, shiftY, shiftZ;
    [SerializeField] private float shiftLeftX;

    [SerializeField] private float followSpeed = 5f; // 追従の速さ
    [SerializeField] private int number;
    [SerializeField] private string explain;

    [SerializeField] private PlayerInput playerInput;
    private Vector3 lastInput;
    // Start is called before the first frame update
    void Awake()
    {
        SetProperety();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void SetProperety()
    {
        IsClear = isClear;
        DistanceFromPlayer = distanceFromPlayer;
        Number = number;
        Explain = explain;
    }

    public override void Animation()
    {
        base.Animation();
        anomaly.gameObject.SetActive(true);
        StartCoroutine(Move());
    }

    public override void ReverseAnomaly()
    {
        base.ReverseAnomaly();
        anomaly.gameObject.SetActive(false);
    }

    private IEnumerator Move()
    {
        while (IsAnomaly)
        {
            lastInput = playerInput.InputVector.x != 0 ? playerInput.InputVector : lastInput;
            if (lastInput.x < 0)
            {
                Vector3 targetPosition = new Vector3(player.transform.position.x + shiftLeftX, player.transform.position.y + shiftY, player.transform.position.z + shiftZ);
                anomaly.transform.position = Vector3.Lerp(anomaly.transform.position, targetPosition, followSpeed * Time.deltaTime);
                anomaly.transform.localEulerAngles = new Vector3(0,180,0);
            }else if(lastInput.x > 0)
            {
                Vector3 targetPosition = new Vector3(player.transform.position.x + shiftX, player.transform.position.y + shiftY, player.transform.position.z + shiftZ);
                anomaly.transform.position = Vector3.Lerp(anomaly.transform.position, targetPosition, followSpeed * Time.deltaTime);
                anomaly.transform.localEulerAngles = new Vector3(0, 0, 0);

            }
            yield return null; // フレームごとに更新
        }
    }
}
