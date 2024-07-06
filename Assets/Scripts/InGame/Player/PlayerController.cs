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
    //�v���C���[�̓���
    private void Move()
    {
        Vector3 moveDirection = playerInput.InputVector.normalized;
        float moveInput = playerInput.InputVector.x;
        lastInput = playerInput.InputVector.x != 0 ? playerInput.InputVector : lastInput;

        // ���E�̌����ɉ����ĉ�]�p�x��ݒ�
        float targetRotation = lastInput.x > 0 ? 0f : 180f;

        // ���݂̃v���C���[�̊p�x���擾
        Vector3 currentRotation = playerObj.transform.eulerAngles;

        // Y���̉�]������ݒ肵�ĉ�]
        playerObj.transform.eulerAngles = new Vector3(currentRotation.x, targetRotation, currentRotation.z);

        Vector3 newPosition = transform.position + moveDirection * moveSpeed * Time.deltaTime;
        rb.MovePosition(newPosition);
    }

}
