using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DebugText : MonoBehaviour
{
    private void Update()
    {
        if(GameManager.Instance != null)
        {
            TextMeshProUGUI tex=GetComponent<TextMeshProUGUI>();
            tex.text = GameManager.Instance.currentState.ToString();
        }
    }
}
