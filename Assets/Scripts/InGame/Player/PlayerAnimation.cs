using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    [SerializeField] private Sprite[] PlayerLeft;
    [SerializeField] private Sprite[] PlayerRight;
    [SerializeField] private float Cooldown = 0.5f;

    private SpriteRenderer spriteRenderer;
    private bool reverseOrder = false;
        

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Animation()
    {
        StartCoroutine(RightChangeSprite());
        StartCoroutine(LeftChangeSprite());
    }
   
    private IEnumerator RightChangeSprite()
    {
        while (true)
        {
            if (!reverseOrder)
            {
                for (int i = 0; i < PlayerLeft.Length; i++)
                {
                    spriteRenderer.sprite = PlayerLeft[i];
                    yield return new WaitForSeconds(Cooldown);
                }
            }
            else
            {
                for (int i = PlayerLeft.Length - 1; i >= 0; i--)
                {
                    spriteRenderer.sprite = PlayerLeft[i];
                    yield return new WaitForSeconds(Cooldown);
                }
            }
        }
    }

    private IEnumerator LeftChangeSprite()
    {
        while (true)
        {
            if (!reverseOrder)
            {
                for (int i = 0; i < PlayerRight.Length; i++)
                {
                    spriteRenderer.sprite = PlayerRight[i];
                    yield return new WaitForSeconds(Cooldown);
                }
            }
            else
            {
                for (int i = PlayerRight.Length; i >= 0; i--)
                {
                    spriteRenderer.sprite = PlayerRight[i];
                    yield return new WaitForSeconds(Cooldown);
                }

            }
        }
    }


}

