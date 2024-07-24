using System.Collections;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Sprite[] PlayerLeft;
    [SerializeField] private Sprite[] PlayerRight;
    [SerializeField] private float baseCooldown = 0.5f; // 基本のクールダウン時間

    [SerializeField] SpriteRenderer spriteRenderer;
    public bool isAnimating = false; // アニメーション制御のためのフラグ

    private bool reverseOrder = false;
    private Coroutine currentCoroutine = null; // 現在のコルーチンを保存

    private void Awake()
    {
    }

    public void StartRightAnimation(float speedMultiplier)
    {
        StopCurrentAnimation();
        isAnimating = true;
        float cooldown = baseCooldown / speedMultiplier; // ダッシュ時のクールダウン時間を計算
        currentCoroutine = StartCoroutine(RightChangeSprite(cooldown));
    }

    public void StartLeftAnimation(float speedMultiplier)
    {
        StopCurrentAnimation();
        isAnimating = true;
        float cooldown = baseCooldown / speedMultiplier; // ダッシュ時のクールダウン時間を計算
        currentCoroutine = StartCoroutine(LeftChangeSprite(cooldown));
    }

    public void StopAnimation()
    {
        StopCurrentAnimation();
        isAnimating = false;
    }

    private void StopCurrentAnimation()
    {
        if (currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
            currentCoroutine = null;
        }
    }

    private IEnumerator LeftChangeSprite(float cooldown)
    {
        while (isAnimating)
        {
            if (!reverseOrder)
            {
                for (int i = 0; i < PlayerLeft.Length; i++)
                {
                    spriteRenderer.sprite = PlayerLeft[i];
                    yield return new WaitForSeconds(cooldown); // クールダウン時間を調整
                }
            }
            else
            {
                for (int i = PlayerLeft.Length - 2; i > 0; i--)
                {
                    spriteRenderer.sprite = PlayerLeft[i];
                    yield return new WaitForSeconds(cooldown); // クールダウン時間を調整
                }
            }
            reverseOrder = !reverseOrder;
        }
    }

    private IEnumerator RightChangeSprite(float cooldown)
    {
        while (isAnimating)
        {
            if (!reverseOrder)
            {
                for (int i = 0; i < PlayerRight.Length; i++)
                {
                    spriteRenderer.sprite = PlayerRight[i];
                    yield return new WaitForSeconds(cooldown); // クールダウン時間を調整
                }
            }
            else
            {
                for (int i = PlayerRight.Length - 2; i > 0; i--)
                {
                    spriteRenderer.sprite = PlayerRight[i];
                    yield return new WaitForSeconds(cooldown); // クールダウン時間を調整
                }
            }
            reverseOrder = !reverseOrder;
        }
    }
}