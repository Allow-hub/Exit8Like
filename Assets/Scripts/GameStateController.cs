using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateController : MonoBehaviour
{
    private void OnEnable()
    {
        TurnBackCollider.onTurnBack += ChangeStateCheckAnomalies;
        NotBackCollider.onNotBack += ChangeStateCheckAnomalies;
    }

    private void OnDisable()
    {
        TurnBackCollider.onTurnBack -= ChangeStateCheckAnomalies; 
        NotBackCollider.onNotBack -= ChangeStateCheckAnomalies;
    }

    private void Update()
    {
           if(CanClear())
            GameManager.Instance.ChangeToGameClearState();
    }

    private bool CanClear()
    {
        if (GameManager.Instance == null) return false;
        return GameManager.Instance.CurrentNum >= 8;
    }
    private void ChangeStateCheckAnomalies()
    {
        if (GameManager.Instance == null) return;
        GameManager.Instance.ChangeToCheckAnomaliesState();
    }
}
