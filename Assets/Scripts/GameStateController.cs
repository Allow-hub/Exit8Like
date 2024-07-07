using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateController : MonoBehaviour
{
    private void OnEnable()
    {
        TurnBackCollider.onTurnBack += ChangeStateFindingAnomaries;
    }

    private void OnDisable()
    {
        TurnBackCollider.onTurnBack -= ChangeStateFindingAnomaries;
    }

    private void ChangeStateFindingAnomaries()
    {
        if (GameManager.Instance == null) return;
        GameManager.Instance.ChangeToFindingAnomaliesState();
    }
    private void ChangeStateFindingAnomaries()
    {
        if (GameManager.Instance == null) return;
        GameManager.Instance.ChangeToFindingAnomaliesState();
    }
}
