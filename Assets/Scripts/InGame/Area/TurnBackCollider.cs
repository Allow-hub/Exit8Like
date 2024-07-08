using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBackCollider : MonoBehaviour
{
    public delegate void TurnBack();
    public static TurnBack onTurnBack;

    private void OnTriggerEnter(Collider other)
    {
        if (onTurnBack == null) return;
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.isBack = true;
            onTurnBack?.Invoke();
        }
    }
}
