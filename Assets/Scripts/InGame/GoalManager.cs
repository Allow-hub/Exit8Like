using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class GoalManager : MonoBehaviour
{
    [SerializeField] private GameObject trueArea, badArea,player;
    [SerializeField] private GameObject trueEffect,badEffect;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private PlayerCamera playerCamera;
    [SerializeField] private PlayerAnimation playerAnimation;
    [SerializeField] private Ending ending;
    [SerializeField] private Transform targetPos, targetPosDown;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite backPlayer;
    [SerializeField] private float speed,sitSpeed,coolDown;
    private bool isAnimation=false,isReverse;

    [SerializeField] private Sprite[] playerAnimSprite;
    private void Start()
    {
        trueEffect.SetActive(false);
        badEffect.SetActive(false);

        isAnimation = false;
        isReverse=false;
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
        yield return new WaitForSeconds(2f);
        isAnimation = true;
        StartCoroutine(Animation());
        badEffect.SetActive(true);
        // 現在の位置が目標位置に近づくまでループ
        while (Vector3.Distance(player.transform.position, targetPos.position) > 0.1f)
        {

            // 一定速度で目標位置に向かって移動
            player.transform.position = Vector3.MoveTowards(player.transform.position, targetPos.position, speed * Time.deltaTime);
            yield return null; // フレームごとに処理を一時停止
        }

        isAnimation = false;
        // 最後に目標位置にぴったり位置を合わせる
        player.transform.position = targetPos.position;
        //spriteRenderer.sprite = backPlayer;

        playerCamera.enabled = false;
        yield return new WaitForSeconds(1);

        // 現在の位置が目標位置に近づくまでループ
        while (Vector3.Distance(player.transform.position, targetPosDown.position) > 0.01f)
        {
            // 一定速度で目標位置に向かって移動
            player.transform.position = Vector3.MoveTowards(player.transform.position, targetPosDown.position, sitSpeed * Time.deltaTime);
            yield return null; // フレームごとに処理を一時停止
        }
        ending.StartCoroutine(ending.EndRoll(true));
    }
    private IEnumerator TrueAnimation()
    {
        playerInput.ResetInput();

        playerInput.enabled = false;
        yield return new WaitForSeconds(2f);
        isAnimation = true;
        trueEffect.SetActive(true);

        StartCoroutine(Animation());
        // 現在の位置が目標位置に近づくまでループ
        while (Vector3.Distance(player.transform.position, targetPos.position) > 0.1f)
        {
            // 一定速度で目標位置に向かって移動
            player.transform.position = Vector3.MoveTowards(player.transform.position, targetPos.position, speed * Time.deltaTime);
            yield return null; // フレームごとに処理を一時停止
        }
        isAnimation = false;

        // 最後に目標位置にぴったり位置を合わせる
        player.transform.position = targetPos.position;
        //spriteRenderer.sprite = backPlayer;

        playerCamera.enabled = false;
        yield return new WaitForSeconds(1);
        // 現在の位置が目標位置に近づくまでループ
        while (Vector3.Distance(player.transform.position, targetPosDown.position) > 0.01f)
        {
            // 一定速度で目標位置に向かって移動
            player.transform.position = Vector3.MoveTowards(player.transform.position, targetPosDown.position, sitSpeed * Time.deltaTime);
            yield return null; // フレームごとに処理を一時停止
        }
        ending.StartCoroutine(ending.EndRoll(false));

    }

    private IEnumerator Animation()
    {
        while(isAnimation)
        {
            if (!isReverse)
            {
                for (int i = 0; i < playerAnimSprite.Length; i++)
                {
                    spriteRenderer.sprite = playerAnimSprite[i];
                    yield return new WaitForSeconds(coolDown);
                }
            }
            else
            {
                for (int i = playerAnimSprite.Length - 1; i >= 0; i--)
                {
                    spriteRenderer.sprite = playerAnimSprite[i];
                    yield return new WaitForSeconds(coolDown);
                }
            }

            isReverse = !isReverse;
        }
        spriteRenderer.sprite = backPlayer;

    }
}
