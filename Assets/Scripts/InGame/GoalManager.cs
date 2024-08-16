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

        // 現在の位置が目標位置に近づくまでループ
        while (Vector3.Distance(player.transform.position, targetPos.position) > 0.1f)
        {
            // 一定速度で目標位置に向かって移動
            player.transform.position = Vector3.MoveTowards(player.transform.position, targetPos.position, speed * Time.deltaTime);
            yield return null; // フレームごとに処理を一時停止
        }

        // 最後に目標位置にぴったり位置を合わせる
        player.transform.position = targetPos.position;
        spriteRenderer.sprite = backPlayer;
    }
    private IEnumerator TrueAnimation()
    {
        playerInput.ResetInput();

        playerInput.enabled = false;

        // 現在の位置が目標位置に近づくまでループ
        while (Vector3.Distance(player.transform.position, targetPos.position) > 0.1f)
        {
            // 一定速度で目標位置に向かって移動
            player.transform.position = Vector3.MoveTowards(player.transform.position, targetPos.position, speed * Time.deltaTime);
            yield return null; // フレームごとに処理を一時停止
        }

        // 最後に目標位置にぴったり位置を合わせる
        player.transform.position = targetPos.position;
        spriteRenderer.sprite = backPlayer;
    }
}
