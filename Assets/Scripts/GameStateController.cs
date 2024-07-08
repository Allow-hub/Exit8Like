using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateController : MonoBehaviour
{
    private void OnEnable()
    {
        TurnBackCollider.onTurnBack += ChangeStateCheckAnomalies;
    }

    private void OnDisable()
    {
        TurnBackCollider.onTurnBack -= ChangeStateCheckAnomalies;
    }

    //private void ChangeStateFindingAnomaries()
    //{
    //    if (GameManager.Instance == null) return;
    //    GameManager.Instance.ChangeToFindingAnomaliesState();
    //}
    private void ChangeStateCheckAnomalies()
    {
        if (GameManager.Instance == null) return;
        GameManager.Instance.ChangeToCheckAnomaliesState();
    }
}
