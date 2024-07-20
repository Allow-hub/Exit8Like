using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    [SerializeField] private Sprite[] PlayerLeft;
    [SerializeField] private Sprite[] PlayerRight;
    [SerializeField] private float Cooldown;

    // Start is called before the first frame update
    void Start()
    {
        Animation();
    }

    private void Animation()
    {
        StartCoroutine(ChangeSprite());
    }
   
    private IEnumerator ChangeSprite()
    {
        while (true)
        {

        }
    }


}

