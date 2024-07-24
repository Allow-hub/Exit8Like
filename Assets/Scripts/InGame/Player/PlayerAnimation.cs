using System.Collections;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Sprite[] PlayerLeft;
    [SerializeField] private Sprite[] PlayerRight;
    [SerializeField] private float baseCooldown = 0.5f; // ��{�̃N�[���_�E������

    [SerializeField] SpriteRenderer spriteRenderer;
    public bool isAnimating = false; // �A�j���[�V��������̂��߂̃t���O

    private bool reverseOrder = false;
    private Coroutine currentCoroutine = null; // ���݂̃R���[�`����ۑ�

    private void Awake()
    {
    }

    public void StartRightAnimation(float speedMultiplier)
    {
        StopCurrentAnimation();
        isAnimating = true;
        float cooldown = baseCooldown / speedMultiplier; // �_�b�V�����̃N�[���_�E�����Ԃ��v�Z
        currentCoroutine = StartCoroutine(RightChangeSprite(cooldown));
    }

    public void StartLeftAnimation(float speedMultiplier)
    {
        StopCurrentAnimation();
        isAnimating = true;
        float cooldown = baseCooldown / speedMultiplier; // �_�b�V�����̃N�[���_�E�����Ԃ��v�Z
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
                    yield return new WaitForSeconds(cooldown); // �N�[���_�E�����Ԃ𒲐�
                }
            }
            else
            {
                for (int i = PlayerLeft.Length - 2; i > 0; i--)
                {
                    spriteRenderer.sprite = PlayerLeft[i];
                    yield return new WaitForSeconds(cooldown); // �N�[���_�E�����Ԃ𒲐�
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
                    yield return new WaitForSeconds(cooldown); // �N�[���_�E�����Ԃ𒲐�
                }
            }
            else
            {
                for (int i = PlayerRight.Length - 2; i > 0; i--)
                {
                    spriteRenderer.sprite = PlayerRight[i];
                    yield return new WaitForSeconds(cooldown); // �N�[���_�E�����Ԃ𒲐�
                }
            }
            reverseOrder = !reverseOrder;
        }
    }
}