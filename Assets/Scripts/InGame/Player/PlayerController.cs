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
    [SerializeField] private Transform limitObject; // �ړ�������������I�u�W�F�N�g��Transform

    [Header("Animation")]
    [SerializeField] private PlayerAnimation playerAnimation;

    private const float magnification = 2; // �_�b�V�����̑��x�{��
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

    // �v���C���[�̓���
    private void Move()
    {
        Vector3 moveDirection = playerInput.InputVector.normalized;

        // �_�b�V�����̑��x���v�Z
        float currentSpeed = playerInput.IsDash ? moveSpeed * magnification : moveSpeed;

        // �ʒu���v�Z���Ĉړ�
        Vector3 newPosition = transform.position + moveDirection * currentSpeed * Time.deltaTime;

        // ���񂳂ꂽx���W�𒴂��Ȃ��悤�ɂ���
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
        float speedMultiplier = playerInput.IsDash ? magnification : 1f; // �_�b�V�����̃X�s�[�h�{���Ɋ�Â��A�j���[�V�������x�{��

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
