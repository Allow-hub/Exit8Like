using System.Collections;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Sprite[] PlayerLeft;
    [SerializeField] private Sprite[] PlayerRight;
    [SerializeField] private float baseCooldown = 0.5f; // 基本のクールダウン時間

    [SerializeField] SpriteRenderer spriteRenderer;
    public bool isAnimating = false; // アニメーション制御のためのフラグ

    private float currentCooldown;
    private bool reverseOrder = false;
    private Coroutine currentCoroutine = null; // 現在のコルーチンを保存

    private void Awake()
    {
        currentCooldown = baseCooldown; // 初期クールダウン時間を設定
    }

    public void StartRightAnimation(float speedMultiplier)
    {
        StopCurrentAnimation();
        isAnimating = true;
        UpdateAnimationSpeed(speedMultiplier);
        currentCoroutine = StartCoroutine(RightChangeSprite());
    }

    public void StartLeftAnimation(float speedMultiplier)
    {
        StopCurrentAnimation();
        isAnimating = true;
        UpdateAnimationSpeed(speedMultiplier);
        currentCoroutine = StartCoroutine(LeftChangeSprite());
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

    public void UpdateAnimationSpeed(float speedMultiplier)
    {
        currentCooldown = baseCooldown / speedMultiplier;
    }

    private IEnumerator LeftChangeSprite()
    {
        while (isAnimating)
        {
            if (!reverseOrder)
            {
                for (int i = 0; i < PlayerLeft.Length; i++)
                {
                    spriteRenderer.sprite = PlayerLeft[i];
                    yield return new WaitForSeconds(currentCooldown); // クールダウン時間を調整
                }
            }
            else
            {
                for (int i = PlayerLeft.Length - 2; i > 0; i--)
                {
                    spriteRenderer.sprite = PlayerLeft[i];
                    yield return new WaitForSeconds(currentCooldown); // クールダウン時間を調整
                }
            }
            reverseOrder = !reverseOrder;
        }
    }

    private IEnumerator RightChangeSprite()
    {
        while (isAnimating)
        {
            if (!reverseOrder)
            {
                for (int i = 0; i < PlayerRight.Length; i++)
                {
                    spriteRenderer.sprite = PlayerRight[i];
                    yield return new WaitForSeconds(currentCooldown); // クールダウン時間を調整
                }
            }
            else
            {
                for (int i = PlayerRight.Length - 2; i > 0; i--)
                {
                    spriteRenderer.sprite = PlayerRight[i];
                    yield return new WaitForSeconds(currentCooldown); // クールダウン時間を調整
                }
            }
            reverseOrder = !reverseOrder;
        }
    }
}