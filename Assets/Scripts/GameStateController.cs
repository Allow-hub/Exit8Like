using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateController : MonoBehaviour
{
    bool once=false;
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
        if (CanClear() && !once)
        {
            GameManager.Instance.ChangeToGameClearState();
            once = true;
        }
    }

    private bool CanClear()
    {
        if (GameManager.Instance == null) return false;
        return GameManager.Instance.CurrentNum >= 9;
    }
    private void ChangeStateCheckAnomalies()
    {
        if (GameManager.Instance == null) return;
        GameManager.Instance.ChangeToCheckAnomaliesState();
    }
}
