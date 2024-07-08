using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotBackCollider : MonoBehaviour
{
    public delegate void NotBack();
    public static NotBack onNotBack;

    private void OnTriggerEnter(Collider other)
    {
        if (onNotBack == null) return;
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.isBack = false;
            onNotBack?.Invoke();
        }
    }
}
