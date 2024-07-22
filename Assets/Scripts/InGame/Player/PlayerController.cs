using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private PlayerInput playerInput;

    [Header("Movement")]
    [SerializeField] private float moveSpeed;

    private const float magnification = 3; // ダッシュ時の速度倍率
    private Vector3 lastInput;
    private GameObject playerObj;
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerObj = this.gameObject.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    // プレイヤーの動き
    private void Move()
    {
        Vector3 moveDirection = playerInput.InputVector.normalized;
        //lastInput = playerInput.InputVector.x != 0 ? playerInput.InputVector : lastInput;

        //// 左右の向きに応じて回転角度を設定
        //float targetRotation = lastInput.x > 0 ? 0f : 180f;

        //// 現在のプレイヤーの角度を取得
        //Vector3 currentRotation = playerObj.transform.eulerAngles;

        //// Y軸の回転だけを設定して回転
        //playerObj.transform.eulerAngles = new Vector3(currentRotation.x, targetRotation, currentRotation.z);

        // ダッシュ時の速度を計算
        float currentSpeed = playerInput.IsDash ? moveSpeed * magnification : moveSpeed;

        // 位置を計算して移動
        Vector3 newPosition = transform.position + moveDirection * currentSpeed * Time.deltaTime;
        rb.MovePosition(newPosition);
    }
}
