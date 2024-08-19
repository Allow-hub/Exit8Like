using System.Collections;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Sprite[] PlayerLeft;
    [SerializeField] private Sprite[] PlayerRight;
    [SerializeField] private float baseCooldown = 0.5f; // 基本のクールダウン時間

    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private Sprite defPlayerLeft,defPlayerRight;
    public bool isAnimating = false; // アニメーション制御のためのフラグ

    private float currentCooldown;
    private bool reverseOrder = false;
    private Coroutine currentCoroutine = null; // 現在のコルーチンを保存

    private Vector3 lastInput;
    private void Awake()
    {
        currentCooldown = baseCooldown; // 初期クールダウン時間を設定
    }
    private void Update()
    {
        lastInput = playerInput.InputVector.x != 0 ? playerInput.InputVector : lastInput;

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

        if (lastInput.x < 0)
        {
            spriteRenderer.sprite = defPlayerLeft;
        }
        else if(lastInput.x > 0)
        {
            spriteRenderer.sprite = defPlayerRight;

        }
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