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
    [SerializeField] private Transform limitObject; // 移動制限をかけるオブジェクトのTransform

    [Header("Animation")]
    [SerializeField] private PlayerAnimation playerAnimation;

    private const float magnification = 2; // ダッシュ時の速度倍率
    private Vector3 lastInput;
    private GameObject playerObj;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerObj = this.gameObject.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Animation();
    }

    // プレイヤーの動き
    private void Move()
    {
        Vector3 moveDirection = playerInput.InputVector.normalized;

        // ダッシュ時の速度を計算
        float currentSpeed = playerInput.IsDash ? moveSpeed * magnification : moveSpeed;

        // 位置を計算して移動
        Vector3 newPosition = transform.position + moveDirection * currentSpeed * Time.deltaTime;

        // 制約されたx座標を超えないようにする
        float limitX = limitObject.position.x;
        if (newPosition.x < limitX)
        {
            newPosition.x = limitX;
        }

        rb.MovePosition(newPosition);
    }

    private void Animation()
    {
        Vector3 moveDirection = playerInput.InputVector.normalized;
        float speedMultiplier = playerInput.IsDash ? magnification : 1f; // ダッシュ時のスピード倍率に基づくアニメーション速度倍率

        if (moveDirection.x > 0)
        {
            if (!playerAnimation.isAnimating)
            {
                playerAnimation.StartRightAnimation(speedMultiplier);
            }
        }
        else if (moveDirection.x < 0)
        {
            if (!playerAnimation.isAnimating)
            {
                playerAnimation.StartLeftAnimation(speedMultiplier);
            }
        }
        else
        {
            if (playerAnimation.isAnimating)
            {
                playerAnimation.StopAnimation();
            }
        }

        playerAnimation.UpdateAnimationSpeed(speedMultiplier);
    }
}
