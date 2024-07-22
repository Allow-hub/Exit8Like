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

    private const float magnification = 3; // �_�b�V�����̑��x�{��
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

    // �v���C���[�̓���
    private void Move()
    {
        Vector3 moveDirection = playerInput.InputVector.normalized;
        //lastInput = playerInput.InputVector.x != 0 ? playerInput.InputVector : lastInput;

        //// ���E�̌����ɉ����ĉ�]�p�x��ݒ�
        //float targetRotation = lastInput.x > 0 ? 0f : 180f;

        //// ���݂̃v���C���[�̊p�x���擾
        //Vector3 currentRotation = playerObj.transform.eulerAngles;

        //// Y���̉�]������ݒ肵�ĉ�]
        //playerObj.transform.eulerAngles = new Vector3(currentRotation.x, targetRotation, currentRotation.z);

        // �_�b�V�����̑��x���v�Z
        float currentSpeed = playerInput.IsDash ? moveSpeed * magnification : moveSpeed;

        // �ʒu���v�Z���Ĉړ�
        Vector3 newPosition = transform.position + moveDirection * currentSpeed * Time.deltaTime;
        rb.MovePosition(newPosition);
    }
}
