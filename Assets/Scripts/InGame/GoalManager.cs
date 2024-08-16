using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class GoalManager : MonoBehaviour
{
    [SerializeField] private GameObject trueArea, badArea,player;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private Transform targetPos;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite backPlayer;
    [SerializeField] private float speed;
 
    private void Start()
    {
        trueArea.SetActive(false);
        badArea.SetActive(false);
    }

    public void BadEnd()
    {
        badArea.SetActive(true);
        StartCoroutine(BadAnimation());
    }

    public void TrueEnd()
    {
        trueArea.SetActive(true);
        StartCoroutine (TrueAnimation());
    }
    private IEnumerator BadAnimation()
    {
        playerInput.ResetInput();
        playerInput.enabled = false;

        // ���݂̈ʒu���ڕW�ʒu�ɋ߂Â��܂Ń��[�v
        while (Vector3.Distance(player.transform.position, targetPos.position) > 0.1f)
        {
            // ��葬�x�ŖڕW�ʒu�Ɍ������Ĉړ�
            player.transform.position = Vector3.MoveTowards(player.transform.position, targetPos.position, speed * Time.deltaTime);
            yield return null; // �t���[�����Ƃɏ������ꎞ��~
        }

        // �Ō�ɖڕW�ʒu�ɂ҂�����ʒu�����킹��
        player.transform.position = targetPos.position;
        spriteRenderer.sprite = backPlayer;
    }
    private IEnumerator TrueAnimation()
    {
        playerInput.ResetInput();

        playerInput.enabled = false;

        // ���݂̈ʒu���ڕW�ʒu�ɋ߂Â��܂Ń��[�v
        while (Vector3.Distance(player.transform.position, targetPos.position) > 0.1f)
        {
            // ��葬�x�ŖڕW�ʒu�Ɍ������Ĉړ�
            player.transform.position = Vector3.MoveTowards(player.transform.position, targetPos.position, speed * Time.deltaTime);
            yield return null; // �t���[�����Ƃɏ������ꎞ��~
        }

        // �Ō�ɖڕW�ʒu�ɂ҂�����ʒu�����킹��
        player.transform.position = targetPos.position;
        spriteRenderer.sprite = backPlayer;
    }
}
