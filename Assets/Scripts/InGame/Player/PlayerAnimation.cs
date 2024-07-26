using System.Collections;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Sprite[] PlayerLeft;
    [SerializeField] private Sprite[] PlayerRight;
    [SerializeField] private float baseCooldown = 0.5f; // ��{�̃N�[���_�E������

    [SerializeField] SpriteRenderer spriteRenderer;
    public bool isAnimating = false; // �A�j���[�V��������̂��߂̃t���O

    private float currentCooldown;
    private bool reverseOrder = false;
    private Coroutine currentCoroutine = null; // ���݂̃R���[�`����ۑ�

    private void Awake()
    {
        currentCooldown = baseCooldown; // �����N�[���_�E�����Ԃ�ݒ�
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
                    yield return new WaitForSeconds(currentCooldown); // �N�[���_�E�����Ԃ𒲐�
                }
            }
            else
            {
                for (int i = PlayerLeft.Length - 2; i > 0; i--)
                {
                    spriteRenderer.sprite = PlayerLeft[i];
                    yield return new WaitForSeconds(currentCooldown); // �N�[���_�E�����Ԃ𒲐�
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
                    yield return new WaitForSeconds(currentCooldown); // �N�[���_�E�����Ԃ𒲐�
                }
            }
            else
            {
                for (int i = PlayerRight.Length - 2; i > 0; i--)
                {
                    spriteRenderer.sprite = PlayerRight[i];
                    yield return new WaitForSeconds(currentCooldown); // �N�[���_�E�����Ԃ𒲐�
                }
            }
            reverseOrder = !reverseOrder;
        }
    }
}